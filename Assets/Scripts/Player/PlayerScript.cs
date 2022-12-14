using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] float playerSpeed = 4f;
    [SerializeField] GameObject clothes;
    [SerializeField] GameObject pants;
    [SerializeField] GameObject hair;
    [SerializeField] TextMeshProUGUI interactText;
    [SerializeField] TextMeshProUGUI credit;
    [SerializeField] GameObject inventoryPanel;
    private bool inventoryActive = false;
    private Animator animator;
    private bool canInteract, merchantInteract, buyingState = false;
    private int availableCredit = 300;
    public static PlayerScript Instance { get; private set; }
    public int AvailableCredit { get { return availableCredit; } set { availableCredit = value; } }
    public bool BuyingState { get { return buyingState; } set { buyingState = value; } }
    public TextMeshProUGUI InteractText { get { return interactText; } set { interactText = value; } }



    private void Awake()
    {
        Instance = this;
        characterController = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        inventoryPanel.SetActive(false);
        
    }

    private void Update()
    {
        credit.text = availableCredit.ToString();
    }


    public void ProcessMove(Vector2 input)
    {
        if (!buyingState)
        {
            Vector2 move = new Vector2(input.x, input.y);
            Vector2 animMove = new Vector2(input.x, input.y);
            if (animMove.y < 0 && animMove.x < 0)
            {
                animMove.x = 0;
                animMove.y = -1;
            }
            else if (animMove.y > 0 && animMove.x > 0)
            {
                animMove.x = 0;
                animMove.y = 1;
            }
            clothes.GetComponent<ClothesScript>().ClothesAnimation(animMove);
            pants.GetComponent<ClothesScript>().ClothesAnimation(animMove);
            hair.GetComponent<ClothesScript>().ClothesAnimation(animMove);
            animator.SetInteger("VelocityY", Mathf.FloorToInt(animMove.y));
            animator.SetInteger("VelocityX", Mathf.FloorToInt(animMove.x));
            characterController.Move(move * Time.deltaTime * playerSpeed);
        }
    }


    public void Interact()
    {
        if (canInteract)
        {
            if (merchantInteract)
            {
                Merchant.Instance.DialogueState = true;
            }
        }
    }

    public void CheckInventory()
    {
        if (!inventoryActive)
        {
            inventoryPanel.SetActive(true);
            inventoryActive = true;
        }
        else
        {
            inventoryPanel.SetActive(false);
            inventoryActive = false;
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Merchant"))
        {
            canInteract = true;
            interactText.text = "Press E To Talk To Merchant";
            merchantInteract = true;
        }    
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Merchant"))
        {
            canInteract = false;
            interactText.text = string.Empty;
            merchantInteract = false;
        }
    }

    public void EscapeGame()
    {
        Application.Quit();
    }
}
