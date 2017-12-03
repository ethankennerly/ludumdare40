using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class ScoreTrigger2D : MonoBehaviour
{
    public static event Action<GameObject> onPickup;

    [SerializeField]
    private int m_Amount = 1;

    [SerializeField]
    private bool m_IsPickup = true;

    [SerializeField]
    private string m_EndState = "TreasureTaken";

    private Animator m_Animator;

    private ScoreModel m_ScoreModel = ScoreModel.GetInstance();

    private Collider2D m_Collider;

    private void OnEnable()
    {
        if (m_Collider == null)
        {
            m_Collider = (Collider2D)GetComponent(typeof(Collider2D));
        }

        if (m_Animator == null)
        {
            m_Animator = (Animator)GetComponent(typeof(Animator));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        m_Collider.enabled = false;

        m_ScoreModel.score.value += m_Amount;

        if (m_IsPickup && onPickup != null)
        {
            onPickup(gameObject);
        }

        if (m_Animator != null)
        {
            m_Animator.Play(m_EndState);
        }
    }
}
