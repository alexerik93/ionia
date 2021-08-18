 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chordPlayingHighlights : MonoBehaviour
{
    public AudioHelm.Sequencer sequencer;
    public List<GameObject> highlighters;
    public GameObject songMIDI;

    private void highlightChord(int beat){
        int chord = beat / 8;
        for (int i = 0; i < 8; i ++){
            highlighters[i].SetActive(false);
        }
        highlighters[chord].SetActive(true);
    }

    private void clearHighlights(){
        for (int i = 0; i < 8; i ++){
            highlighters[i].SetActive(false);
        }
    }


    void Update(){
        if (songMIDI.GetComponent<songMIDI>().songPlaying == true){
            int beat= System.Convert.ToInt32(System.Math.Floor(sequencer.GetSequencerPosition()));
            highlightChord(beat);
        }
        else clearHighlights();
    }
}
