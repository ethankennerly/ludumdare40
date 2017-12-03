using Entitas;

public sealed class ClickPointInputSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
{
    private readonly InputContext m_Context;
    private readonly InputEntity m_Input;

    private float inputMultiplier = 20.0f;

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
        ClickPoint.onClickXY += ReplaceInput;
    }

    private void RemoveListeners()
    {
        ClickPoint.onClickXY -= ReplaceInput;
    }

    private void ReplaceInput(float worldX, float worldY)
    {
        m_Input.ReplaceInput(inputMultiplier * worldX, inputMultiplier * worldY);
    }
}
