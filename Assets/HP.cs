using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        if (GetComponent<PlayerMovement>())
        {
            UnityEvents.UpdateUIHealthBar.Invoke(_currentHealth, _maxHealth);
            Debug.Log(_maxHealth);
        }
    }
    private void Death()
    {
        if(_currentHealth <= 0)
        {
            if(GetComponent<Enemy>() != null)
            UnityEvents.OnAddScorePoints.Invoke(GetComponent<Enemy>().GetScorePoints());
            Destroy(gameObject);
        }
    }

    public void Attacked(int damage)
    {
        _currentHealth -= damage;
        Death();
        if (GetComponent<PlayerMovement>())
            UnityEvents.UpdateUIHealthBar.Invoke(_currentHealth, _maxHealth);

    }

    public float GetCurrentHP() => _currentHealth;
}
