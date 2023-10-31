using System.Collections;
using UnityEngine;

public class PointsSpawnSystem : MonoBehaviour
{
    public static PointsSpawnSystem Instance { get; private set; }
    
    [Header("Objects settings")]
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private Transform pointsParent;

    [Header("Spawn settings")]
    [SerializeField] private Vector2 spawnSquareCenter;
    [SerializeField] private Vector2 spawnSquareSize;
    [Tooltip("Interval in seconds")]
    [SerializeField] [Range(0f, 60f)] private float spawnInterval;
    [SerializeField] [Range(0, 1000000)] private int maxPoints;

    private int _numberOfPoints;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is more than 1 PointsSpawnSystem");
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        StartCoroutine(SpawnPoints());
    }

    public void PointDestroyed()
    {
        if (_numberOfPoints == 0)
        {
            Debug.LogError("You destroyed too many points");
            return;
        }
        _numberOfPoints--;
    }

    private IEnumerator SpawnPoints()
    {
        while (true)
        {
            if (_numberOfPoints >= maxPoints) yield return new WaitForEndOfFrame();
            else
            {
                var pointX = Random.Range(-spawnSquareSize.x / 2f, spawnSquareSize.x / 2f) + spawnSquareCenter.x;
                var pointY = Random.Range(-spawnSquareSize.x / 2f, spawnSquareSize.y / 2f) + spawnSquareCenter.y;
                Instantiate(pointPrefab, new Vector3(pointX, pointY, 0f), Quaternion.identity, pointsParent);
                _numberOfPoints++;
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}
