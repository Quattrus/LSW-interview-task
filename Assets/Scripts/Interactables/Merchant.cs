using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    [SerializeField] GameObject buyingPanel;
    [SerializeField] List<Sprite> allSkinTones = new List<Sprite>();
    [SerializeField] List<Sprite> allClothes = new List<Sprite>();
    [SerializeField] List<Sprite> allHair = new List<Sprite>();

    [SerializeField] Button skinToneLeft, skinToneRight, clothesLeft, clothesRight, hairLeft, hairRight, pantsLeft, pantsRight;



    public void LeftSkinButton()
    {
        Debug.Log("LeftSkin");
    }

    public void RightSkinButton() 
    {
        Debug.Log("RightSkin");
    }

    public void LeftClothesButton()
    {
        Debug.Log("LeftClothes");
    }

    public void RightClothesButton()
    {
        Debug.Log("RightClothes");
    }
    public void LeftHairButton()
    {
        Debug.Log("LeftHair");
    }

    public void RightHairButton()
    {
        Debug.Log("RightHair");
    }

    public void LeftPantsButton()
    {
        Debug.Log("LeftPants");
            
    }

    public void RightPantsButton()
    {
        Debug.Log("RightPants");
    }


}
