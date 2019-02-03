using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : Singleton<CameraShake>
{
    public float shakes = 0f;
    public float shakeAmount = 0.05f;
    public float decreaseFacetor = 1.0f;
    Vector3 OriginalPos;
    public bool cameraShaking;

    private void OnEnable()
    {
        cameraShaking = false;
        OriginalPos = gameObject.transform.position;
    }

    private void Update()
    {
        if(cameraShaking)
        {
            if(shakes>0f)
            {
                gameObject.transform.position = OriginalPos + Random.insideUnitSphere * shakeAmount;

                shakes -= Time.deltaTime * decreaseFacetor;
            }
            else
            {
                shakes = 0f;
                cameraShaking = false;
                gameObject.transform.position = OriginalPos;
            }
        }
    }

    public void ShakeCamera(float shaking,float _shakeAmount)
    {

        if(!cameraShaking)
        {
            OriginalPos = gameObject.transform.position;
        }
        shakeAmount = _shakeAmount;
        shakes = shaking;
        cameraShaking = true;
    }

}
