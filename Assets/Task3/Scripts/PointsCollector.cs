using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PointsCollector : MonoBehaviour
{
    private int _collectedNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CollectablePoint>() != null)
        {
            _collectedNumber++;
            Destroy(other.gameObject);
        }
    }
}
