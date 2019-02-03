using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroToolTipControl : MonoBehaviour
{
    public GameObject NewGameToolTip;
    public GameObject IntroButton;
    

    public void Cancel()
    {
        IntroButton.gameObject.SetActive(true);
        NewGameToolTip.gameObject.SetActive(false);
    }

}
