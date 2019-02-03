using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    public int InherentNumber;
    private void OnMouseUp()
    {
        TutorialText.Instance.TutorialEvent3132(InherentNumber);
        if(InherentNumber==29)
        {
            TutorialText.Instance.TutorialFinally.gameObject.SetActive(true);

        }
        else
        {
            TutorialText.Instance.TutorialFinally.gameObject.SetActive(false);
        }
    }

}

