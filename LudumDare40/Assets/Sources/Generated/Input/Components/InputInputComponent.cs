//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputComponent input { get { return (InputComponent)GetComponent(InputComponentsLookup.Input); } }
    public bool hasInput { get { return HasComponent(InputComponentsLookup.Input); } }

    public void AddInput(float newX, float newY) {
        var index = InputComponentsLookup.Input;
        var component = CreateComponent<InputComponent>(index);
        component.x = newX;
        component.y = newY;
        AddComponent(index, component);
    }

    public void ReplaceInput(float newX, float newY) {
        var index = InputComponentsLookup.Input;
        var component = CreateComponent<InputComponent>(index);
        component.x = newX;
        component.y = newY;
        ReplaceComponent(index, component);
    }

    public void RemoveInput() {
        RemoveComponent(InputComponentsLookup.Input);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherInput;

    public static Entitas.IMatcher<InputEntity> Input {
        get {
            if (_matcherInput == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Input);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInput = matcher;
            }

            return _matcherInput;
        }
    }
}