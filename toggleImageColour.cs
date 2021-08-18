using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleImageColour : MonoBehaviour
{
    public Image image;
    public bool toggle;

    void Awake(){
        image = gameObject.GetComponent<Image>();
        toggle = false;
    }


    public void toggleColour(){
        switch (toggle){
            case true:
            image.color = new Color32(192, 192, 192, 255);
            toggle = false;
            break;
            case false:
            image.color = new Color32(0,143,255,255);
            toggle = true;
            break;
        }
    }
}
