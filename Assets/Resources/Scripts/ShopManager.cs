using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    #region LIST
    public List<CharacterDataObject> characterList = new List<CharacterDataObject>();

    [SerializeField] private List<Text> characterPriceTxt;
    [SerializeField] private List<GameObject> _buyButtons;
    [SerializeField] private List<GameObject> _selectButtons;
    [SerializeField] private List<Text> _buyButtonsTxt;
    [SerializeField] private List<Text> _selectButtonsTxt;
    #endregion


    public static int _selectCharacterID;

   
    private void Start()
    {
        GetCharacterPriceList();
        CharacterPurchasedControll();
        GetCurrentCharacter();

    }

    #region GET CURRENT CHARACTER METHOD
    private void GetCurrentCharacter()
    {
        // SELECT CHARACTER DATA CONTROLL
        if (PlayerPrefs.HasKey("selectcharacterıd"))
        {
            _selectCharacterID = PlayerPrefs.GetInt("selectcharacterıd");
        }
        else
        {
            _selectCharacterID = 0;
        }

        _selectButtonsTxt[_selectCharacterID].text = "SELECTED";


        // We Turn Off All Characters
        for (int i = 0; i < MenuManager.Singleton.playerObjects.Length; i++)
        {
            MenuManager.Singleton.playerObjects[i].SetActive(false);
        }

        // We Leave the Selected Character Open.

        switch (_selectCharacterID)
        {
            case 0:
                MenuManager.Singleton.playerObjects[_selectCharacterID].SetActive(true);
                break;
            case 1:
                MenuManager.Singleton.playerObjects[_selectCharacterID].SetActive(true);
                break;
            case 2:
                MenuManager.Singleton.playerObjects[_selectCharacterID].SetActive(true);
                break;
            case 3:
                MenuManager.Singleton.playerObjects[_selectCharacterID].SetActive(true);
                break;
            
        }
    }

    #endregion

    #region CHARACTER SELECT CURRENT ID
    public void SelectCharacter(int charachterID)
    {
        
        for (int i = 0; i < characterList.Count; i++)
        {
            if (characterList[i].isPurchase)
            {
                _selectCharacterID = charachterID;
                if (_selectCharacterID == characterList[i].characterID)
                {
                    PlayerPrefs.SetInt("selectcharacterıd", _selectCharacterID);
                    _selectButtonsTxt[charachterID].text = "SELECTED";
                    GetCurrentCharacter();

                    // Notification Pop-Up
                    MenuManager.Singleton.notificationPanel.SetActive(true);
                    MenuManager.Singleton.notificationCommentLabel.text = "CHARACTER SELECTED!";
                }
                else
                {
                    _selectButtonsTxt[i].text = "SELECT";
                }
            }
            
        }
    }
    #endregion

    #region CHARACTER BUY/SELECT BUTTONS CONTROLL
    private void CharacterPurchasedControll()
    {
        characterList[0].isPurchase = true;

        for (int i = 0; i < characterList.Count; i++)
        {

            if (characterList[i].isPurchase)
            {
                _selectButtons[i].SetActive(true);
                _buyButtons[i].SetActive(false);
            }
            else
            {
                _buyButtons[i].SetActive(true);
                _selectButtons[i].SetActive(false);

            }
           
        }
    }
    #endregion

    #region CHARACTER PURCHASED METHOD
    public void BuyCharacter(int characterID)
    {
        switch (characterID)
        {
            case 1:
                if (MenuManager.gameMoney >= characterList[1].characterPrice && !characterList[1].isPurchase)
                {
                    MenuManager.Singleton.GameMoneyDecrease(characterList[1].characterPrice);

                    characterList[1].isPurchase = true;

                    CharacterPurchasedControll();

                    // Notification Pop-Up
                    MenuManager.Singleton.notificationPanel.SetActive(true);
                    MenuManager.Singleton.notificationCommentLabel.text = "CHARACTER PURCHASED!";

                }
                break;
            case 2:
                if (MenuManager.gameMoney >= characterList[2].characterPrice && !characterList[2].isPurchase)
                {
                    MenuManager.Singleton.GameMoneyDecrease(characterList[2].characterPrice);

                    characterList[2].isPurchase = true;

                    CharacterPurchasedControll();

                    // Notification Pop-Up
                    MenuManager.Singleton.notificationPanel.SetActive(true);
                    MenuManager.Singleton.notificationCommentLabel.text = "CHARACTER PURCHASED!";
                }
                break;
            case 3:
                if (MenuManager.gameMoney >= characterList[3].characterPrice && !characterList[3].isPurchase)
                {
                    MenuManager.Singleton.GameMoneyDecrease(characterList[3].characterPrice);

                    characterList[3].isPurchase = true;

                    CharacterPurchasedControll();

                    // Notification Pop-Up
                    MenuManager.Singleton.notificationPanel.SetActive(true);
                    MenuManager.Singleton.notificationCommentLabel.text = "CHARACTER PURCHASED!";
                }
                break;

            default:
                // Notification Pop-Up
                MenuManager.Singleton.notificationPanel.SetActive(true);
                MenuManager.Singleton.notificationCommentLabel.text = "Not Enough Money!";
                break;
        }
    }
    #endregion


    #region CHARACTER PRICE LIST
    private void GetCharacterPriceList()
    {
        // Get Character Prices.
        for (int i = 0; i < characterList.Count; i++)
        {
            characterPriceTxt[i].text = characterList[i].characterPrice.ToString();
        }
    }

    #endregion
}
