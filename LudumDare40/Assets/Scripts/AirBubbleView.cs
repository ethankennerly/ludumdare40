using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class AirBubbleView : MonoBehaviour
{
    public static event Action<float> onAddAir;

    [SerializeField]
    private float m_AirAmount = 20.0f;

    [SerializeField]
    private bool m_IsStay = false;

    [SerializeField]
    private string m_EndState = "BubblePop";

    private bool m_IsIn = false;

    private Collider2D m_Collider;

    private Animator m_Animator;

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

    private void OnTriggerEnter2D(Collider2D otherNotUsed)
    {
        m_IsIn = true;
        if (onAddAir != null)
        {
            onAddAir(m_AirAmount);
        }
        if (m_IsStay)
        {
            return;
        }
        m_Collider.enabled = false;
        if (m_Animator != null)
        {
            m_Animator.Play(m_EndState);
        }
    }

    // OnTriggerStay2D only fires when moving.
    // IsIn tracks when still too.
    private void Update()
    {
        if (!m_IsIn)
        {
            return;
        }
        if (onAddAir == null)
        {
            return;
        }
        onAddAir(Time.deltaTime * m_AirAmount);
    }

    private void OnTriggerExit2D(Collider2D otherNotUsed)
    {
        m_IsIn = false;
    }
}
