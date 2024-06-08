using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private InputControls _inputControls;
    private NewControls _controls;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _specBullet;

    private float _reloadTime;
    private float _reloadTimeE;
    [SerializeField] private float _specAttackReloadTime;

    [SerializeField] private float _minReloadTime;
    [SerializeField] private float _maxReloadTime;

    private bool _isReload;
    private bool _isSpecReload;

    private void Awake()
    {
        _reloadTime = Random.Range(_minReloadTime, _maxReloadTime);
        _reloadTimeE = _specAttackReloadTime;
    }
    private void Start()
    {
        _controls = _inputControls.GetControls();
        UnityEvents.UpdateSpecAttackReloadBar.Invoke(_specAttackReloadTime);
        _controls.Spaceship.Shooting.performed += context => Shoot();
        _controls.Spaceship.SpecialShooting.performed += context => SpecShoot();
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

        if (_reloadTimeE > 0)
        {
            _reloadTimeE -= Time.deltaTime;
        }
        else
        {
            _isSpecReload = true;
        }
    }

    private void Shoot()
    {
        if (_isReload)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
            _reloadTime = Random.Range(_minReloadTime, _maxReloadTime);
            _isReload = false;
        }
        
    }

    private void SpecShoot()
    {
        if (_isSpecReload)
        {
            Instantiate(_specBullet, new Vector3(transform.position.x + 1, transform.position.y), transform.rotation);
            _reloadTimeE = _specAttackReloadTime;
            _isSpecReload = false;
            UnityEvents.UpdateSpecAttackReloadBar.Invoke(_specAttackReloadTime);
        }
    }

    private void OnDestroy()
    {
        _controls.Spaceship.Shooting.performed -= context => Shoot();
        _controls.Spaceship.SpecialShooting.performed -= context => SpecShoot();
    }
}
