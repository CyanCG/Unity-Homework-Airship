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
    }

    private void Start()
    {
        inputActions.Hero.Move.performed += OnMove;
        inputActions.Hero.Move.canceled += OnMove;
        inputActions.Hero.Fire.performed += OnFire;
        inputActions.Hero.Fire.canceled += OnFire;

        #region for test
        inputActions.Test.Die.performed += (c) => WorldEvents.Instance.RaiseDead();
        inputActions.Test.AddScore.performed += (c) =>
            WorldEvents.Instance.RaiseChangeScore(WorldState.Instance.Score + 1);
        inputActions.Test.Hurt.performed += (c) =>
            WorldEvents.Instance.RaiseChangeHealth(WorldState.Instance.Health - 25);
        #endregion
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
