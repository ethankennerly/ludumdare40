using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class GravityScaler2D : MonoBehaviour
{
    [SerializeField]
    private float m_Amount = 10.0f;
    [SerializeField]
    private float m_Min = -100.0f;
    [SerializeField]
    private float m_Max = 100.0f;

    private float m_MarginFromZero = 0.16f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Add(other, m_Amount);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Add(other, Time.deltaTime * m_Amount);
    }

    private void Add(Collider2D other, float amount)
    {
        if (amount == 0.0f)
        {
            return;
        }
        Rigidbody2D body = (Rigidbody2D)other.GetComponent(typeof(Rigidbody2D));
        if (body == null)
        {
            return;
        }
        float gravityScale = body.gravityScale;
        gravityScale = Mathf.Clamp(gravityScale + amount, m_Min, m_Max);
        bool isInMargin = gravityScale > -m_MarginFromZero && gravityScale < m_MarginFromZero;
        if (isInMargin)
        {
            if (amount > 0.0f)
            {
                gravityScale = m_MarginFromZero;
            }
            else
            {
                gravityScale = -m_MarginFromZero;
            }
        }
        body.gravityScale = gravityScale;
    }
}
