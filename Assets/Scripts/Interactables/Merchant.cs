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
    [SerializeField] GameObject sellingPanel;
    [SerializeField] Sprite[] allSkinTones;
    [SerializeField] Sprite[] allClothes;
    [SerializeField] Sprite[] allHair;
    [SerializeField] Sprite[] allPants;
    [SerializeField] GameObject skinSprite, clothesSprite, pantsSprite, hairSprite;
    [SerializeField] GameObject sellSkinSprite, sellClothesSprite, sellPantsSprite, sellHairSprite;
    [SerializeField] TextMeshProUGUI tonePriceText, sellTonePriceText;
    [SerializeField] TextMeshProUGUI clothesPriceText, sellClothesPriceText;
    [SerializeField] TextMeshProUGUI pantsPriceText, sellPantsPriceText;
    [SerializeField] TextMeshProUGUI hairPriceText, sellHairPriceText;
    [SerializeField] Button buyingPanelExit, buyingButton, sellingButton;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] int clothesPrice = 30;
    [SerializeField] int hairPrice = 10;
    [SerializeField] int pantsPrice = 20;
    [SerializeField] int tonePrice = 50;
    private List<int> ownedSkins = new List<int>();
    [SerializeField] List<Sprite> ownedSkinSprites = new List<Sprite>();
    private List<int> ownedClothes = new List<int>();
    [SerializeField] List<Sprite> ownedClothesSprites = new List<Sprite>();
    private List<int> ownedHair = new List<int>();
    [SerializeField] List<Sprite> ownedHairSprites = new List<Sprite>();
    private List<int> ownedPants = new List<int>();
    [SerializeField] List<Sprite> ownedPantsSprites = new List<Sprite>();
    private bool canBuySkin, canBuyPants, canBuyHair, canBuyClothes = false;
    private bool canSellSkin, canSellPants, canSellHair, canSellClothes = false;
    private int currentSkinSprite, currentClothesSprite, currentHairSprite, currentPantsSprite = 0;
    private int currentSellSkinSprite, currentSellClothesSprite, currentSellHairSprite, currentSellPantsSprite = 0;
    private bool buyingState, dialogueState, sellingState;
    [SerializeField] Button skinToneLeft, skinToneRight, clothesLeft, clothesRight, hairLeft, hairRight, pantsLeft, pantsRight;

    public static Merchant Instance { get; private set; }
    public bool DialogueState { get { return dialogueState; } set { dialogueState = value; } }

    private void Awake()
    {
        Instance = this;
        tonePriceText.text = tonePrice.ToString();
        clothesPriceText.text = clothesPrice.ToString();
        pantsPriceText.text = pantsPrice.ToString();
        hairPriceText.text = hairPrice.ToString();
        sellTonePriceText.text = (tonePrice - 10).ToString();
        sellClothesPriceText.text = (clothesPrice - 10).ToString();
        sellHairPriceText.text = (hairPrice - 10).ToString();
        sellPantsPriceText.text = (pantsPrice - 10).ToString();
        ownedSkins.Add(0);
        ownedClothes.Add(0);
        ownedHair.Add(0);
        ownedPants.Add(0);
        buyingPanel.SetActive(false);
        sellingPanel.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (buyingState)
        {
            CheckSkinAvailability();
            CheckPantsAvailability();
            CheckHairAvailability();
            CheckClothesAvailability();
        }

        if (dialogueState)
        {
            dialoguePanel.SetActive(true);
            PlayerScript.Instance.BuyingState = true;
        }
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

    public void LeftSkinButtonSell()
    {
        if (currentSellSkinSprite <= 0)
        {
            currentSellSkinSprite = ownedSkins.Count - 1;
        }
        else
        {
            currentSellSkinSprite--;
        }

        sellSkinSprite.GetComponent<Image>().sprite = ownedSkinSprites[currentSellSkinSprite];
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
    public void RightSkinButtonSell()
    {
        if (currentSellSkinSprite >= 0)
        {
            currentSellSkinSprite = 0;
        }
        else
        {
            currentSellSkinSprite++;
        }

        sellSkinSprite.GetComponent<Image>().sprite = ownedSkinSprites[currentSellSkinSprite];
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

    public void LeftClothesButtonSell()
    {
        if (currentSellClothesSprite <= 0)
        {
            currentSellClothesSprite = ownedClothes.Count - 1;
        }
        else
        {
            currentSellClothesSprite--;
        }

        sellClothesSprite.GetComponent<Image>().sprite = ownedClothesSprites[currentSellClothesSprite];
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

    public void RightClothesButtonSell()
    {
        if (currentSellClothesSprite >= 0)
        {
            currentSellClothesSprite = 0;
        }
        else
        {
            currentSellClothesSprite++;
        }

        sellClothesSprite.GetComponent<Image>().sprite = ownedClothesSprites[currentSellClothesSprite];
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

    public void LeftHairButtonSell()
    {
        if (currentSellHairSprite <= 0)
        {
            currentSellHairSprite = ownedHair.Count - 1;
        }
        else
        {
            currentSellHairSprite--;
        }

        sellHairSprite.GetComponent<Image>().sprite = ownedHairSprites[currentSellHairSprite];
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

    public void RightHairButtonSell()
    {
        if (currentSellHairSprite >= 0)
        {
            currentSellHairSprite = 0;
        }
        else
        {
            currentSellHairSprite++;
        }

        sellHairSprite.GetComponent<Image>().sprite = ownedHairSprites[currentSellHairSprite];
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

    public void LeftPantsButtonSell()
    {
        if (currentSellPantsSprite <= 0)
        {
            currentSellPantsSprite = ownedPants.Count - 1;
        }
        else
        {
            currentSellPantsSprite--;
        }

        sellPantsSprite.GetComponent<Image>().sprite = ownedPantsSprites[currentSellPantsSprite];
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

    public void RightPantsButtonSell()
    {
        if (currentSellPantsSprite >= 0)
        {
            currentSellPantsSprite = 0;
        }
        else
        {
            currentSellPantsSprite++;
        }

        sellPantsSprite.GetComponent<Image>().sprite = ownedPantsSprites[currentSellPantsSprite];
    }


    public void BuyTone()
    {
        if (canBuySkin)
        {
            ownedSkins.Add(currentSkinSprite);
            CostumeScript.Instance.AvailableSkins(currentSkinSprite);
            PlayerScript.Instance.AvailableCredit -= tonePrice;
            ownedSkinSprites.Add(allSkinTones[currentSkinSprite]);
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

    public void SellSkins()
    {
        if (canSellSkin)
        {
            CostumeScript.Instance.RemoveSkins(currentSkinSprite);
            ownedSkins.Remove(currentSkinSprite);
            PlayerScript.Instance.AvailableCredit += (tonePrice - 10);
        }
    }
    public void SellPants()
    {
        if (canSellPants)
        {
            CostumeScript.Instance.RemovePants(currentPantsSprite);
            ownedSkins.Remove(currentPantsSprite);
            PlayerScript.Instance.AvailableCredit += (pantsPrice - 10);
        }
    }
    public void SellHair()
    {
        if (canSellHair)
        {
            CostumeScript.Instance.RemoveHair(currentHairSprite);
            ownedSkins.Remove(currentHairSprite);
            PlayerScript.Instance.AvailableCredit += (hairPrice - 10);
        }
    }
    public void SellClothes()
    {
        if (canSellClothes)
        {
            CostumeScript.Instance.RemoveHair(currentClothesSprite);
            ownedSkins.Remove(currentClothesSprite);
            PlayerScript.Instance.AvailableCredit += (clothesPrice - 10);
        }
    }


    private void CheckSkinAvailability()
    {
            foreach (int skins in ownedSkins)
            {
                if (currentSkinSprite == skins)
                {
                    canBuySkin = false;
                    canSellSkin = true;
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
                    canSellClothes = true;
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
                canSellPants = true;
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
                canSellHair = true;
            }
            else
            {
                canBuyHair = true;
            }
        }
    }

    public void ExitBuyingState()
    {
        PlayerScript.Instance.BuyingState = false;
        buyingPanel.SetActive(false);
    }

    public void ExitSellingState()
    {
        PlayerScript.Instance.BuyingState = false;
        sellingPanel.SetActive(false);
    }
    public void ExitDialogueState()
    {
        PlayerScript.Instance.BuyingState = false;
        dialoguePanel.SetActive(false);
        dialogueState = false;
    }

    public void PlayerSell()
    {
        dialoguePanel.SetActive(false);
        sellingPanel.SetActive(true);
        dialogueState = false;
        
    }

    public void PlayerBuying()
    {
        dialoguePanel.SetActive(false);
        dialogueState = false;
        buyingPanel.SetActive(true);
        PlayerScript.Instance.BuyingState = true;
    }


}
