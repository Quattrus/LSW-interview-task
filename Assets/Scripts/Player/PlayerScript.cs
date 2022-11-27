using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] float playerSpeed = 4f;
    



    private void Awake()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }


    public void ProcessMove(Vector2 input)
    {
        Vector2 move = new Vector2(input.x, input.y);
        characterController.Move(move * Time.deltaTime * playerSpeed);
    }
}
