using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damageAmount = 10; // Dégâts infligés à l'ennemi
    public string enemyTag = "Enemy"; // Le tag des ennemis

    // Cette fonction est appelée quand un autre objet entre dans la zone de trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si l'objet entrant dans la zone est un ennemi
        if (other.CompareTag(enemyTag))
        {
            // Essaye de récupérer le script de l'ennemi
            EnemyBehaviour enemyHealth = other.GetComponent<EnemyBehaviour>();
            if (enemyHealth != null)
            {
                // Inflige des dégâts à l'ennemi
                enemyHealth.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
            Debug.Log("je suis detrui");

                }
    }
}