using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    #region UI PANELS
    [Header("PANELS")]
    public GameObject startPanel, gameOverPanel, nextLevelPanel, gamePlayPanel;
    #endregion

    [Space]

    #region VARIABLES
    [Header("VARIABLES")]
    [SerializeField] private Text _topUserName, _gamePlayUserName, _topGameMoney, _gamePlayGameMoney;
    private string _userName;
    private int _gameMoney;

    public static UIManager Singleton;
    #endregion
    private void Awake()
    {
        Singleton = this;

        #region START CONFIGURATIONS
        GetUserName();
        GetGameMoney();
        #endregion
    }
    #region GET GAME MONEY
    private void GetGameMoney()
    {
        if (PlayerPrefs.HasKey("gamemoney"))
        {
            _gameMoney = PlayerPrefs.GetInt("gamemoney");
            _topGameMoney.text = _gameMoney.ToString();
            _gamePlayGameMoney.text = _gameMoney.ToString();
        }
        else
        {

            _gameMoney = 500;
            _topGameMoney.text = _gameMoney.ToString();
            _gamePlayGameMoney.text = _gameMoney.ToString();
        }
    }

    #endregion

    #region GAME PLAYER GET USER NAME
    private void GetUserName()
    {
        if (PlayerPrefs.HasKey("username"))
        {
            _userName = PlayerPrefs.GetString("username");
            _topUserName.text = _userName;
            _gamePlayUserName.text = _userName;
        }
        else
        {

            _userName = "UserName..";
            _topUserName.text = _userName;
            _gamePlayUserName.text = _userName;
        }
    }

    #endregion

    #region GAME PLAY BUTTON METHODS
    public void GameStartBtn()
    {
        startPanel.SetActive(false);
        GameManager.Singleton.GameStart(true);
    }

    public void RetryGameBtn()
    {
        GameManager.Singleton.LoadNewLevel();
        GameManager.Singleton.GameStart(false);
    }
    #endregion
}
