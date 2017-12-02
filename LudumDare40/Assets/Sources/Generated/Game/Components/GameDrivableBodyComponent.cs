//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DrivableBodyComponent drivableBody { get { return (DrivableBodyComponent)GetComponent(GameComponentsLookup.DrivableBody); } }
    public bool hasDrivableBody { get { return HasComponent(GameComponentsLookup.DrivableBody); } }

    public void AddDrivableBody(UnityEngine.Rigidbody2D newBody, bool newHorizontalEnabled, bool newVerticalEnabled, UnityEngine.Vector2 newForce) {
        var index = GameComponentsLookup.DrivableBody;
        var component = CreateComponent<DrivableBodyComponent>(index);
        component.body = newBody;
        component.horizontalEnabled = newHorizontalEnabled;
        component.verticalEnabled = newVerticalEnabled;
        component.force = newForce;
        AddComponent(index, component);
    }

    public void ReplaceDrivableBody(UnityEngine.Rigidbody2D newBody, bool newHorizontalEnabled, bool newVerticalEnabled, UnityEngine.Vector2 newForce) {
        var index = GameComponentsLookup.DrivableBody;
        var component = CreateComponent<DrivableBodyComponent>(index);
        component.body = newBody;
        component.horizontalEnabled = newHorizontalEnabled;
        component.verticalEnabled = newVerticalEnabled;
        component.force = newForce;
        ReplaceComponent(index, component);
    }

    public void RemoveDrivableBody() {
        RemoveComponent(GameComponentsLookup.DrivableBody);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDrivableBody;

    public static Entitas.IMatcher<GameEntity> DrivableBody {
        get {
            if (_matcherDrivableBody == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DrivableBody);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDrivableBody = matcher;
            }

            return _matcherDrivableBody;
        }
    }
}
