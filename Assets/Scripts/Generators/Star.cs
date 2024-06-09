using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Sprite[] _sprites;

    private void Start()
    {
        ChangeSpeed();
        ChangeSprite();
    }
    private void Update()
    {
        Vector2 move = Vector2.right * -_speed * Time.deltaTime;

        transform.Translate(move);

        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

        if(transform.position.x < min.x)
        {
            transform.position = new Vector2(max.x, Random.Range(min.y,max.y));
            ChangeSpeed();
            ChangeSprite();
        }
    }

    private void ChangeSpeed()
    {
        _speed = Random.Range(1f, 5);
    }

    private void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = _sprites[Random.Range(0, _sprites.Length)];
    }
}
