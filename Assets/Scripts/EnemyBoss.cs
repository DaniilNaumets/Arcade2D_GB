using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class EnemyBoss : Enemy
{
    
    public override void Move()
    {
        Vector2 newPosition = transform.position;
        newPosition.y += Random.Range(-2f, 2f) * _speed * Time.deltaTime;
        transform.position = newPosition;
    }


    private void Update()
    {
        Move();
    }
}
