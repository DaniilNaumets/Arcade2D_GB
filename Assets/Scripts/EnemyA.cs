using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    private bool _isStop;
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
            }
        }
    }

    private void Stay()
    {
        if (_isStop)
        {
            Vector2 move = Vector2.up * -_speed * Time.deltaTime;
        }
    }

    private void Update()
    {
        Move();
    }
}
