using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mono.Cecil.Cil;

public class PlayerScript : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] float playerSpeed = 4f;
    [SerializeField] GameObject clothes;
    [SerializeField] GameObject pants;
    [SerializeField] GameObject hair;
    [SerializeField] TextMeshProUGUI interactText;
    [SerializeField] TextMeshProUGUI credit;
    [SerializeField] GameObject buyingPanel;
    [SerializeField] Button buyingPanelExit;
    private Animator animator;
    private bool canInteract, merchantInteract, genericInteract, buyingState = false;
    private int availableCredit = 300;
    public static PlayerScript Instance { get; private set; }



    private void Awake()
    {
        Instance = this;
        characterController = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        buyingPanel.SetActive(false);
        
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
                buyingPanel.SetActive(true);
                buyingState = true;
            }
            else if (genericInteract)
            {
                Debug.Log("Generic Interaction");
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            canInteract = true;
            interactText.text = "Interact";
            genericInteract = true;
            
        }

        if (other.gameObject.CompareTag("Merchant"))
        {
            canInteract = true;
            interactText.text = "Buy";
            merchantInteract = true;
        }
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            canInteract = false;
            interactText.text = string.Empty;
            genericInteract = false;
        }

        if (other.gameObject.CompareTag("Merchant"))
        {
            canInteract = false;
            interactText.text = string.Empty;
            merchantInteract = false;
        }
    }

    public void ExitBuyingState()
    {
        buyingState = false;
        buyingPanel.SetActive(false);
    }
}
