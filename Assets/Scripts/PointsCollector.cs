using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerMovement))]
public class PointsCollector : NetworkBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CollectablePoint collectablePoint))
        {
            if (collectablePoint.IsCollected) return;

            if (IsOwner)
            {
                collectablePoint.Collect();
            }

            Destroy(other.gameObject);
        }
    }
}
