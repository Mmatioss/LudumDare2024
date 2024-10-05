using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TowerContainer : MonoBehaviour
{
    public GameObject towerPrefab;

    void Start()
    {
        GetComponent<Image>().sprite = towerPrefab.GetComponent<SpriteRenderer>().sprite;
    }
}
