using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControls : MonoBehaviour
{
    private NewControls _controls;

    private void Awake() => _controls = new NewControls();

    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();
    public NewControls GetControls() =>  _controls; 
}
