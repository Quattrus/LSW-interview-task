using UnityEngine;


public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }


    private PlayerInput playerInput;
    private PlayerInput.MovementActions movement;
    private PlayerScript playerScript;

    public PlayerInput.MovementActions Movement { get { return movement; } }

    private void Awake()
    {
        Instance = this;
        playerInput = new PlayerInput();
        movement = new PlayerInput().Movement;
        playerScript = GetComponent<PlayerScript>();
        movement.Interact.performed += ctx => playerScript.Interact();
        movement.Inventory.performed += ctx => playerScript.CheckInventory();
        movement.QuitGame.performed += ctx => playerScript.EscapeGame();
    }


    private void Update()
    {
        playerScript.ProcessMove(movement.PlayerMovement.ReadValue<Vector2>());
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
