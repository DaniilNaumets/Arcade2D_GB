using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private AudioSource _audioShooting;
    [SerializeField] private AudioSource _audioShootingE;

    [SerializeField] private InputControls _inputControls;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _specBullet;

    [SerializeField] private float _specAttackReloadTime;
    [SerializeField] private float _minReloadTime;
    [SerializeField] private float _maxReloadTime;

    private NewControls _controls;

    private float _reloadTime;
    private float _reloadTimeE;

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
            _audioShooting.Play();
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
            _audioShootingE.Play();
        }
    }

    private void OnDestroy()
    {
        _controls.Spaceship.Shooting.performed -= context => Shoot();
        _controls.Spaceship.SpecialShooting.performed -= context => SpecShoot();
    }

    public void SpeedBulletUp(float value) => _bullet.GetComponent<Bullet>().SpeedUp(value);
}
