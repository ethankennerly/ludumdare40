using UnityEngine;

public sealed class ResultView : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private string m_PlayState = "none";

    [SerializeField]
    private string m_LoseState = "lose";

    [SerializeField]
    private string m_WinState = "win";

    private void OnEnable()
    {
        LivingSystem.onLivingChanged += UpdateLiving;
        ScoreWinTrigger2D.onTriggerEnter2D += UpdateWin;
    }

    private void OnDisable()
    {
        LivingSystem.onLivingChanged -= UpdateLiving;
        ScoreWinTrigger2D.onTriggerEnter2D -= UpdateWin;
    }

    private void UpdateLiving(bool isLiving)
    {
        string state;
        if (isLiving)
        {
            state = m_PlayState;
        }
        else
        {
            state = m_LoseState;
        }
        m_Animator.Play(state);
    }

    private void UpdateWin()
    {
        m_Animator.Play(m_WinState);
    }
}
