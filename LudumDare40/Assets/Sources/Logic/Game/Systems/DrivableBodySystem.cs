using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class DrivableBodySystem : ReactiveSystem<InputEntity>, IInitializeSystem, ITearDownSystem
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
                AddForce(drivable.drivableBody, input);
            }
        }
    }

    private static void AddForce(DrivableBodyComponent drivable, InputComponent input)
    {
        float dx = 0.0f;
        float dy = 0.0f;
        Rigidbody2D body = drivable.body;
        if (body == null)
        {
            return;
        }
        if (drivable.horizontalEnabled)
        {
            dx = input.x - body.position.x;
        }
        if (drivable.verticalEnabled)
        {
            dx = input.y - body.position.y;
        }
        Vector2 force = new Vector2(
            dx * drivable.force.x,
            dy * drivable.force.y);
        if (input.isImpulse)
        {
            force *= drivable.impulseMultiplier;
        }
        body.AddForce(force);
    }

    public void Initialize()
    {
        LivingSystem.onLivingChanged += OnLivingChanged;
    }

    public void TearDown()
    {
        LivingSystem.onLivingChanged -= OnLivingChanged;
    }

    private void OnLivingChanged(bool isLiving)
    {
        if (isLiving)
        {
            return;
        }
        foreach (var drivable in m_DrivableBodies.GetEntities())
        {
            Rigidbody2D body = drivable.drivableBody.body;
            if (body == null)
            {
                continue;
            }
            GameObject.Destroy(body);
        }
    }
}
