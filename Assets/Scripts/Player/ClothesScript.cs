using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesScript : MonoBehaviour
{
    private Animator animator;



    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    public void ClothesAnimation(Vector2 input)
    {
        animator.SetFloat("VelocityX", input.x);
        animator.SetFloat("VelocityY", input.y);
        Debug.Log(input);
    }
}
