using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private GameObject _lifebar;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _lifebar = GameObject.FindGameObjectWithTag("Lifebar");
        
        for (int i = _lifebar.transform.childCount - 1; i >= _maxHealth ; i--)
        {
            _lifebar.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        if (_currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void DamageHealth()
    {
        _currentHealth--;
        _lifebar.transform.GetChild(_currentHealth).gameObject.SetActive(false);
    }

    public void Heal()
    {
        _currentHealth++;
        _lifebar.transform.GetChild(_currentHealth - 1).gameObject.SetActive(true);
    }

    void GameOver()
    {
        GameObject.Find("Canvas").BroadcastMessage("GameOver");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.transform.parent.gameObject);
            DamageHealth();
        }
    }
}
