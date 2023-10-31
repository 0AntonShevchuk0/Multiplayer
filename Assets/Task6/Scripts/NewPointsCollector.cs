using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))] 
public class NewPointsCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out NewCollectablePoint collectablePoint))
        {
            ScoreSystem.Instance.AddScore(collectablePoint.Score);
            Destroy(other.gameObject);
        }
    }
}
