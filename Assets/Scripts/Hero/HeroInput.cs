using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInput : MonoBehaviour
{
    public Vector2 Move { get; private set; }
    public bool Fire { get; private set; }

    private UserControls inputActions;

    private void Awake()
    {
        inputActions = new UserControls();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Hero.Move.performed += OnMove;
        inputActions.Hero.Move.canceled += OnMove;
        inputActions.Hero.Fire.performed += OnFire;
        inputActions.Hero.Fire.canceled += OnFire;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        Fire = context.ReadValueAsButton();
    }
}
