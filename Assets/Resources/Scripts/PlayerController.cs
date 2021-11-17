using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float _playerRunSpeed;
    [SerializeField] private Rigidbody _playerRigidbody;

    [HideInInspector] public static bool _isFall;
    #endregion


    private void Start()
    {
        #region START CONFIGURATIONS
        _isFall = false;

        #endregion
    }
    private void FixedUpdate()
    {
        PlayerRun();
    }
    
    #region PLAYER RUN
    public void PlayerRun()
    {
        if (!_isFall && GameManager.Singleton.isGameStart)
        {
            GameManager.Singleton.SetAnimations("Run", true, ShopManager._selectCharacterID);
            transform.Translate(Vector3.forward * _playerRunSpeed * Time.fixedDeltaTime);
        }
    }
    #endregion

    #region PLAYER FALL & ENEMY CONTROLL
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FallTrigger"))
        {
            _isFall = true;
            GameManager.Singleton.SetAnimations("Fall", true, ShopManager._selectCharacterID);
            GameManager.Singleton.SetAnimations("Run", false, ShopManager._selectCharacterID);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            _playerRigidbody.AddForce(Vector3.forward*-100);
            UIManager.Singleton.gamePlayPanel.SetActive(false);
            UIManager.Singleton.gameOverPanel.SetActive(true);
        }
        else if (other.gameObject.CompareTag("LevelComplete"))
        {
            GameManager.Singleton.SetAnimations("Fall",false,ShopManager._selectCharacterID);
            GameManager.Singleton.SetAnimations("Jump",true,ShopManager._selectCharacterID);

            PortalController.Singleton._sliderObj.gameObject.SetActive(false);
            UIManager.Singleton.nextLevelPanel.SetActive(true);
        }
        else if (other.gameObject.CompareTag("FinishTrigger"))
        {
            _isFall = false;
            GameManager.Singleton.isGameStart = false;
            
        }

    }
    #endregion
}
