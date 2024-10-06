using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damageAmount = 10; // D�g�ts inflig�s � l'ennemi
    public string enemyTag = "Enemy"; // Le tag des ennemis

    // Cette fonction est appel�e quand un autre objet entre dans la zone de trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // V�rifie si l'objet entrant dans la zone est un ennemi
        if (other.CompareTag(enemyTag))
        {
            // Essaye de r�cup�rer le script de l'ennemi
            EnemyBehaviour enemyHealth = other.GetComponent<EnemyBehaviour>();
            if (enemyHealth != null)
            {
                // Inflige des d�g�ts � l'ennemi
                enemyHealth.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
            Debug.Log("je suis detrui");

                }
    }
}