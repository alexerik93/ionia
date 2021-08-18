using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chordNameController : MonoBehaviour
{
    public GameObject chordDetails;
    public GameObject musicTheoryTranslator;
    int chord; 
    bool seventh;
    bool majMinFlip;

    public void updateText(){
        string chordName;
        chord = chordDetails.GetComponent<chordDetailsController>().chord;
        seventh = chordDetails.GetComponent<chordDetailsController>().seventh;
        majMinFlip = chordDetails.GetComponent<chordDetailsController>().majMinFlip;
        chordName = musicTheoryTranslator.GetComponent<musicTheoryTranslator>().getChordName(chord, seventh, majMinFlip);
        gameObject.GetComponent<Text>().text = chordName;
    }
}
