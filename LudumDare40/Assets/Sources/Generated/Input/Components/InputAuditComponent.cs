//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public AuditComponent audit { get { return (AuditComponent)GetComponent(InputComponentsLookup.Audit); } }
    public bool hasAudit { get { return HasComponent(InputComponentsLookup.Audit); } }

    public void AddAudit(System.Collections.Generic.List<string> newLogs) {
        var index = InputComponentsLookup.Audit;
        var component = CreateComponent<AuditComponent>(index);
        component.logs = newLogs;
        AddComponent(index, component);
    }

    public void ReplaceAudit(System.Collections.Generic.List<string> newLogs) {
        var index = InputComponentsLookup.Audit;
        var component = CreateComponent<AuditComponent>(index);
        component.logs = newLogs;
        ReplaceComponent(index, component);
    }

    public void RemoveAudit() {
        RemoveComponent(InputComponentsLookup.Audit);
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
public partial class InputEntity : IAuditEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherAudit;

    public static Entitas.IMatcher<InputEntity> Audit {
        get {
            if (_matcherAudit == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Audit);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherAudit = matcher;
            }

            return _matcherAudit;
        }
    }
}
