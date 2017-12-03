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
        Rigidbody2D body = (Rigidbody2D)other.GetComponent(typeof(Rigidbody2D));
        if (body == null)
        {
            return;
        }
        float gravityScale = body.gravityScale;
        body.gravityScale = Mathf.Clamp(gravityScale + amount, m_Min, m_Max);
    }
}
