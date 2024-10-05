using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private GameObject tower;
    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        GameObject towerToBuild = buildManager.instance.GetTowerToBuild();
        tower = (GameObject)Instantiate(towerToBuild,new Vector3(transform.position.x,transform.position.y,transform.position.z-0.5f), transform.rotation);
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
