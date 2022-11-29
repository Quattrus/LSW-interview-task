using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using static UnityEngine.InputManagerEntry;

public class Merchant : MonoBehaviour
{
    [SerializeField] GameObject buyingPanel;
    [SerializeField] Sprite[] allSkinTones;
    [SerializeField] Sprite[] allClothes;
    [SerializeField] Sprite[] allHair;
    [SerializeField] Sprite[] allPants;
    [SerializeField] GameObject skinSprite, clothesSprite, pantsSprite, hairSprite;
    [SerializeField] TextMeshProUGUI tonePriceText;
    [SerializeField] TextMeshProUGUI clothesPriceText;
    [SerializeField] TextMeshProUGUI pantsPriceText;
    [SerializeField] TextMeshProUGUI hairPriceText;
    [SerializeField] int clothesPrice = 30;
    [SerializeField] int hairPrice = 10;
    [SerializeField] int pantsPrice = 20;
    [SerializeField] int tonePrice = 50;
    public List<int> ownedSkins = new List<int>();
    public List<int> ownedClothes = new List<int>();
    public List<int> ownedHair = new List<int>();
    public List<int> ownedPants = new List<int>();
    private bool canBuySkin, canBuyPants, canBuyHair, canBuyClothes = false;
    private int currentSkinSprite, currentClothesSprite, currentHairSprite, currentPantsSprite = 0;

    [SerializeField] Button skinToneLeft, skinToneRight, clothesLeft, clothesRight, hairLeft, hairRight, pantsLeft, pantsRight;

    private void Awake()
    {
        tonePriceText.text = tonePrice.ToString();
        clothesPriceText.text = clothesPrice.ToString();
        pantsPriceText.text = pantsPrice.ToString();
        hairPriceText.text = hairPrice.ToString();
        ownedSkins.Add(0);
        ownedClothes.Add(0);
        ownedHair.Add(0);
        ownedPants.Add(0);
    }

    private void Update()
    {
        if (PlayerScript.Instance.BuyingState)
        {
            CheckSkinAvailability();
            CheckPantsAvailability();
            CheckHairAvailability();
            CheckClothesAvailability();
        }

        Debug.Log(ownedHair);
        
    }

    public void LeftSkinButton()
    {
        
        if(currentSkinSprite <= 0)
        {
            currentSkinSprite = allSkinTones.Length -1;    
        }
        else
        {
            currentSkinSprite--;
        }

        skinSprite.GetComponent<Image>().sprite = allSkinTones[currentSkinSprite];
    }

    public void RightSkinButton() 
    {
        
        if (currentSkinSprite == allSkinTones.Length)
        {
            currentSkinSprite = 0;
        }
        else
        {
            currentSkinSprite++;
        }
        skinSprite.GetComponent<Image>().sprite = allSkinTones[currentSkinSprite];
    }

    public void LeftClothesButton()
    {
        if(currentClothesSprite<= 0)
        {
            currentClothesSprite = allClothes.Length -1;
        }
        else
        {
            currentClothesSprite--;
        }
        clothesSprite.GetComponent<Image>().sprite = allClothes[currentClothesSprite];
    }

    public void RightClothesButton()
    {

        if (currentClothesSprite == allClothes.Length)
        {
            currentClothesSprite = 0;
        }
        else
        {
            currentClothesSprite++;
        }
        clothesSprite.GetComponent<Image>().sprite = allClothes[currentClothesSprite];
    }
    public void LeftHairButton()
    {
        if (currentHairSprite <= 0)
        {
            currentHairSprite = allHair.Length - 1;
        }
        else
        {
            currentHairSprite--;
        }
        hairSprite.GetComponent<Image>().sprite = allHair[currentHairSprite];
    }

    public void RightHairButton()
    {
        if (currentHairSprite == allHair.Length)
        {
            currentHairSprite = 0;
        }
        else
        {
            currentHairSprite++;
        }
        hairSprite.GetComponent<Image>().sprite = allHair[currentHairSprite];
    }

    public void LeftPantsButton()
    {
        if (currentPantsSprite <= 0)
        {
            currentPantsSprite = allPants.Length - 1;
        }
        else
        {
            currentPantsSprite--;
        }
        pantsSprite.GetComponent<Image>().sprite = allPants[currentPantsSprite];

    }

    public void RightPantsButton()
    {
        if (currentPantsSprite == allPants.Length)
        {
            currentPantsSprite = 0;
        }
        else
        {
            currentPantsSprite++;
        }
        pantsSprite.GetComponent<Image>().sprite = allPants[currentPantsSprite];
    }


    public void BuyTone()
    {
        if (canBuySkin)
        {
            ownedSkins.Add(currentSkinSprite);
            CostumeScript.Instance.AvailableSkins(currentSkinSprite);
            PlayerScript.Instance.AvailableCredit -= tonePrice;
        }
        else
        {
            //send a can't buy message 
        }
    }

    public void BuyClothes()
    {
        if (canBuyClothes)
        {
            CostumeScript.Instance.AvailableClothes(currentClothesSprite);
            ownedClothes.Add(currentClothesSprite);
            PlayerScript.Instance.AvailableCredit -= clothesPrice;
        }
        
    }

    public void BuyHair()
    {
        if (canBuyHair)
        {
            CostumeScript.Instance.AvailableHair(currentHairSprite);
            ownedHair.Add(currentHairSprite);
            PlayerScript.Instance.AvailableCredit -= hairPrice;
        }
        
    }

    public void BuyPants()
    {
        if (canBuyPants)
        {
            CostumeScript.Instance.AvailablePants(currentPantsSprite);
            ownedPants.Add(currentPantsSprite);
            PlayerScript.Instance.AvailableCredit -= pantsPrice;
        }
        
    }


    private void CheckSkinAvailability()
    {
            foreach (int skins in ownedSkins)
            {
                if (currentSkinSprite == skins)
                {
                    canBuySkin = false;
                }
                else
                {
                    canBuySkin = true;
                }
            }
    }

    private void CheckClothesAvailability()
    {
            foreach (int clothes in ownedClothes)
            {
                if (currentClothesSprite == clothes)
                {
                    canBuyClothes = false;
                }
                else
                {
                    canBuyClothes = true;
                }
            }
    }


    private void CheckPantsAvailability()
    {
        foreach(int pants in ownedPants)
        {
            if(currentPantsSprite == pants)
            {
                canBuyPants = false;
            }
            else
            {
                canBuyPants = true;
            }
        }
    }
    private void CheckHairAvailability()
    {
        foreach (int hair in ownedHair)
        {
            if (currentHairSprite == hair)
            {
                canBuyHair = false;
            }
            else
            {
                canBuyHair = true;
            }
        }
    }


}
