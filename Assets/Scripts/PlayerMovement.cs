using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _direction;

    private NewControls _controls;

    private void Awake()
    {
       _controls = new NewControls();

        _controls.Spaceship.Move.performed += OnMove;
        _controls.Spaceship.Move.canceled += OnMove;
    }

    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();

    private void Update()
    {
        Move(_direction);
    }

    public void OnMove(InputAction.CallbackContext context) => _direction = context.ReadValue<Vector2>();
    private void Move(Vector2 vector)
    {
        Vector2 move = new Vector2(-vector.x, -vector.y) * _speed * Time.deltaTime;
        transform.Translate(move);
    }
}
