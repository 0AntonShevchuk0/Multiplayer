using UnityEngine;

namespace Task7
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class PointsCollectorT7 : MonoBehaviour
    {
        private int _collectedNumber;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out CollectablePointT7 collectablePoint))
            {
                if (collectablePoint.IsCollected) return;
                
                collectablePoint.Collect();
                Destroy(other.gameObject);
            }
        }
    }
}
