using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class EnemyA : Enemy
{
    private bool _isStop;
    private float _stayPositionY;
    public override void Move()
    {
        if (!_isStop)
        {
            Vector2 move = Vector2.up * -_speed * Time.deltaTime;

            transform.Translate(move);

            Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
            Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

            if (transform.position.x < min.x + Random.Range(11, 16))
            {
                _isStop = true;
                _stayPositionY = transform.position.y;
            }
        }
        else
        {
            Stay();
        }
    }

    private void Stay()
    {
        if (_isStop)
        {
            Vector2 newPosition = transform.position;
            newPosition.y += Random.Range(-2f, 2f) * _speed * Time.deltaTime;
            transform.position = newPosition;
        }
    }

    private void Update()
    {
        Move();
    }
}
