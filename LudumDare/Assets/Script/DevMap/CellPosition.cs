using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CellPosition : MonoBehaviour
{

public Vector3Int PositionCell(Tilemap tilemap)
{
    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    // Debug.Log("Position de la souris: "+mouseWorldPos);
    Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
    
    cellPosition.z = 0;
    cellPosition.y += 1;
    // Debug.Log("Position de la cellule: " + cellPosition);
    return cellPosition;
}

public Vector3Int PositionCell2(Tilemap tilemap)
{
    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    // Debug.Log("Position de la souris: "+mouseWorldPos);
    Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
    cellPosition.z = 0;
    // Debug.Log("Position de la cellule: " + cellPosition);
    return cellPosition;
}

}
