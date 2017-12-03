using Entitas;

public sealed class ClickPointInputSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
{
    private readonly InputContext m_Context;
    private readonly InputEntity m_Input;

    public ClickPointInputSystem(Contexts contexts)
    {
        m_Context = contexts.input;
        m_Input = m_Context.CreateEntity();
    }

    public void Initialize()
    {
        AddListeners();
    }

    public void TearDown()
    {
        RemoveListeners();
    }

    public void Execute()
    {
        ClickPoint.Update();
    }

    private void AddListeners()
    {
        ClickPoint.onClickXY += m_Input.ReplaceInput;
    }

    private void RemoveListeners()
    {
        ClickPoint.onClickXY -= m_Input.ReplaceInput;
    }
}
