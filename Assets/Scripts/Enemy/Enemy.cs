using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public static event Action OnEnemyDestroyed;

    [SerializeField] protected Animator _animator;

    [SerializeField] protected float _speed;
    [SerializeField] protected float _minSpeed;
    [SerializeField] protected float _maxSpeed;

    [SerializeField] protected float _xValueOne;
    [SerializeField] protected float _xValueTwo;

    protected bool _isStop;

    [SerializeField] protected float _givenScorePoints;

    protected float _stopPositionX;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _speed = UnityEngine.Random.Range(_minSpeed, +_maxSpeed);
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
        _stopPositionX = UnityEngine.Random.Range(-3, max.x - 2);
    }

    public abstract void Move();

    public float GetScorePoints() => _givenScorePoints;

    private void OnDestroy()
    {
        if (OnEnemyDestroyed != null)
            OnEnemyDestroyed.Invoke();
    }
}
