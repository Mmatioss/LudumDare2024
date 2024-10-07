using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Spawn Points")]
    [SerializeField] private Transform[] _points = new Transform[3];

    [Header("Parameters")]
    [SerializeField, Range(.5f, 3f)] private float _spawnCooldown;
    [SerializeField, Range(1, 5)] private int _spawnAmount;

    [Header("Enemies Types")]
    [SerializeField] private GameObject[] _ennemiesTypes = new GameObject[4];

    private float _spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        _spawnTime = _spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawner();
    }

    void SpawnEnemy(GameObject enemy, Transform point)
    {
        Instantiate(enemy, point.position, point.rotation);
    }

    void SpawnWave(int amount, GameObject enemyType, Transform point)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnEnemy(enemyType, point);
        }
    }

    void UpdateSpawner()
    {
        _spawnTime -= Time.deltaTime;
        if (_spawnTime < 0)
        {
            foreach (Transform point in _points)
            {
                SpawnWave(_spawnAmount, _ennemiesTypes[0], point);
            }
            _spawnTime = _spawnCooldown;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        foreach (Transform point in _points)
        {
            Gizmos.DrawSphere(point.position, .5f);
        }
    }
}
