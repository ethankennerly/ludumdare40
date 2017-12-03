using Entitas;
using UnityEngine;
using Finegamedesign.Utils;

public sealed class AirSupplySystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> m_AirSupplies;
    private readonly GameContext m_Context;

    public AirSupplySystem()
    {
        m_Context = Contexts.sharedInstance.game;
        m_AirSupplies = m_Context.GetGroup(GameMatcher.AirSupply);
    }

    public void Execute()
    {
        foreach (var airSupplyEntity in m_AirSupplies.GetEntities())
        {
            AirSupplyComponent airSupply = airSupplyEntity.airSupply;
            Timer timer = airSupply.timer;
            if (timer == null)
            {
                continue;
            }
            timer.Update(-Time.deltaTime);
            GameEntity breather = m_Context.GetEntityWithId(airSupply.breatherId);
            bool isLiving = timer.normal.value > 0.0f;
            if (breather.isLiving == isLiving)
            {
                continue;
            }
            breather.isLiving = isLiving;
        }
    }
}
