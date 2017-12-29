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
        RemoveListeners();
        ClickPoint.onAxisXY += ReplaceAbsoluteInput;
        KeyView.onKeyDownXY += ReplaceRelativeInput;
    }

    private void RemoveListeners()
    {
        ClickPoint.onAxisXY -= ReplaceAbsoluteInput;
        KeyView.onKeyDownXY -= ReplaceRelativeInput;
    }

    private void ReplaceRelativeInput(float axisX, float axisY)
    {
        m_Input.ReplaceInput(axisX, axisY, true, true);
    }

    private void ReplaceAbsoluteInput(float axisX, float axisY)
    {
        m_Input.ReplaceInput(axisX, axisY, true, false);
    }
}
