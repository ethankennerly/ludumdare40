using UnityEngine;
using Entitas.Unity;

public sealed class ComponentView
{
    public static GameEntity LinkGame(GameObject gameObject)
    {
        GameContext context = Contexts.sharedInstance.game;
        GameEntity entity = context.CreateEntity();
        gameObject.Link(entity, context);
        return entity;
    }
}
