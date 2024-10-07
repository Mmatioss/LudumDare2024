using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private SpriteRenderer _skin;
    private bool _isFlipped;

    [Header("Parameters")]
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _moneyLoot;
    private int _currentHealth;
    GameObject _coinpurse;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _skin = GetComponent<SpriteRenderer>();
        _coinpurse = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        FlipManager();
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            _coinpurse.SendMessage("AddMoney", _moneyLoot);
            Destroy(transform.parent.gameObject);
        }
    }

    void FlipManager()
    {
        if(_isFlipped)
        {
            _skin.flipX = true;
        }
        else
        {
            _skin.flipX = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _isFlipped = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _isFlipped = false;
        }
    }
}