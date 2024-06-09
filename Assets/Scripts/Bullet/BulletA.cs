using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletA : Bullet
{
    [SerializeField] private Direction _direction;
    private Vector2 _bulletDirection;
    private enum Direction
    {
        Up, Down, Left, Right
    }

    private void Awake()
    {
        SetDirection();
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
                if(!_isImmortal)
                Destroy(gameObject);
                else
                {
                    if(Convert.ToInt32(collision.gameObject.GetComponent<HP>().GetCurrentHP()) > 0)
                    GetComponent<HP>().Attacked(Convert.ToInt32(collision.gameObject.GetComponent<HP>().GetCurrentHP()));
                }
            }
        }
    }

    protected override void Move()
    {
        CheckCollisions();
        Vector2 move = _bulletDirection * _speed * Time.deltaTime;
        transform.Translate(move);
    }

    private void SetDirection()
    {
        
        switch (_direction)
        {
            case Direction.Up:
                _bulletDirection = Vector2.up; break;
            case Direction.Left:
                _bulletDirection = Vector2.left; break;
            case Direction.Right:
                _bulletDirection = Vector2.right; break;
            case Direction.Down:
                _bulletDirection = Vector2.down; break;
            default: _bulletDirection = Vector2.right; break;
        }
    }


}
