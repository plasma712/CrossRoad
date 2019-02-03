using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Screen.SetResolution(1080, 1920, true);
    }

    public void ThisObjectDestory()
    {   
        Destroy(this.gameObject);
    }
}
