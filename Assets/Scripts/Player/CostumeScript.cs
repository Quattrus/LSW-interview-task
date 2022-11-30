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
    private int skinTonePicked, clothesPicked, hairPicked, pantsPicked = 0;
    [SerializeField] GameObject clothesObject;
    [SerializeField] GameObject pantsObject;
    [SerializeField] GameObject hairObject;
    [SerializeField] Button skinTonePrev, skinToneNext;
    [SerializeField] Slider skinToneSlider;
    [SerializeField] Slider clothesSlider;
    [SerializeField] Slider pantsSlider;
    [SerializeField] Slider hairSlider;


    public static CostumeScript Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        AvailableSkins(0);
        AvailablePants(0);
        AvailableClothes(0);
        AvailableHair(0);
    }



    private void ChangeSkinTone()
    {
        animator.runtimeAnimatorController = availableSkin[skinTonePicked];
    }
    private void ChangeClothes()
    {
        clothesObject.GetComponent<Animator>().runtimeAnimatorController = availableClothes[clothesPicked];
    }
    private void ChangePants()
    {
        pantsObject.GetComponent<Animator>().runtimeAnimatorController = availablePants[pantsPicked];
    }
    private void ChangeHair()
    {
        hairObject.GetComponent<Animator>().runtimeAnimatorController = availableHair[hairPicked];
    }

    public void SkinTonePrevious()
    {
        if(skinTonePicked <= 0)
        {
            skinTonePicked = availableSkin.Count - 1;
        }
        else
        {
            skinTonePicked--;
        }
        ChangeSkinTone();
    }

    public void SkinToneNext()
    {
        if(skinTonePicked >= availableSkin.Count - 1)
        {
            skinTonePicked = 0;
        }
        else
        {
            skinTonePicked++;
        }
        ChangeSkinTone();
    }

    public void ClothesNext()
    {
        if(clothesPicked >= availableClothes.Count - 1)
        {
            clothesPicked = 0;
        }
        else
        {
            clothesPicked++;
        }
        ChangeClothes();
    }

    public void ClothesPrevious()
    {
        if(clothesPicked <= 0)
        {
            clothesPicked = availableClothes.Count - 1;
        }
        else
        {
            clothesPicked--;
        }
    }

    public void HairNext()
    {
        if (hairPicked >= availableHair.Count - 1)
        {
            hairPicked = 0;
        }
        else
        {
            hairPicked++;
        }
        ChangeHair();
    }

    public void HairPrevious()
    {
        if (hairPicked <= 0)
        {
            hairPicked = availableHair.Count - 1;
        }
        else
        {
            hairPicked--;
        }
    }

    public void PantsNext()
    {
        if (pantsPicked >= availablePants.Count - 1)
        {
            pantsPicked = 0;
        }
        else
        {
            pantsPicked++;
        }
        ChangePants();
    }

    public void PantsPrevious()
    {
        if (pantsPicked <= 0)
        {
            pantsPicked = availablePants.Count - 1;
        }
        else
        {
            pantsPicked--;
        }
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

    public void RemoveSkins(int value)
    {
        availableSkin.Remove(newSkin[value]);
    }

    public void RemovePants(int value)
    {
        availablePants.Remove(newPants[value]);
    }

    public void RemoveClothes(int value)
    {
        availableClothes.Remove(newClothes[value]);
    }

    public void RemoveHair(int value)
    {
        availableHair.Remove(newHair[value]);
    }
}
