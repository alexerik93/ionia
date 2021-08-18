using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordUIController : MonoBehaviour
{
    public GameObject chordPlayer;
    public bool majMinFlip;
    public bool seventh;
    public List<bool> chordActive;

    void Awake(){
        chordActive.Add(true);
        for (int i = 1; i<6; i++){
            chordActive.Add(false);
        }
        majMinFlip = false;
        seventh = false;
    }
    public bool anyChordActive(){
        bool active = false;
        for (int i = 0; i<6; i++){
            if (chordActive[i] == true){
                active = true;
            }
        }
        return active;
    }
    public int getChord(){
        int result = 0;
        if (anyChordActive() == false){
            result = 0;
        }
        else{
            bool found = false;
            int i = 0;
            while (found == false){
                if (chordActive[i] == true){
                    found = true;
                    result = i +1;
                }
                else {
                    i++;
                }
            }
        }
        return result;
    }

    public void toggleChordActive(int selection){
        for (int i = 0; i<selection; i++){
            chordActive[i] = false;
        }
        chordActive[selection] = true;
        for (int j = selection+1; j<6; j++){
            chordActive[j] = false;
        }
        chordPlayer.GetComponent<creatorZoneMIDI>().playChord(selection + 1, seventh, majMinFlip);
    }

    public void toggleMajMin(){
        majMinFlip = !majMinFlip;
    }
    public void toggleSeventh(){
        seventh = !seventh;
    }
}
