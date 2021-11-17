using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    [HideInInspector] public bool isGameStart;

    public static GameManager Singleton;

    [SerializeField] private GameObject[] _Players;
    [SerializeField] private Animator[] _PlayersAnimator;
    #endregion

    

    private void Awake()
    {
        #region START CONFIGURATIONS
        Singleton = this;
        isGameStart = false;
        #endregion

        GetSelectCharacter();

    }

    #region GET SELECT CHARACTER

    // Show the Character Selected in the Menu in the Game Scene
    private void GetSelectCharacter()
    {
        // We Turn Off All Characters
        for (int i = 0; i < _Players.Length; i++)
        {
            _Players[i].SetActive(false);
        }

        // We Leave the Selected Character Open.

        switch (ShopManager._selectCharacterID)
        {
            case 0:
                _Players[0].SetActive(true);
                break;
            case 1:
                _Players[1].SetActive(true);
                break;
            case 2:
                _Players[2].SetActive(true);
                break;
            case 3:
                _Players[3].SetActive(true);
                break;

        }
    }
    #endregion

    public void GameStart(bool isStart)
    {
        isGameStart = isStart;
    }

    public void LoadNewLevel()
    {
        // Reloads Current Level When Current Level Is Not Completed
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #region PLAYER ANIMATION METHODS
    public void SetAnimations(string _animationName,bool _state, int characterID)
    {
        switch (characterID)
        {
            case 0:
                _PlayersAnimator[characterID].SetBool(_animationName,_state);
                break;
            case 1:
                _PlayersAnimator[characterID].SetBool(_animationName, _state);
                break;
            case 2:
                _PlayersAnimator[characterID].SetBool(_animationName, _state);
                break;
            case 3:
                _PlayersAnimator[characterID].SetBool(_animationName, _state);
                break;
            
        }
      
    }
    #endregion
}
