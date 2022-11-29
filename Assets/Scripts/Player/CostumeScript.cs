using Packages.Rider.Editor.UnitTesting;
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
    [SerializeField] List<RuntimeAnimatorController> newClothes = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> newPants = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> newHair = new List<RuntimeAnimatorController>();
    private List<RuntimeAnimatorController> availableSkin = new List<RuntimeAnimatorController>();
    private List<RuntimeAnimatorController> availableClothes = new List<RuntimeAnimatorController>();
    private List<RuntimeAnimatorController> availableHair = new List<RuntimeAnimatorController>();
    private List<RuntimeAnimatorController> availablePants = new List<RuntimeAnimatorController>();
    [SerializeField] GameObject clothesObject;
    [SerializeField] GameObject pantsObject;
    [SerializeField] GameObject hairObject;
    [SerializeField] Slider skinToneSlider;
    [SerializeField] Slider clothesSlider;
    [SerializeField] Slider pantsSlider;
    [SerializeField] Slider hairSlider;


    public static CostumeScript Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        AvailableSkins(0);
        AvailablePants(0);
        AvailableClothes(0);
        AvailableHair(0);
    }

    public void ChangeSkinTone()
    {
        animator.runtimeAnimatorController = availableSkin[Mathf.FloorToInt(skinToneSlider.value)];
    }
    public void ChangeClothes()
    {
        clothesObject.GetComponent<Animator>().runtimeAnimatorController = availableClothes[Mathf.FloorToInt(clothesSlider.value)];
    }
    public void ChangePants()
    {
        pantsObject.GetComponent<Animator>().runtimeAnimatorController = availablePants[Mathf.FloorToInt(pantsSlider.value)];
    }
    public void ChangeHair()
    {
        hairObject.GetComponent<Animator>().runtimeAnimatorController = availableHair[Mathf.FloorToInt(hairSlider.value)];
    }

    public void AvailableSkins(int value)
    {
      availableSkin.Add(newSkin[value]);
    }
    public void AvailableClothes(int value)
    {
        availableClothes.Add(newClothes[value]);
    }

    public void AvailableHair(int value)
    {
        availableHair.Add(newHair[value]);
    }

    public void AvailablePants(int value)
    {
        availablePants.Add(newPants[value]);
    }
}
