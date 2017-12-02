using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class DrivableBodySystem : ReactiveSystem<InputEntity>
{
    private readonly IGroup<GameEntity> m_DrivableBodies;

    public DrivableBodySystem(Contexts contexts) : base(contexts.input)
    {
        m_DrivableBodies = Contexts.sharedInstance.game.GetGroup(GameMatcher.DrivableBody);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Input.Added());
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> inputEntities)
    {
        for (int inputIndex = 0, inputEnd = inputEntities.Count; inputIndex < inputEnd; ++inputIndex)
        {
            InputEntity inputEntity = inputEntities[inputIndex];
            InputComponent input = inputEntity.input;
            foreach (var drivable in m_DrivableBodies.GetEntities())
            {
                AddForce(drivable.drivableBody, input.x, input.y);
            }
        }
    }

    private static void AddForce(DrivableBodyComponent drivable, float worldX, float worldY)
    {
        float dx = 0.0f;
        float dy = 0.0f;
        Rigidbody2D body = drivable.body;
        if (drivable.horizontalEnabled)
        {
            dx = worldX - body.position.x;
        }
        if (drivable.verticalEnabled)
        {
            dx = worldY - body.position.y;
        }
        Vector2 force = new Vector2(
            dx * drivable.force.x,
            dy * drivable.force.y);
        body.AddForce(force);
    }
}
