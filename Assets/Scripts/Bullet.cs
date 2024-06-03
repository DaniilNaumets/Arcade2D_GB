using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected float _lifeTime = 10f;

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
}
