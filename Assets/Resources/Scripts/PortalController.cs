using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PortalController : MonoBehaviour
{

    [SerializeField] private GameObject[] Points;
    [SerializeField] private GameObject _forwardPortalObj;
    [SerializeField] private GameObject _backPortalObj;
    public Slider _sliderObj;
    public int pointIndex;

    public static PortalController Singleton;

    private void Awake()
    {
        Singleton = this;
    }
    private void Update()
    {
        if (GameManager.Singleton.isGameStart && PlayerController._isFall)
        {
            PortalControll();
            CameraEffectControll();

            // Portall Energy Ball Refill
            _sliderObj.value += 0.20f * Time.deltaTime;

        }
    }

    #region CAMERA EFFECT
    private void CameraEffectControll()
    {
        if (CameraManager.cameraEffect)
        {
            CameraManager.Singleton.CameraEffect("back");

        }
        else
        {
            CameraManager.Singleton.CameraEffect("forward");

        }
    }
    #endregion

    #region PORTALL MECHANIC
    private void PortalControll()
    {
        if (Input.GetMouseButton(0))
        {


            CameraManager.cameraEffect = true;
            _sliderObj.value -= 0.005f;


            _backPortalObj.SetActive(true);
            _forwardPortalObj.SetActive(true);


            if (Vector3.Distance(_forwardPortalObj.transform.position, Points[pointIndex].transform.position) < 0.001f)
            {
                pointIndex++;

                if (pointIndex == 2)
                {
                    pointIndex = 0;
                }
            }
            _forwardPortalObj.transform.position = Vector3.MoveTowards(_forwardPortalObj.transform.position, Points[pointIndex].transform.position, 5f * Time.deltaTime);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().isTrigger = true;

            CameraManager.cameraEffect = false;

            transform.position = _forwardPortalObj.transform.position;

            StartCoroutine(PortallDelay());

        }

    }

    IEnumerator PortallDelay()
    {
        _forwardPortalObj.transform.position = Points[0].transform.position;
        yield return new WaitForSeconds(1f);
        _backPortalObj.SetActive(false);
        _forwardPortalObj.SetActive(false);
    }
    #endregion
}
