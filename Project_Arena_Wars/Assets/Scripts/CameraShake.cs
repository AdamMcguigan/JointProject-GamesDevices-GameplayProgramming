using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 originalCameraPos;

    public float shakeDuration = 2f;
    public float shakeAmount = 0.7f;

    public static CameraShake instance;

    private bool canShake = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
       
    }

    public void shakeCamera(float _shakeDuration)
    {
        canShake = true;
        shakeDuration = _shakeDuration;
    }

    void Update()
    {
        originalCameraPos = cameraTransform.localPosition;
        if (shakeDuration > 0)
        {
            cameraTransform.localPosition = originalCameraPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            cameraTransform.position = originalCameraPos;
        }
    }
}
