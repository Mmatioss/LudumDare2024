using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        HealthManager();
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
    }

    void HealthManager()
    {
        if (_currentHealth == 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}