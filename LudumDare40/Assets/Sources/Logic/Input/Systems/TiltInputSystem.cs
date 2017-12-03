using Entitas;
using UnityEngine;

public sealed class TiltInputSystem : IExecuteSystem
{
    private readonly InputEntity m_Input;

    private const float kSquareThreshold = 0.05f * 0.05f;

    public TiltInputSystem(Contexts contexts)
    {
        m_Input = contexts.input.CreateEntity();
    }

    public void Execute()
    {
        Vector3 acceleration = UnityEngine.Input.acceleration;
        if (acceleration.sqrMagnitude <= kSquareThreshold)
        {
            return;
        }
        m_Input.ReplaceInput(acceleration.x, acceleration.y, false);
    }
}
