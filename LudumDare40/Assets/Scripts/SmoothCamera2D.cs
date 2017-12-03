using UnityEngine;

public sealed class SmoothCamera2D : MonoBehaviour
{
    private const float kBoundary = 10000.0f;

    public Transform target;
    public Vector3 offset;
    public Vector3 scale = new Vector3(1.0f, 1.0f, 0.0f);
    public Vector3 min = new Vector3(-kBoundary, -kBoundary, -kBoundary);
    public Vector3 max = new Vector3(kBoundary, kBoundary, kBoundary);

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
        position.x = Mathf.Clamp(position.x, min.x, max.x);
        position.y = Mathf.Clamp(position.y, min.y, max.y);
        position.z = Mathf.Clamp(position.z, min.z, max.z);
        transform.position = position;
    }
}
