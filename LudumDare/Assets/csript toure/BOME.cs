using UnityEngine;

public class Boum : MonoBehaviour
{
    public float speed = 10f; // Vitesse de la balle
    public int damage = 1; // Dégâts infligés à l'ennemi
    public float lifetime = 2f; // Durée de vie de la balle avant destruction
    public GameObject explosionEffect; // Référence à l'effet d'explosion (à définir dans l'inspecteur)

    private Transform targetEnemy; // Référence vers l'ennemi à suivre
    private Vector2 direction; // Direction de la balle

    void Start()
    {
        // Trouver l'ennemi le plus proche
        targetEnemy = FindClosestEnemy();

        if (targetEnemy != null)
        {
            // Calcule la direction vers l'ennemi
            direction = (targetEnemy.position - transform.position).normalized;
        }
        else
        {
            // Si aucun ennemi n'est trouvé, détruire la balle immédiatement
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (targetEnemy != null)
        {
            // Calcule la nouvelle direction à chaque frame pour suivre l'ennemi
            direction = (targetEnemy.position - transform.position).normalized;

            // Déplace la balle vers l'ennemi
            transform.Translate(direction * speed * Time.deltaTime);
        }

        // Réduire la durée de vie de la balle
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si la balle touche un ennemi
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Applique des dégâts à l'ennemi
            var enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Détruire la balle après le tir
            DestroyProjectile();
        }
    }

    // Fonction pour trouver l'ennemi le plus proche
    private Transform FindClosestEnemy()
    {
        EnemyBehaviour[] enemies = FindObjectsOfType<EnemyBehaviour>();
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (EnemyBehaviour enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }

    // Méthode pour détruire le projectile et créer un effet à la position de l'impact
    private void DestroyProjectile()
    {
        // Si un effet d'explosion est assigné dans l'inspecteur, on l'instancie à la position du projectile
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Détruire le projectile
        Destroy(gameObject);
    }
}
