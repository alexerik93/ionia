using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class songController : MonoBehaviour
{

    public List<int> chords;
    public List<bool> sevenths;
    public List<bool> majMinFlips;

    public List<GameObject> chordSources;

    void Awake(){
        for (int i = 0; i<8; i++){
            chords.Add(0);
            sevenths.Add(false);
            majMinFlips.Add(false);
        }
    }

    public void refreshSongChords(){
        for(int i = 0; i<8; i++){
            chords[i] = chordSources[i].GetComponent<chordDetailsController>().chord;
            sevenths[i] = chordSources[i].GetComponent<chordDetailsController>().seventh;
            majMinFlips[i] = chordSources[i].GetComponent<chordDetailsController>().majMinFlip;
            chordSources[i].GetComponent<chordDetailsController>().updateText();
        }
    }
}
