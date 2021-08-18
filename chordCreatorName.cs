using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chordCreatorName : MonoBehaviour
{
    public GameObject chordDetails;
    public GameObject musicTheoryTranslator;
    int chord = 1;
    bool seventh = false;
    bool majMinFlip = false;

    void Awake(){
        int key = musicTheoryTranslator.GetComponent<musicTheoryTranslator>().getKeyOctave();
        gameObject.GetComponent<Text>().text = musicTheoryTranslator.GetComponent<musicTheoryTranslator>().getChordName(key, false, false);
    }

    public void updateText(){
        string chordName;
        for (int i = 0; i< 6; i++){
            if (chordDetails.GetComponent<ChordUIController>().chordActive[i] == true){
                chord = i+1;
            }
        }
        seventh = chordDetails.GetComponent<ChordUIController>().seventh;
        majMinFlip = chordDetails.GetComponent<ChordUIController>().majMinFlip;
        chordName = musicTheoryTranslator.GetComponent<musicTheoryTranslator>().getChordName(chord, seventh, majMinFlip);
        gameObject.GetComponent<Text>().text = chordName;
    }
}
