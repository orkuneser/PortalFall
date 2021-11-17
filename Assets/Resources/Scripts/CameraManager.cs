using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region VARIABLES
    [Header("SKYBOX ROTOTE SPEED")]
    [SerializeField] private float _skyboxRotationPerSecond = 2;
    [Space]
    [Header("CAMERA VARIABLES")]
    private Transform _targetObj;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Vector3 _offSet;

    public static bool cameraEffect;

    #endregion

    public static CameraManager Singleton;


    private void Awake()
    {
        Singleton = this;

        // Set Player Tags as Targets
        _targetObj = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected void Update()
    {
        SkyboxRotate();
    }
    private void LateUpdate()
    {
        CameraTargetFollow();
    }

    #region CAMERA EFFECT METHOD
    public void CameraEffect(string effectName)
    {
        if (effectName == "back")
        {
            if (GetComponent<Camera>().fieldOfView < 60)
            {
                GetComponent<Camera>().fieldOfView += 10 * Time.deltaTime;
            }

        }
        else if (effectName == "forward")
        {
            if (GetComponent<Camera>().fieldOfView > 50)
            {
                GetComponent<Camera>().fieldOfView -= 10 * Time.deltaTime;
            }
        }

    }
    #endregion

    #region TARGET FOLLOW METHOD
    private void CameraTargetFollow()
    {
        Vector3 desiredPosition = _targetObj.position + _offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;
    }
    #endregion

    #region SKYBOX ROTATE METHOD
    private void SkyboxRotate()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * _skyboxRotationPerSecond);
    }

    #endregion

}
