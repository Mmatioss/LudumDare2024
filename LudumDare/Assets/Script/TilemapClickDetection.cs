using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapClickDetection : MonoBehaviour
{
 public bool IsHoverTile(Tilemap tilemap, Vector3Int cellPosition)
 {

            // Vérifie si la cellule contient une tuile
            if (tilemap.HasTile(cellPosition))
            {
                Debug.Log("Tuile sur cette position.");
                return true;
            }
            else
            {
                Debug.Log("Aucune tuile sur cette position.");
                return false;
            }
 }

}