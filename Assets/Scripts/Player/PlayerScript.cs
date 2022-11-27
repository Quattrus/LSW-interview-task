using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] float playerSpeed = 4f;
    private Animator animator;



    private void Awake()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
    }


    public void ProcessMove(Vector2 input)
    {
        Vector2 move = new Vector2(input.x, input.y);
        animator.SetFloat("VelocityY", input.y);
        animator.SetFloat("VelocityX", input.x);
        characterController.Move(move * Time.deltaTime * playerSpeed);
    }
}
