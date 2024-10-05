using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapClickDetection : MonoBehaviour
{
    public Tilemap tilemap;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clique gauche de la souris
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log("Position de la souris: "+mouseWorldPos);
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
            cellPosition.z = 0;
            // Debug.Log("Position de la cellule: " + cellPosition);

            // Vérifie si la cellule contient une tuile
            if (tilemap.HasTile(cellPosition))
            {
                Debug.Log("Tuile sur cette position.");
            }
            else
            {
                Debug.Log("Aucune tuile sur cette position.");
            }
        }
    }
}