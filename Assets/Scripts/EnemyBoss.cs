using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class EnemyBoss : Enemy
{
    
    public override void Move()
    {
        if (!_isStop)
        {
            Vector2 move = Vector2.up * -_speed * Time.deltaTime;

            transform.Translate(move);

            Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
            Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

            if (transform.position.x < 9f)
            {
                _isStop = true;
            }
        }
        else
        {
            _isStop = true;
        }
    }


    private void Update()
    {
        Move();
    }
}
