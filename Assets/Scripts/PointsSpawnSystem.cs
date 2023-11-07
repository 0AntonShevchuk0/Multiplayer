using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PointsSpawnSystem : NetworkBehaviour
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

    private readonly List<Vector3> _spawnedPointsPositions = new();

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

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            StartCoroutine(SpawnPoints());
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void SpawnPointServerRpc()
    {
        var pointX = Random.Range(-spawnSquareSize.x / 2f, spawnSquareSize.x / 2f) + spawnSquareCenter.x;
        var pointY = Random.Range(-spawnSquareSize.x / 2f, spawnSquareSize.y / 2f) + spawnSquareCenter.y;
        SpawnPointClientRpc(new Vector3(pointX, pointY, 0f), _spawnedPointsPositions.ToArray());
    }

    [ClientRpc]
    private void SpawnPointClientRpc(Vector3 newPointPosition, Vector3[] spawnedPoints)
    {
        if (_spawnedPointsPositions.Count == 0)
        {
            foreach (var spawnedPointPosition in spawnedPoints)
            {
                Instantiate(pointPrefab, spawnedPointPosition, Quaternion.identity, pointsParent);
            }
        }
        Instantiate(pointPrefab, newPointPosition, Quaternion.identity, pointsParent);
        _spawnedPointsPositions.Add(newPointPosition);
    }

    private IEnumerator SpawnPoints()
    {
        while (true)
        {
            if (_spawnedPointsPositions.Count >= maxPoints) yield return new WaitForEndOfFrame();
            else
            {
                SpawnPointServerRpc();
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}
