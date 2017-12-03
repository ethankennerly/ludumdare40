using Entitas;
using UnityEngine;
using Finegamedesign.Utils;

public sealed class AirSupplySystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
{
    private readonly IGroup<GameEntity> m_AirSupplies;
    private readonly GameContext m_Context;

    public AirSupplySystem()
    {
        m_Context = Contexts.sharedInstance.game;
        m_AirSupplies = m_Context.GetGroup(GameMatcher.AirSupply);
    }

    public void Initialize()
    {
        AirBubbleView.onAddAir += AddAir;
    }

    public void TearDown()
    {
        AirBubbleView.onAddAir -= AddAir;
    }

    public void Execute()
    {
        AddAir(-Time.deltaTime);
    }

    private void AddAir(float amount)
    {
        foreach (var breather in m_AirSupplies.GetEntities())
        {
            AirSupplyComponent airSupply = breather.airSupply;
            Timer timer = airSupply.timer;
            if (timer == null)
            {
                continue;
            }
            timer.Update(amount);
            bool isLiving = timer.normal.value > 0.0f;
            if (breather.isLiving == isLiving)
            {
                continue;
            }
            breather.isLiving = isLiving;
        }
    }
}
