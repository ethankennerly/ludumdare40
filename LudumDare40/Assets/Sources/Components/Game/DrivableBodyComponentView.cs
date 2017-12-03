using System;
using UnityEngine;

public sealed class DrivableBodyComponentView : MonoBehaviour
{
    public DrivableBodyComponent m_Component;

    private void OnEnable()
    {
        GameEntity entity = ComponentView.LinkGame(gameObject);
        int index = GameComponentsLookup.DrivableBody;
        entity.ReplaceComponent(index, m_Component);
    }
}
