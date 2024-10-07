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
        towerContainerInGame.transform.position = new Vector3(theposition.x*2 +0.5f, theposition.y*2, 0);
    }

    void Update()
    {
        TowerFollowMouse();
    }

}
