using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private GameManager _gm;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
    private void Start()
    {
        if (GetComponent<PlayerMovement>())
        {
            UnityEvents.UpdateUIHealthBar.Invoke(_currentHealth, _maxHealth);
        }
    }
    private void Death()
    {
        if(_currentHealth <= 0)
        {
            if(GetComponent<Enemy>() != null)
            UnityEvents.OnAddScorePoints.Invoke(GetComponent<Enemy>().GetScorePoints());
            if (GetComponent<PlayerMovement>())
            {
                _gm.LooseGame();
            }
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

    public void UpHP(float value)
    {
        _maxHealth += _maxHealth * value;
        _currentHealth = _maxHealth;
        UnityEvents.UpdateUIHealthBar.Invoke(_currentHealth, _maxHealth);
    }
}
