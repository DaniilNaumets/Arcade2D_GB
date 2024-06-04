using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletC : Bullet
{
    private GameObject _target;
    private Vector2 _direction;

    private void Awake()
    {
        _target = FindAnyObjectByType<PlayerMovement>().gameObject;
        _direction = (transform.position - _target.transform.position).normalized;
    }
    private void Update()
    {
        Move();
        LifeTime();
    }

    protected override void Move()
    {
        
        Vector2 move = _direction * _speed * Time.deltaTime;
        transform.Translate(move);
    }

}
