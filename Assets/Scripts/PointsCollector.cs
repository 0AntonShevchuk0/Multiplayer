using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PointsCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CollectablePoint collectablePoint))
        {
            if (collectablePoint.IsCollected) return;
                
            collectablePoint.Collect();
            Destroy(other.gameObject);
        }
    }
}
