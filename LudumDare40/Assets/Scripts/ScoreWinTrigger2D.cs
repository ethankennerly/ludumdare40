using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class ScoreWinTrigger2D : MonoBehaviour
{
    public static event Action onTriggerEnter2D;

    [SerializeField]
    private int m_Min = 1;

    private void OnTriggerEnter2D(Collider2D otherNotUsed)
    {
        int score = ScoreModel.GetInstance().score.value;
        if (score < m_Min)
        {
            return;
        }
        if (onTriggerEnter2D == null)
        {
            return;
        }
        onTriggerEnter2D();
    }
}
