using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chordPositionNameController : MonoBehaviour
{
    public GameObject chordDetailsController;
    private int chord; 
    private string text;

    public void updateText(){
        chord = chordDetailsController.GetComponent<chordDetailsController>().chord;
        switch(chord){
            case 1:
            text = "I";
            break;
            case 2:
            text = "II";
            break;
            case 3:
            text = "III";
            break;
            case 4:
            text = "IV";
            break;
            case 5:
            text = "V";
            break;
            case 6:
            text = "VI";
            break;
        }
        gameObject.GetComponent<Text>().text = text;
    }
}
