using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

#pragma warning disable IDE0044

public class WaveManager : MonoBehaviour
{
    [Header("Spawn Points")]
    [SerializeField] private Transform[] _points = new Transform[3];

    [Header("Parameters")]
    [SerializeField, Range(0f, 1f)] private float _spawnCooldown;
    [SerializeField, Range(1, 50)] private int _waveCooldown;

    [Header("Mobs")]
    [SerializeField] private GameObject[] mobs = new GameObject[4];

    [Header("Wave 1")]
    [SerializeField] private int[] count1 = new int[4];

    [Header("Wave 2")]
    [SerializeField] private int[] count2 = new int[4];

    [Header("Wave 3")]
    [SerializeField] private int[] count3 = new int[4];

    [Header("Wave 4")]
    [SerializeField] private int[] count4 = new int[4];

    private float _timeBetweenWaves;

    void Start()
    {
        _timeBetweenWaves = _waveCooldown;
        StartCoroutine(SpawnWave(count1, _points[0]));
        StartCoroutine(SpawnWave(count1, _points[1]));
        StartCoroutine(SpawnWave(count1, _points[2]));
    }

    void Update()
    {
        UpdateSpawner();
    }

    IEnumerator SpawnEnemyType(GameObject mob, Transform point, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(mob, point.position, point.rotation);
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    IEnumerator SpawnWave(int[] count, Transform point)
    {
        for (int i = 0; i < 4; i++)
        {
            StartCoroutine(SpawnEnemyType(mobs[i], point, count[i]));
            yield return new WaitForSeconds(_spawnCooldown / 4f);
        }
    }

    private int currentWave = 2;
    void UpdateSpawner()
    {
        _timeBetweenWaves -= Time.deltaTime;
        if (_timeBetweenWaves < 0)
        {
            Debug.Log("spawning");

            foreach (Transform point in _points)
            {
                switch (currentWave)
                {
                    case 2:
                        StartCoroutine(SpawnWave(count2, point));
                        break;

                    case 3:
                        StartCoroutine(SpawnWave(count3, point));
                        break;

                    case 4:
                        StartCoroutine(SpawnWave(count4, point));
                        break;

                    default:
                        break;
                }
            }

            _timeBetweenWaves = _waveCooldown;
            currentWave++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.cyan;
        foreach (Transform point in _points)
        {
            Gizmos.DrawSphere(point.position, .5f);
        }
    }
}
