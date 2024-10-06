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
    private bool isTileAlreadyOccupied = false;

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
        Debug.Log("Mouse up");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger enter"+ other);
        if (other.gameObject.tag == "ColliderOfTurrelPlacement")
        {
            isTileAlreadyOccupied = true;
            Debug.Log("Tile already occupied");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ColliderOfTurrelPlacement")
        {
            isTileAlreadyOccupied = false;
            Debug.Log("Tile not occupied");
        }
    }
}
