//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AuditComponent audit { get { return (AuditComponent)GetComponent(GameComponentsLookup.Audit); } }
    public bool hasAudit { get { return HasComponent(GameComponentsLookup.Audit); } }

    public void AddAudit(System.Collections.Generic.List<string> newLogs) {
        var index = GameComponentsLookup.Audit;
        var component = CreateComponent<AuditComponent>(index);
        component.logs = newLogs;
        AddComponent(index, component);
    }

    public void ReplaceAudit(System.Collections.Generic.List<string> newLogs) {
        var index = GameComponentsLookup.Audit;
        var component = CreateComponent<AuditComponent>(index);
        component.logs = newLogs;
        ReplaceComponent(index, component);
    }

    public void RemoveAudit() {
        RemoveComponent(GameComponentsLookup.Audit);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity : IAuditEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAudit;

    public static Entitas.IMatcher<GameEntity> Audit {
        get {
            if (_matcherAudit == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Audit);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAudit = matcher;
            }

            return _matcherAudit;
        }
    }
}
