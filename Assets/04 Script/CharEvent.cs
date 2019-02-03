using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharEvent : MonoBehaviour
{
    public GameObject Box;
    public int InherentNumber;
    public GameObject Original;
    public GameObject Opaque;


    private void Start()
    {
        Box.gameObject.SetActive(false);
    }

    public void BoxSetActiveTrue()
    {
         Box.gameObject.SetActive(true);
    }
    

}
