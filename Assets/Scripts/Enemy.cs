using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Animator _animator;

    [SerializeField] protected float _speed;
    [SerializeField] protected float _minSpeed;
    [SerializeField] protected float _maxSpeed;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _speed = Random.Range(_minSpeed,+_maxSpeed);
    }

    public abstract void Move();
}
