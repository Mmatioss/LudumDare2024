using System.Collections;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int Damage = 2;
    public float BlastRadius = 1.5f;
    public GameObject BlastParticles;

    private void Start()
    {
        //Instantiate(BlastParticles, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, BlastRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {
                collider.SendMessage("TakeDamage", Damage);
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, BlastRadius);
    }
}