using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class EnemyA : Enemy
{
    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (!_isStop)
        {
            Vector2 move = Vector2.up * -_speed * Time.deltaTime;

            transform.Translate(move);

            Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
            Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

            if (transform.position.x < _stopPositionX)
            {
                _isStop = true;
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
}
