using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
    private void Death()
    {
        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Attacked(int damage)
    {
        _currentHealth -= damage;
        Debug.Log("Ohh " + this.gameObject);
        Death();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(1);
    }
}
