using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetSetter : MonoBehaviour
{
    private AIDestinationSetter destination;
    private Transform _target;

    void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        _target = GameObject.FindGameObjectWithTag("LevelEnd").gameObject.transform;
        destination.target = _target;
    }
}
