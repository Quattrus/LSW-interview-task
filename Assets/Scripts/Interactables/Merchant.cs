using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] List<int> ownedSkins = new List<int>();
    [SerializeField] List<Sprite> ownedSkinSprites = new List<Sprite>();
    [SerializeField] List<int> ownedClothes = new List<int>();
    [SerializeField] List<Sprite> ownedClothesSprites = new List<Sprite>();
    [SerializeField] List<int> ownedHair = new List<int>();
    [SerializeField] List<Sprite> ownedHairSprites = new List<Sprite>();
    [SerializeField] List<int> ownedPants = new List<int>();
    [SerializeField] List<Sprite> ownedPantsSprites = new List<Sprite>();
    private bool canBuySkin, canBuyPants, canBuyHair, canBuyClothes = false;
    private bool canSellSkin, canSellPants, canSellHair, canSellClothes = false;
    private int currentSkinSprite, currentClothesSprite, currentHairSprite, currentPantsSprite = 0;
    private int currentSellSkinSprite, currentSellClothesSprite, currentSellHairSprite, currentSellPantsSprite = 0;
    private bool buyingState, dialogueState;
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
        sellHairPriceText.text = (hairPrice - 5).ToString();
        sellPantsPriceText.text = (pantsPrice - 10).ToString();
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
        
        if(currentSkinSprite == 0)
        {
            currentSkinSprite = allSkinTones.Length - 1;    
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
        
        if (currentSkinSprite >= allSkinTones.Length - 1)
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
        if (currentSellSkinSprite >= ownedSkinSprites.Count - 1)
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
            currentClothesSprite = allClothes.Length - 1;
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

        if (currentClothesSprite >= allClothes.Length - 1)
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
        if (currentSellClothesSprite >= ownedClothes.Count - 1)
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
        if (currentHairSprite >= allHair.Length - 1)
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
        if (currentSellHairSprite >= ownedHairSprites.Count - 1)
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
        if (currentPantsSprite >= allPants.Length - 1)
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
        if (currentSellPantsSprite >= ownedPantsSprites.Count - 1)
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
            ownedClothesSprites.Add(allClothes[currentClothesSprite]);
        }
        
    }

    public void BuyHair()
    {
        if (canBuyHair)
        {
            CostumeScript.Instance.AvailableHair(currentHairSprite);
            ownedHair.Add(currentHairSprite);
            PlayerScript.Instance.AvailableCredit -= hairPrice;
            ownedHairSprites.Add(allHair[currentHairSprite]);
        }

        
        
    }

    public void BuyPants()
    {
        if (canBuyPants)
        {
            CostumeScript.Instance.AvailablePants(currentPantsSprite);
            ownedPants.Add(currentPantsSprite);
            PlayerScript.Instance.AvailableCredit -= pantsPrice;
            ownedPantsSprites.Add(allPants[currentPantsSprite]);
        }
        
    }

    public void SellSkins()
    {
        if (canSellSkin)
        {
            Sprite toSellSkinSprite = ownedSkinSprites[currentSellSkinSprite];
            int toRemoveSkinSprite = ownedSkins[currentSellSkinSprite];
            ownedSkinSprites.Remove(toSellSkinSprite);
            ownedSkins.Remove(toRemoveSkinSprite);
            if (CostumeScript.Instance.SkinTonePicked == currentSellSkinSprite)
            {
                CostumeScript.Instance.ChangeSkinTone(CostumeScript.Instance.SkinTonePicked - 1);
            }
            else if(CostumeScript.Instance.SkinTonePicked == 1)
            {
                CostumeScript.Instance.ChangeSkinTone(0);
            }
            CostumeScript.Instance.RemoveSkins(toRemoveSkinSprite);
            if(currentSellSkinSprite < 1)
            {
                currentSellSkinSprite = ownedSkins.Count;
                sellSkinSprite.GetComponent<Image>().sprite = ownedSkinSprites[ownedSkins.Count - 1];
            }
            else
            {
                sellSkinSprite.GetComponent<Image>().sprite = ownedSkinSprites[currentSellSkinSprite - 1];
            }
                     
            PlayerScript.Instance.AvailableCredit += (tonePrice - 10);
            
            
        }
    }
    public void SellPants()
    {
        if (canSellPants)
        {                      
            Sprite toSellPantsSprite = ownedPantsSprites[currentSellPantsSprite];
            int toRemovePantsSprite = ownedPants[currentSellPantsSprite];
            ownedPantsSprites.Remove(toSellPantsSprite);
            ownedPants.Remove(toRemovePantsSprite);
            if (CostumeScript.Instance.PantsPicked == currentSellPantsSprite)
            {
                CostumeScript.Instance.ChangePants(CostumeScript.Instance.PantsPicked - 1);
            }
            else if (CostumeScript.Instance.PantsPicked == 1)
            {
                CostumeScript.Instance.ChangePants(0);
            }
            CostumeScript.Instance.RemovePants(toRemovePantsSprite);
            
            if (currentSellPantsSprite < 1)
            {
                currentSellPantsSprite = ownedPants.Count;
                sellPantsSprite.GetComponent<Image>().sprite = ownedPantsSprites[ownedPants.Count - 1];
            }
            else
            {
                sellPantsSprite.GetComponent<Image>().sprite = ownedSkinSprites[currentSellPantsSprite - 1];
            }
            PlayerScript.Instance.AvailableCredit += (pantsPrice - 10);
        }
    }
    public void SellHair()
    {
        if (canSellHair)
        {
            PlayerScript.Instance.AvailableCredit += (hairPrice - 10);
            Sprite toSellHairSprite = ownedHairSprites[currentSellHairSprite];
            int toRemoveHairSprite = ownedHair[currentSellHairSprite];
            ownedHairSprites.Remove(toSellHairSprite);
            ownedHair.Remove(toRemoveHairSprite);
            if (CostumeScript.Instance.HairPicked == currentSellHairSprite)
            {
                CostumeScript.Instance.ChangeHair(CostumeScript.Instance.HairPicked - 1);
            }
            else if (CostumeScript.Instance.HairPicked == 1)
            {
                CostumeScript.Instance.ChangeHair(0);
            }
            CostumeScript.Instance.RemoveHair(toRemoveHairSprite);
            if (currentSellHairSprite < 1)
            {
                currentSellHairSprite = ownedHair.Count;
                sellHairSprite.GetComponent<Image>().sprite = ownedSkinSprites[ownedHair.Count - 1];
            }
            else
            {
                sellHairSprite.GetComponent<Image>().sprite = ownedHairSprites[currentSellHairSprite - 1];
            }
            PlayerScript.Instance.AvailableCredit += (hairPrice - 10);
        }
    }
    public void SellClothes()
    {
        if (canSellClothes)
        {
            PlayerScript.Instance.AvailableCredit += (clothesPrice - 10);
            Sprite toSellClothesSprite = ownedClothesSprites[currentSellClothesSprite];
            int toRemoveClothesSprite = ownedClothes[currentSellClothesSprite];
            ownedClothesSprites.Remove(toSellClothesSprite);
            ownedClothes.Remove(toRemoveClothesSprite);
            if (CostumeScript.Instance.HairPicked == currentSellHairSprite)
            {
                CostumeScript.Instance.ChangeClothes(CostumeScript.Instance.ClothesPicked - 1);
            }
            else if (CostumeScript.Instance.ClothesPicked == 1)
            {
                CostumeScript.Instance.ChangeClothes(0);
            }
            CostumeScript.Instance.RemoveClothes(toRemoveClothesSprite);
            
            if (currentSellClothesSprite < 1)
            {
                currentSellClothesSprite = ownedClothes.Count;
                sellClothesSprite.GetComponent<Image>().sprite = ownedClothesSprites[ownedClothes.Count - 1];
            }
            else
            {
                sellClothesSprite.GetComponent<Image>().sprite = ownedClothesSprites[currentSellClothesSprite - 1];
            }
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
        buyingState = false;
    }

    public void ExitSellingState()
    {
        PlayerScript.Instance.BuyingState = false;
        sellingPanel.SetActive(false);
        buyingState = false;
        currentSellSkinSprite = 0;
        currentSellHairSprite = 0;
        currentSellClothesSprite = 0;
        currentSellPantsSprite = 0;

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
        buyingState = true;
        sellingPanel.SetActive(true);
        dialogueState = false;
        PlayerScript.Instance.BuyingState = true;


    }

    public void PlayerBuying()
    {
        dialoguePanel.SetActive(false);
        dialogueState = false;
        buyingPanel.SetActive(true);
        buyingState = true;
        PlayerScript.Instance.BuyingState = true;

    }


}
