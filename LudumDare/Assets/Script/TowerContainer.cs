using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TowerContainer : MonoBehaviour
{
    public GameObject towerPrefab;
    private bool isMouseHover = false;
    [SerializeField] private TowerPlacement towerPlacement;


    void Update()
    {
        if (isMouseHover)
        {
            if (Input.GetMouseButtonDown(0))
            {
                towerPlacement.towerToBuild = towerPrefab;
                towerPlacement.towerContainerInGame.GetComponent<SpriteRenderer>().sprite = towerPlacement.towerToBuild.GetComponent<SpriteRenderer>().sprite;
                //Debug.Log("Mouse down");
            }
        }
    }

    public void OnPointerEnter()
    {
        //Debug.Log("Mouse enter");
        isMouseHover = true;
    }

    public void OnPointerExit()
    {
        //Debug.Log("Mouse exit");
        isMouseHover = false;
    }
}
