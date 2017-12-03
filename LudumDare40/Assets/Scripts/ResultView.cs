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
    }

    private void OnDisable()
    {
        LivingSystem.onLivingChanged -= UpdateLiving;
    }

    private void UpdateLiving(bool isLiving)
    {
        Debug.Log("UpdateLiving: " + isLiving);
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
}
