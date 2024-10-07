using System.Collections;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public float detectionRadius = 5f; // Port�e de d�tection de l'ennemi
    public float timeBetweenShots = 1f; // D�lai entre chaque tir
    public GameObject bulletPrefab; // Pr�fabriqu� de la balle
    public Transform shootPoint; // Point de tir de la tour

    private Transform targetEnemy; // L'ennemi cibl�
    private float nextShotTime = 0f; // Temps pour le prochain tir

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // D�tecter l'ennemi
        DetectEnemy();

        // Si un ennemi est trouv� et que le temps est �coul�, tirer
        if (targetEnemy != null && Time.time >= nextShotTime && (_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "AcidAlliedFiring" ||
                                                                 _animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "RockAlliedAttack"
                                                                 ))
        {
            Shoot();
        }

        _animator.SetBool("Attacking", targetEnemy != null && GameObject.FindGameObjectWithTag("Enemy") != null);
    }

    void DetectEnemy()
    {
        // Cherche l'ennemi � proximit�
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        // Parcourt tous les objets d�tect�s pour trouver un ennemi
        targetEnemy = null;
        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Enemy")) // Assurez-vous que vos ennemis ont le tag "Enemy"
            {
                targetEnemy = col.transform;
                break; // Cibler le premier ennemi d�tect�
            }
        }
    }

    void Shoot()
    {
        // Cr�e une balle et la tire vers l'ennemi
        if (targetEnemy.transform.position.y > transform.position.y) 
        {
            Instantiate(
            bulletPrefab,
            shootPoint.position,
            Quaternion.Euler(0, 0, Vector3.Angle(Vector3.right, new Vector3(
                targetEnemy.position.x - transform.position.x,
                targetEnemy.position.y - transform.position.y,
                0)
            )));
        }
        else
        {
            Instantiate(
            bulletPrefab,
            shootPoint.position,
            Quaternion.Euler(0, 0, -Vector3.Angle(Vector3.right, new Vector3(
                targetEnemy.position.x - transform.position.x,
                targetEnemy.position.y - transform.position.y,
                0)
            )));
        }

        // R�initialiser le timer pour le prochain tir
        nextShotTime = Time.time + timeBetweenShots;
    }

    // Affiche un rayon de d�tection dans l'�diteur pour d�boguer
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}