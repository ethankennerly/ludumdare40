using UnityEngine;
using UnityEngine.UI;

public sealed class ScoreView : MonoBehaviour
{
    [SerializeField]
    private Text m_ScoreText;

    [SerializeField]
    private Text m_HighScoreText;

    private ScoreModel m_ScoreModel = ScoreModel.GetInstance();

    private void OnEnable()
    {
        OnDisable();
        UpdateScore(m_ScoreModel.score.value);
        m_ScoreModel.score.onChanged += UpdateScore;

        UpdateHighScore(m_ScoreModel.highScore.value);
        m_ScoreModel.highScore.onChanged += UpdateHighScore;
    }

    private void OnDisable()
    {
        m_ScoreModel.score.onChanged -= UpdateScore;
        m_ScoreModel.highScore.onChanged -= UpdateHighScore;
    }

    private void UpdateScore(int value)
    {
        if (m_ScoreText != null)
        {
            m_ScoreText.text = value.ToString();
        }
    }

    private void UpdateHighScore(int value)
    {
        if (m_HighScoreText != null)
        {
            m_HighScoreText.text = value.ToString();
        }
    }
}
