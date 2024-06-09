using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private int _type;

    [SerializeField] private GameObject _bulletE;
    [SerializeField] private float _changeValue;
    private GameObject _player;
    [SerializeField] private LayerMask _playerLayer;

    [SerializeField] private AudioSource _audio;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void Update()
    {
        CheckCollision();
    }

    private void CheckCollision()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, 0.5f, _playerLayer);
        foreach (Collider2D collision in objects)
        {
            if (collision.gameObject.GetComponent<PlayerMovement>())
            {
                GiveBonus();
                Destroy(gameObject);
            }
        }
    }



    private void GiveBonus()
    {
        switch (_type)
        {
            case 0: UpMaxHp(_player.GetComponent<HP>()); break;
            case 1: UpProjectileSpeed(_player.GetComponentInChildren<PlayerShooting>()); break;
            case 2: KillAll(); break;
            case 3: UpSpeed(_player.GetComponent<PlayerMovement>()); break;
        }
        _audio.Play();
        
    }

    private void UpMaxHp(HP playerHP)
    {
        playerHP.UpHP(_changeValue);
    }

    private void UpSpeed(PlayerMovement playerMovement)
    {
        playerMovement.SpeedUp(_changeValue);
    }

    private void KillAll()
    {
        for (int i = -7; i < 7; i+= 2)
        {
            Instantiate(_bulletE, new Vector3(-10, i, 0), transform.rotation);
        }
    }

    private void UpProjectileSpeed(PlayerShooting playerShooting)
    {
        playerShooting.SpeedBulletUp(_changeValue);
    }
}
