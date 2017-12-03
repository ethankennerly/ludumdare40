using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class LivingSystem : ReactiveSystem<GameEntity>
{
    public static event Action<bool> onLivingChanged;

    public LivingSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(
            GameMatcher.Living.Added(),
            GameMatcher.Living.Removed()
        );
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        for (int gameIndex = 0, gameEnd = entities.Count; gameIndex < gameEnd; ++gameIndex)
        {
            GameEntity gameEntity = entities[gameIndex];
            if (onLivingChanged != null)
            {
                onLivingChanged(gameEntity.isLiving);
            }
            break;
        }
    }
}
