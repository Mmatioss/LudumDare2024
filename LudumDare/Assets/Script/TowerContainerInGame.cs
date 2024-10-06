using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class TowerContainerInGame : MonoBehaviour
{
    public TowerPlacement towerPlacement;
    public TilemapClickDetection tilemapClickDetection;
    private Vector3Int theposition;
    private Vector3Int theposition2;
    [NonSerialized] public bool isTileAlreadyOccupied = false;

    void OnMouseUp()
    {
        if (towerPlacement.towerToBuild != null)
        {
            theposition = towerPlacement.cellPosition.PositionCell(towerPlacement.tilemap);
            theposition2 = towerPlacement.cellPosition.PositionCell2(towerPlacement.tilemap);
            Debug.Log(theposition);
            if (tilemapClickDetection.IsHoverTile(towerPlacement.tilemap, theposition2) && !isTileAlreadyOccupied)
            {
                Instantiate(towerPlacement.towerToBuild, new UnityEngine.Vector3(theposition.x, theposition.y-0.2f, 0), UnityEngine.Quaternion.identity);
                Debug.Log("Tower built");
            }
        }
        towerPlacement.towerToBuild = null;
        towerPlacement.towerContainerInGame.GetComponent<SpriteRenderer>().sprite = null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.tag == "ColliderOfTurrelPlacement")
        {
            isTileAlreadyOccupied = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collision exit");
        if (collision.gameObject.tag == "ColliderOfTurrelPlacement")
        {
            isTileAlreadyOccupied = false;
        }
    }
}
