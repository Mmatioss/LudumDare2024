using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public float lifetime = 2f; 

    private Transform targetEnemy; 
    private Vector2 direction; 

    void Start()
    {
        targetEnemy = FindClosestEnemy();

        if (targetEnemy != null)
        {
            direction = (targetEnemy.position - transform.position).normalized;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (targetEnemy != null)
        {
           
            direction = (targetEnemy.position - transform.position).normalized;

            
            transform.Translate(direction * speed * Time.deltaTime);
        }

        
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            var enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            
            Destroy(gameObject);
        }
    }

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
}