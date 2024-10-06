using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Vitesse de la balle
    public int damage = 1; // D�g�ts inflig�s � l'ennemi
    public float lifetime = 2f;

    private Vector2 direction;

    void Update()
    {
        // D�place la balle vers l'ennemi
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        lifetime -= Time.deltaTime;
        if(lifetime < 0 )
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // V�rifie si la balle touche un ennemi
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Applique des d�g�ts � l'ennemi
            collision.gameObject.SendMessage("TakeDamage", damage);
            // D�truire la balle apr�s le tir
            Destroy(gameObject);
        }
    }
}