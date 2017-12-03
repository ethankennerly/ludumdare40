using Entitas;
using Finegamedesign.Utils;

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
        KeyView.Update();
    }

    private void AddListeners()
    {
        ClickPoint.onAxisXY += ReplaceInput;
        KeyView.onKeyDownXY += ReplaceInput;
    }

    private void RemoveListeners()
    {
        ClickPoint.onAxisXY -= ReplaceInput;
        KeyView.onKeyDownXY -= ReplaceInput;
    }

    private void ReplaceInput(float axisX, float axisY)
    {
        DebugUtil.Log("ReplaceInput: " + axisX + ", " + axisY);
        m_Input.ReplaceInput(axisX, axisY, true);
    }
}
