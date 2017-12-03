using System;
using UnityEngine;
using Finegamedesign.Utils;

public sealed class AirSupplyComponentView : MonoBehaviour
{
    public AirSupplyComponent m_Component;

    private void OnEnable()
    {
        TimerView timerView = GetComponent<TimerView>();
        if (timerView.model == null)
        {
            timerView.model = new Timer();
        }
        m_Component.timer = timerView.model;
        GameEntity entity = ComponentView.LinkGame(gameObject);
        int index = GameComponentsLookup.AirSupply;
        entity.AddComponent(index, m_Component);
    }
}
