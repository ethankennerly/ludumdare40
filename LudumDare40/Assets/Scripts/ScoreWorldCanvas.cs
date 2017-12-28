using UnityEngine;
using UnityEngine.UI;

public sealed class ScoreWorldCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject m_PointPrefab;
    [SerializeField]
    private GameObject m_Canvas;

    private void OnEnable()
    {
        OnDisable();
        ScoreTrigger2D.onAddPointsAtPosition2D += SpawnPointText;
    }

    private void OnDisable()
    {
        ScoreTrigger2D.onAddPointsAtPosition2D -= SpawnPointText;
    }

    private void SpawnPointText(int points, float x, float y)
    {
        Vector3 position = new Vector3(x, y, 0f);
        GameObject pointObject = GameObject.Instantiate(m_PointPrefab, position,
            Quaternion.identity, m_Canvas.transform);
        Text pointText = pointObject.GetComponentInChildren<Text>();
        string text;
        if (points > 0)
        {
            text = "+" + points.ToString();
        }
        else
        {
            text = points.ToString();
        }
        pointText.text = text;
    }
}
