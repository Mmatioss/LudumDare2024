using System.Collections;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public float detectionRadius = 5f; // Portée de détection de l'ennemi
    public float timeBetweenShots = 1f; // Délai entre chaque tir
    public GameObject bulletPrefab; // Préfabriqué de la balle
    public Transform shootPoint; // Point de tir de la tour

    public Transform targetEnemy; // L'ennemi ciblé
    private float nextShotTime = 0f; // Temps pour le prochain tir

    void Update()
    {
        // Détecter l'ennemi
        DetectEnemy();

        // Si un ennemi est trouvé et que le temps est écoulé, tirer
        if (targetEnemy != null && Time.time >= nextShotTime)
        {
            Shoot();
        }
    }

    void DetectEnemy()
    {
        // Cherche l'ennemi à proximité
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        // Parcourt tous les objets détectés pour trouver un ennemi
        targetEnemy = null;
        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Enemy")) // Assurez-vous que vos ennemis ont le tag "Enemy"
            {
                targetEnemy = col.transform;
                break; // Cibler le premier ennemi détecté
            }
        }
    }

    void Shoot()
    {
        // Crée une balle et la tire vers l'ennemi
        Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // Réinitialiser le timer pour le prochain tir
        nextShotTime = Time.time + timeBetweenShots;
    }

    // Affiche un rayon de détection dans l'éditeur pour déboguer
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}