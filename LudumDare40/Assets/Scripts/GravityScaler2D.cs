using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class GravityScaler2D : MonoBehaviour
{
    [SerializeField]
    private float m_Amount = 10.0f;

    // Does not cache system, in case it was replaced.
    private void OnTriggerEnter2D(Collider2D other)
    {
        GravityScalerSystem.instance.Add(other, m_Amount);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        GravityScalerSystem.instance.Add(other, Time.deltaTime * m_Amount);
    }
}
