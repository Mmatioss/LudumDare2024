using UnityEngine;

public class BOME  : MonoBehaviour
{
    public float speed = 10f; // Vitesse de la balle
    public int damage = 1; // Dégâts infligés à l'ennemi
    public float explosionRadius = 5f; // Rayon de l'explosion (dégâts de zone)
    public int explosionDamage = 1; // Dégâts de l'explosion dans la zone

    private Vector2 direction;

    void Start()
    {
        // Calcule la direction vers l'ennemi
        direction = (FindObjectOfType<TowerShoot>().targetEnemy.position - transform.position).normalized;
    }

    void Update()
    {
        // Déplace la balle vers l'ennemi
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifie si la balle touche un ennemi
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Applique des dégâts à l'ennemi touché
            var enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Applique des dégâts de zone autour de l'ennemi
            ApplyAreaDamage(collision.transform.position);

            // Détruire la balle après le tir
            Destroy(gameObject);
        }
    }

    // Méthode pour appliquer des dégâts de zone
    void ApplyAreaDamage(Vector2 explosionCenter)
    {
        // Trouve tous les objets avec le tag "Enemy" dans un rayon autour du point d'explosion
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(explosionCenter, explosionRadius);

        // Applique des dégâts à tous les ennemis dans le rayon
        foreach (var enemyCollider in enemiesInRange)
        {
            if (enemyCollider.CompareTag("Enemy"))
            {
                var enemy = enemyCollider.GetComponent<EnemyBehaviour>();
                if (enemy != null)
                {
                    enemy.TakeDamage(explosionDamage);
                }
            }
        }
    }
}