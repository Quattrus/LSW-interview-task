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
        animator.SetInteger("VelocityX", Mathf.FloorToInt(input.x));
        animator.SetInteger("VelocityY", Mathf.FloorToInt(input.y));
    }
}
