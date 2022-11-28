using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] List<RuntimeAnimatorController> newControllers = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> newClothes = new List<RuntimeAnimatorController>();
    [SerializeField] GameObject clothesObject;
    [SerializeField] Slider skinToneSlider;
    [SerializeField] Slider clothesSlider;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeSkinTone()
    {
      animator.runtimeAnimatorController = newControllers[Mathf.FloorToInt(skinToneSlider.value)];
    }
    public void ChangeClothes()
    {
        clothesObject.GetComponent<Animator>().runtimeAnimatorController = newClothes[Mathf.FloorToInt(clothesSlider.value)];
    }

}
