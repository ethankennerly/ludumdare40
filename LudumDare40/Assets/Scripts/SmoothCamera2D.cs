using UnityEngine;

public sealed class SmoothCamera2D : MonoBehaviour
{
    public float dampTime = 0.15f;
    public Transform target;
    public Vector3 offset;
    public Vector3 scale = new Vector3(1.0f, 1.0f, 0.0f);

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 position = Vector3.Scale((Vector3.one - scale), offset)
            + Vector3.Scale(scale, target.position);
        transform.position = position;
    }
}
