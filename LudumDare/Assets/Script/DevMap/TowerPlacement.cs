using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerToBuild;
    public GameObject towerContainerInGame;
    public Tilemap tilemap;
    public CellPosition cellPosition;
    

    public void TowerFollowMouse()
    {
        Vector3Int theposition = cellPosition.PositionCell(tilemap);
        towerContainerInGame.transform.position = new Vector3(theposition.x, theposition.y-1.2f, 0);
    }

    void Update()
    {
        TowerFollowMouse();
    }

}
