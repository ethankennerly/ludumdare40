using Entitas;
using Finegamedesign.Utils;

public sealed class ClickPointInputSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
{
    private const float kKeyForceMultiplier = 0.5f;

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
        ClickPoint.onAxisXY += ReplaceInput;
        KeyView.onKeyDownXY += ReplaceSmallInput;
    }

    private void RemoveListeners()
    {
        ClickPoint.onAxisXY -= ReplaceInput;
        KeyView.onKeyDownXY -= ReplaceSmallInput;
    }

    private void ReplaceSmallInput(float axisX, float axisY)
    {
        m_Input.ReplaceInput(kKeyForceMultiplier * axisX,
            kKeyForceMultiplier * axisY, true, true);
    }

    private void ReplaceInput(float axisX, float axisY)
    {
        m_Input.ReplaceInput(axisX, axisY, true, false);
    }
}
