using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject _bullet;

    [SerializeField] private float _reloadTime;
    private float _firstReloadTime;
    private bool _isReload;

    private void Awake()
    {
        _firstReloadTime = _reloadTime;
    }

    private void Update()
    {
        if (_reloadTime > 0)
        {
            _reloadTime -= Time.deltaTime;
        }
        else
        {
            _isReload = true;
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_isReload)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
            _reloadTime = _firstReloadTime;
            _isReload = false;
        }

    }
}
