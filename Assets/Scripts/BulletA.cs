using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletA : Bullet
{
    [SerializeField] private Direction _direction;
    private Vector2 _bulletDirection;
    enum Direction
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

    protected override void Move()
    {
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
