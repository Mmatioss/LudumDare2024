using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Vitesse de la balle
    public int damage = 1; // D�g�ts inflig�s � l'ennemi

    private Vector2 direction;

    void Start()
    {
        // Calcule la direction vers l'ennemi
        direction = (FindObjectOfType<TowerShoot>().targetEnemy.position - transform.position).normalized;
    }

    void Update()
    {
        // D�place la balle vers l'ennemi
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // V�rifie si la balle touche un ennemi
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Applique des d�g�ts � l'ennemi
            var enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            // D�truire la balle apr�s le tir
            Destroy(gameObject);
        }
    }
}