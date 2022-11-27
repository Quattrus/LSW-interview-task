using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumeScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] List<RuntimeAnimatorController> newControllers = new List<RuntimeAnimatorController>();


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        ChangeSkinTone(0);
    }


    public void ChangeSkinTone(int n)
    {
        animator.runtimeAnimatorController = newControllers[n];
    }

}
