using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _lifeTime = 10f;

    [SerializeField] protected LayerMask _characterLayer;
    [SerializeField] protected float _collisionRadius = 0.1f;

    [SerializeField] protected bool _isImmortal;

    protected void LifeTime()
    {
        if(_lifeTime > 0)
        {
            _lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    protected abstract void Move();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HP>())
        {
            collision.gameObject.GetComponent<HP>().Attacked(_damage);
        }
    }

    protected virtual void CheckCollisions()
    {
        Collider2D[] enemyes = Physics2D.OverlapCircleAll(transform.position, _collisionRadius, _characterLayer);
        foreach(Collider2D collision in enemyes)
        {
            if(collision.gameObject.GetComponent<HP>())
            {
                collision.gameObject.GetComponent<HP>().Attacked(_damage);
                Destroy(gameObject);
            }
        }
    }
}
