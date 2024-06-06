using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    [ContextMenu("11")]
    private void Spawn()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

        GameObject newEnemy = Instantiate(_enemy);

        newEnemy.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
    }
}
