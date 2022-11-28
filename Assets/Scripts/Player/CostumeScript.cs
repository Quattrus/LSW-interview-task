using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CostumeScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] List<RuntimeAnimatorController> newSkin = new List<RuntimeAnimatorController>();
    private int[] purchasedSkins;
    [SerializeField] List<RuntimeAnimatorController> newClothes = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> newPants = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> newHair = new List<RuntimeAnimatorController>();
    [SerializeField] GameObject clothesObject;
    [SerializeField] GameObject pantsObject;
    [SerializeField] GameObject hairObject;
    [SerializeField] Slider skinToneSlider;
    [SerializeField] Slider clothesSlider;
    [SerializeField] Slider pantsSlider;
    [SerializeField] Slider hairSlider;
    private int purchasedTones;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        purchasedSkins[0] = 1;
        purchasedSkins[1] = 3;
    }

    private void Update()
    {
        CheckPurchase();
        
    }

    public void ChangeSkinTone()
    {
      animator.runtimeAnimatorController = newSkin[Mathf.FloorToInt(skinToneSlider.value)];
    }
    public void ChangeClothes()
    {
        clothesObject.GetComponent<Animator>().runtimeAnimatorController = newClothes[Mathf.FloorToInt(clothesSlider.value)];
    }
    public void ChangePants()
    {
        pantsObject.GetComponent<Animator>().runtimeAnimatorController = newPants[Mathf.FloorToInt(pantsSlider.value)];
    }
    public void ChangeHair()
    {
        hairObject.GetComponent<Animator>().runtimeAnimatorController = newHair[Mathf.FloorToInt(hairSlider.value)];
    }

    private void CheckPurchase()
    {
    }

}
