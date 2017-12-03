using Entitas;
using UnityEngine;

public sealed class TiltInputSystem : IExecuteSystem
{
    private readonly InputContext m_Context;
    private readonly InputEntity m_Input;

    public TiltInputSystem(Contexts contexts)
    {
        m_Context = contexts.input;
        m_Input = m_Context.CreateEntity();
    }

    public void Execute()
    {
        Vector3 acceleration = UnityEngine.Input.acceleration;
        if (acceleration.x == 0.0f && acceleration.y == 0.0f)
        {
            return;
        }
        ReplaceInput(acceleration.x, acceleration.y);

    }

    private void ReplaceInput(float worldX, float worldY)
    {
        m_Input.ReplaceInput(worldX, worldY);
    }
}
