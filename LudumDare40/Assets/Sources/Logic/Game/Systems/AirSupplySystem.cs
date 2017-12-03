using Entitas;
using UnityEngine;
using Finegamedesign.Utils;

public sealed class AirSupplySystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> m_AirSupplies;

    public AirSupplySystem()
    {
        m_AirSupplies = Contexts.sharedInstance.game.GetGroup(GameMatcher.AirSupply);
    }

    public void Execute()
    {
        foreach (var airSupplyEntity in m_AirSupplies.GetEntities())
        {
            Timer timer = airSupplyEntity.airSupply.timer;
            if (timer == null)
            {
                continue;
            }
            timer.Update(-Time.deltaTime);
        }
    }
}
