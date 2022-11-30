using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] List<RuntimeAnimatorController> newSkin = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> newClothes = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> newPants = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> newHair = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> availableSkin = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> availableClothes = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> availableHair = new List<RuntimeAnimatorController>();
    [SerializeField] List<RuntimeAnimatorController> availablePants = new List<RuntimeAnimatorController>();
    private int skinTonePicked, clothesPicked, hairPicked, pantsPicked = 0;
    [SerializeField] GameObject clothesObject;
    [SerializeField] GameObject pantsObject;
    [SerializeField] GameObject hairObject;
    [SerializeField] Button skinTonePrev, skinToneNext, clothesPrev, clothesNext, hairPrev, hairNext;


    public static CostumeScript Instance { get; private set; }
    public int SkinTonePicked { get { return skinTonePicked; } set { skinTonePicked = value; } }
    public int ClothesPicked { get { return clothesPicked; } set { clothesPicked = value; } }
    public int HairPicked { get { return hairPicked; } set { hairPicked = value; } }
    public int PantsPicked { get { return pantsPicked; } set { pantsPicked = value; } }


    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        AvailableSkins(0);
        AvailablePants(0);
        AvailableClothes(0);
        AvailableHair(0);
    }



    public void ChangeSkinTone(int value)
    {
        if(value < 0)
        {
            value = availableSkin.Count - 1;
        }
        animator.runtimeAnimatorController = availableSkin[value];
    }
    public void ChangeClothes(int value)
    {
        if (value < 0)
        {
            value = availableClothes.Count - 1;
        }
        clothesObject.GetComponent<Animator>().runtimeAnimatorController = availableClothes[value];
    }
    public void ChangePants(int value)
    {
        if (value < 0)
        {
            value = availablePants.Count - 1;
        }
        pantsObject.GetComponent<Animator>().runtimeAnimatorController = availablePants[value];
    }
    public void ChangeHair(int value)
    {
        if (value < 0)
        {
            value = availableHair.Count - 1;
        }
        hairObject.GetComponent<Animator>().runtimeAnimatorController = availableHair[value];
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
        ChangeSkinTone(skinTonePicked);
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
        ChangeSkinTone(skinTonePicked);
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
        ChangeClothes(clothesPicked);
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
        ChangeClothes(clothesPicked);
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
        ChangeHair(hairPicked);
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
        ChangeHair(hairPicked);
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
        ChangePants(pantsPicked);
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
        ChangePants(pantsPicked);
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
