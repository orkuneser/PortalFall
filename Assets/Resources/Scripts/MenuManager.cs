using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    #region SETTINGS VARIABLES
    [SerializeField] private GameObject _SoundBtn;
    private bool isSoundActive;
    #endregion

    #region USER NAME VARIABLES
    [SerializeField] private InputField _inputField;
    [SerializeField] private Text _menuUserName, _userPanelName;
    [HideInInspector] public string userName;
    #endregion


    [SerializeField] private Text gameMoneyTxt;

    #region NATIFICATION PANEL VARIABLES
    [Space]
    [Header("NOTIFICATION VARIABLES")]
    public GameObject notificationPanel;
    public Text notificationCommentLabel;
    #endregion

    #region PLAYERS GAME OBJECT
    [Space]
    [Header("PLAYERS")]
    public GameObject[] playerObjects;
    #endregion

    // Singleton
    public static MenuManager Singleton;
    // Player Money
    [HideInInspector] public static int gameMoney;


    private void Awake()
    {
        #region SINGLETON
        if (Singleton != null && Singleton != this)
        {
            Destroy(this.gameObject);
        }

        Singleton = this;
        DontDestroyOnLoad(this);
        #endregion

        //TEST MONEY
        //GameMoneyIncrease(5000);
    }
    private void Start()
    {

        #region Start Configurations
        _SoundBtn.GetComponent<Image>().color = Color.green;
        #endregion

        #region DATA CONTROLL
        GetUserName();
        GetGameMoney();
        #endregion

    }


    #region GAME MONEY METHODS
    public void GameMoneyIncrease(int amount)
    {
        gameMoney += amount;
        gameMoneyTxt.text = gameMoney.ToString();

        PlayerPrefs.SetInt("gamemoney", gameMoney);
    }

    public void GameMoneyDecrease(int amount)
    {
        gameMoney -= amount;
        gameMoneyTxt.text = gameMoney.ToString();

        PlayerPrefs.SetInt("gamemoney", gameMoney);
    }
    public void GetGameMoney()
    {
        if (PlayerPrefs.HasKey("gamemoney"))
        {
            gameMoney = PlayerPrefs.GetInt("gamemoney");
            gameMoneyTxt.text = gameMoney.ToString();
        }
        else
        {
            gameMoney = 500;
            gameMoneyTxt.text = gameMoney.ToString();
        }


    }

    #endregion

    #region USER NAME METHOD
    public void UserNameSaveBtn()
    {
        SetUserName(_inputField.text);

        // Notification Pop-Up
        notificationPanel.SetActive(true);
        notificationCommentLabel.text = _inputField.text + " Name Saved!";
    }

    private void SetUserName(string _newUserName)
    {
        userName = _newUserName;
        _menuUserName.text = userName;
        _userPanelName.text = userName;

        PlayerPrefs.SetString("username", userName);
    }

    private void GetUserName()
    {
        if (PlayerPrefs.HasKey("username"))
        {
            userName = PlayerPrefs.GetString("username");
            _menuUserName.text = userName;
            _userPanelName.text = userName;
        }
        else
        {
            userName = "UserName..";
            _menuUserName.text = userName;
            _userPanelName.text = userName;
        }
    }
    #endregion

    #region PLAY BUTTON METHOD
    public void PlayGameBtn()
    {
        // Loads Game Scene
        SceneManager.LoadScene("GamePlay");
    }
    #endregion

    #region SETTINGS PANEL METHODS
    public void SoundBtn()
    {
        // If the sound is on, we turn it off, if it is off, we turn it on.
        isSoundActive = !isSoundActive;

        // If Sound is On
        if (isSoundActive)
        {
            _SoundBtn.GetComponent<Image>().color = Color.green;

            // Notification Pop-Up
            notificationPanel.SetActive(true);
            notificationCommentLabel.text = "SOUND ON!";

        }
        // If Sound is Off
        else
        {
            _SoundBtn.GetComponent<Image>().color = Color.red;

            // Notification Pop-Up
            notificationPanel.SetActive(true);
            notificationCommentLabel.text = "SOUND OFF!";


        }
    }

    // Deletes all data
    public void ResetAllDataBtn()
    {
        PlayerPrefs.DeleteAll();

        // Notification Pop-Up
        notificationPanel.SetActive(true);
        notificationCommentLabel.text = "CLEAR ALL DATA!";
    }

    #endregion


}
