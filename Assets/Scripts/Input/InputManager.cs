using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    #region PlayerInputs
    private PlayerInput playerInput;
    private PlayerInput.MovementActions movement;
    private PlayerStateMachine playerStateMachine;
    #endregion

    public PlayerInput.MovementActions Movement { get { return movement; } }

    private void Awake()
    {
        Instance = this;
        playerInput = new PlayerInput();
        movement = new PlayerInput().Movement;
        playerStateMachine = GetComponent<PlayerStateMachine>();
    }


    private void Update()
    {
        playerStateMachine.ProcessMove(movement.PlayerMovement.ReadValue<Vector2>());
    }


    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
