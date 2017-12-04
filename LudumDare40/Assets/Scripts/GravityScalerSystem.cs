using UnityEngine;

public sealed class GravityScalerSystem : MonoBehaviour
{
    private static GravityScalerSystem s_Instance;

    public static GravityScalerSystem instance
    {
        get { return s_Instance; }
    }

    [SerializeField]
    private float m_Min = -10.0f;
    [SerializeField]
    private float m_Max = 1.0f;
    [SerializeField]
    private float m_MarginFromZero = 0.16f;

    private void Awake()
    {
        s_Instance = this;
    }

    public void Add(Collider2D other, float amount)
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
