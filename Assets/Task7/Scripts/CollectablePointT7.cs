using UnityEngine;

namespace Task7
{
    public class CollectablePointT7 : MonoBehaviour
    {
        public bool IsCollected { get; private set; }

        public void Collect()
        {
            IsCollected = true;
            PointsSpawnSystem.Instance.PointDestroyed();
        }
    }
}
