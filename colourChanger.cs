using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colourChanger : MonoBehaviour
{
    public bool selected;
    public void setColourGreen(){
        gameObject.GetComponent<Image>().color = new Color32(0, 100, 0, 100);
    }


}
