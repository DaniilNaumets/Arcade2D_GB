using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _direction;

    [SerializeField] private InputControls _inputControls;
    private NewControls _controls;
    

    private void Start()
    {
        _controls = _inputControls.GetControls();

        _controls.Spaceship.Move.performed += OnMove;
        _controls.Spaceship.Move.canceled += OnMove;
    }


    private void Update()
    {
        Move(_direction);
    }

    public void OnMove(InputAction.CallbackContext context) => _direction = context.ReadValue<Vector2>();
    private void Move(Vector2 vector)
    {
        Vector2 move = new Vector2(vector.y, -vector.x) * _speed * Time.deltaTime;
        transform.Translate(move);
    }
}
