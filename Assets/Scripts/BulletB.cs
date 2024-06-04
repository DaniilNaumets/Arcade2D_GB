using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletB : Bullet
{
    private GameObject _target;

    private void Awake()
    {
        _target = FindAnyObjectByType<PlayerMovement>().gameObject;
    }
    private void Update()
    {
        Move();
        LifeTime();
    }

    protected override void Move()
    {
        CheckCollisions();
        Vector2 direction = (transform.position - _target.transform.position).normalized;
        Vector2 move = direction * _speed * Time.deltaTime;
        transform.Translate(move);
    }

}
