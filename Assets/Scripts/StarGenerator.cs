using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private GameObject _starPrefab;

    private void Awake()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);

        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

        for (int i = 0; i < _count; i++)
        {
            GameObject _newStar = Instantiate(_starPrefab);
            _newStar.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            _newStar.transform.parent = transform;
        }
    }
}
