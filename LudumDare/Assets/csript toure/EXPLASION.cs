using System.Collections;
using UnityEngine;

public class ZoneDeDégâts : MonoBehaviour
{
    public float duréeZone = 5f; // Temps pendant lequel la zone reste active
    public float rayonZone = 3f; // Rayon de la zone
    public int dégâts = 10; // Dégâts infligés aux ennemis
    

    private void Start()
    {
        // Commence à détruire la zone après un certain temps
        Destroy(gameObject, duréeZone); 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("dlsd");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            var enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                 Debug.Log("k:smd");
                enemy.TakeDamage(dégâts);
                Debug.Log("dmsùf");
                Debug.Log(dégâts);
            }

            
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Optionnel: Applique des dégâts continus si nécessaire
        // Physics2D.OverlapCircleAll ou autre logique pour des dégâts continus
    }

   
}