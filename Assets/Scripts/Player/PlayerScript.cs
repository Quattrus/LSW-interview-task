using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] float playerSpeed = 4f;
    public GameObject clothes;
    private Animator animator;




    private void Awake()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
    }


    public void ProcessMove(Vector2 input)
    {
        Vector2 move = new Vector2(input.x, input.y);
        Vector2 animMove = new Vector2(input.x, input.y);
        if(animMove.y < 0 && animMove.x < 0)
        {
            animMove.x = 0;
            animMove.y = -1;
        }
        else if(animMove.y > 0 && animMove.x > 0)
        {
            animMove.x = 0;
            animMove.y = 1;
        }
        clothes.GetComponent<ClothesScript>().ClothesAnimation(animMove);
        animator.SetInteger("VelocityY", Mathf.FloorToInt(animMove.y));
        animator.SetInteger("VelocityX", Mathf.FloorToInt(animMove.x));
        characterController.Move(move * Time.deltaTime * playerSpeed);
    }
}
