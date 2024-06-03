using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private InputControls _inputControls;
    private NewControls _controls;

    [SerializeField] private GameObject _bullet;

    [SerializeField] private float _reloadTime;
    private float _firstReloadTime;
    private bool _isReload;

    private void Awake()
    {
        _firstReloadTime = _reloadTime;
    }
    private void Start()
    {
        _controls = _inputControls.GetControls();

        _controls.Spaceship.Shooting.performed += context => Shoot();
    }

    private void Update()
    {
        if(_reloadTime > 0)
        {
            _reloadTime -= Time.deltaTime;
        }
        else
        {
            _isReload = true;
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
