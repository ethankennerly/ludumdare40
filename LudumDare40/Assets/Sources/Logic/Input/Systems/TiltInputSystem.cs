using Entitas;
using UnityEngine;

public sealed class TiltInputSystem : IExecuteSystem, ICleanupSystem
{
    private readonly InputContext m_Context;
    private readonly IGroup<InputEntity> m_Inputs;

    public TiltInputSystem(Contexts contexts)
    {
        m_Context = contexts.input;
        m_Inputs = m_Context.GetGroup(InputMatcher.Input);
    }

    public void Execute()
    {
        if (!SystemInfo.supportsAccelerometer)
        {
            return;
        }
        Vector3 acceleration = UnityEngine.Input.acceleration;
        if (acceleration.x == 0.0f && acceleration.y == 0.0f)
        {
            return;
        }
        AddInput(acceleration.x, acceleration.y);

    }

    private void AddInput(float worldX, float worldY)
    {
        m_Context.CreateEntity()
            .AddInput(worldX, worldY);
    }

    public void Cleanup()
    {
        InputEntity[] inputEntities = m_Inputs.GetEntities();
        foreach (InputEntity entity in inputEntities)
        {
            entity.Destroy();
        }
    }
}
