using UnityEngine;

public class CollectablePoint : MonoBehaviour
{
    [SerializeField] private int score;
    
    public bool IsCollected { get; private set; }

    public void Collect()
    {
        IsCollected = true;
        ScoreSystem.Instance.AddScore(score);
        PointsSpawnSystem.Instance.PointDestroyed();
    }
}
