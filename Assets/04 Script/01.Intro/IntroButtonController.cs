using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroButtonController : MonoBehaviour
{
    public int num;
    public GameObject Orgin;
    public GameObject Sub;
    public GameObject NewGameToolTip;
    public GameObject IntroButton;

    

	// Use this for initialization
	void Start ()
    {
        Orgin.gameObject.SetActive(true);
        Sub.gameObject.SetActive(false);
	}

    void OnMouseEnter()
    {
        Orgin.gameObject.SetActive(false);
        Sub.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        Orgin.gameObject.SetActive(true);
        Sub.gameObject.SetActive(false);
    }
    
    private void OnMouseUp()
    {
        if (num == 1)
        {
            //SceneChange.Instance.IntroMapSettingTutorial();
            NewGameToolTip.gameObject.SetActive(true);
            IntroButton.gameObject.SetActive(false);
        }
        else if (num == 2)
        {
            
            if (ClearStageNumber.Instance.StageNumber>0)
            {
                SceneChange.Instance.MapLobbySceneChange();
            }
            else
            {
                NewGameToolTip.gameObject.SetActive(true);
                IntroButton.gameObject.SetActive(false);
            }
        }
        else if (num == 3)
        {

        }
        else if (num == 4)
        {

        }
    }

}
