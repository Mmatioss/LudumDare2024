using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Vitesse de la balle
    public int damage = 1; // Dégâts infligés à l'ennemi

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
            // Applique des dégâts à l'ennemi
            var enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            // Détruire la balle après le tir
            Destroy(gameObject);
        }
    }
}