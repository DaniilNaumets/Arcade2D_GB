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

    protected override void CheckCollisions()
    {
        Collider2D[] enemyes = Physics2D.OverlapCircleAll(transform.position, _collisionRadius, _characterLayer);
        foreach (Collider2D collision in enemyes)
        {
            if (collision.gameObject.GetComponent<HP>())
            {
                collision.gameObject.GetComponent<HP>().Attacked(_damage);
                    Destroy(gameObject);
            }
            else if (collision.gameObject.GetComponent<BulletB>() && collision.gameObject != this.gameObject)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
    protected override void Move()
    {
        if (_target != null)
        {
            CheckCollisions();
            Vector2 direction = (_target.transform.position - transform.position).normalized;
            Vector2 move = direction * _speed * Time.deltaTime;
            transform.Translate(move);
        }
    }

}
