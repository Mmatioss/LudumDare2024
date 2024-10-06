using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

#pragma warning disable IDE0090
#pragma warning disable IDE0044
#pragma warning disable IDE0059

public class WaveManager : MonoBehaviour
{
    [Header("Spawn Points")]
    [SerializeField] private Transform[] _points = new Transform[3];

    [Header("Parameters")]
    [SerializeField, Range(.5f, 3f)] private float _spawnCooldown;
    [SerializeField, Range(1, 30)] private int _waveCooldown;

    [Header("Wave 1")]
    [SerializeField] private GameObject[] mobs1 = new GameObject[4];
    [SerializeField] private int[] count1 = new int[4];
    private Dictionary<GameObject, int> _wave1 = new Dictionary<GameObject, int>();

    [Header("Wave 2")]
    [SerializeField] private GameObject[] mobs2 = new GameObject[4];
    [SerializeField] private int[] count2 = new int[4];
    private Dictionary<GameObject, int> _wave2 = new Dictionary<GameObject, int>();

    [Header("Wave 3")]
    [SerializeField] private GameObject[] mobs3 = new GameObject[4];
    [SerializeField] private int[] count3 = new int[4];
    private Dictionary<GameObject, int> _wave3 = new Dictionary<GameObject, int>();

    [Header("Wave 4")]
    [SerializeField] private GameObject[] mobs4 = new GameObject[4];
    [SerializeField] private int[] count4 = new int[4];
    private Dictionary<GameObject, int> _wave4 = new Dictionary<GameObject, int>();

    private float _spawnTime;
    private float _timeBetweenWaves;

    void Start()
    {
        _spawnTime = _spawnCooldown;
        _timeBetweenWaves = _waveCooldown;

        for (int i = 0; i< 4; i++)
        {
            _wave1.Add(mobs1[i], count1[i]);
            _wave2.Add(mobs2[i], count2[i]);
            _wave3.Add(mobs3[i], count3[i]);
            _wave4.Add(mobs4[i], count4[i]);
        }
    }

    void Update()
    {
        UpdateSpawner();
    }

    void SpawnEnemyType(GameObject enemy, Transform point, int amount)
    {
        while (amount > 0)
        {
            _spawnTime -= Time.deltaTime;
            if (_spawnTime < 0)
            { 
                Instantiate(enemy, point.position, point.rotation);
                _spawnTime = _spawnCooldown;
            }
            amount--;
        }
    }

    void SpawnWave(Dictionary<GameObject, int> wave, Transform point)
    {
        foreach (GameObject mob in wave.Keys)
        {
            SpawnEnemyType(mob, point, wave[mob]);
        }
    }

    void UpdateSpawner()
    {
        int currentWave = 1;

        _timeBetweenWaves -= Time.deltaTime;
        if ((_timeBetweenWaves < 0 && currentWave < 5) || (currentWave == 1))
        {
            foreach (Transform point in _points)
            {
                switch (currentWave)
                {
                    case 1:
                        SpawnWave(_wave1, point);
                        break;

                    case 2:
                        SpawnWave(_wave2, point);
                        break;

                    case 3:
                        SpawnWave(_wave3, point);
                        break;

                    case 4:
                        SpawnWave(_wave4, point);
                        break;

                    default:
                        break;
                }
            }

            _timeBetweenWaves = _waveCooldown;

            currentWave += 1;
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
