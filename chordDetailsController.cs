using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chordDetailsController : MonoBehaviour
{
    public GameObject chordInfoSource;
    public GameObject infoBox;
    public GameObject textBox;
    public GameObject songController;
    public GameObject creatorPlayer;
    public GameObject songMidi;
    public GameObject chordPositionBox;

    public int bar = 1;
    public int chord = 1;
    public bool seventh = false;
    public bool majMinFlip = false;

    void Awake(){
        infoBox.SetActive(false);
        chord = 0;
    }
    
    public void getChordDetails(){
        if (chordInfoSource.GetComponent<ChordUIController>().anyChordActive() == true){
            chord = chordInfoSource.GetComponent<ChordUIController>().getChord();
            Debug.Log("Added Chord " + chord);
            seventh = chordInfoSource.GetComponent<ChordUIController>().seventh;
            majMinFlip = chordInfoSource.GetComponent<ChordUIController>().majMinFlip;
        }
    }

    public void updateText(){
        textBox.GetComponent<chordNameController>().updateText();
    }

    public void updatePositionText(){
        chordPositionBox.GetComponent<chordPositionNameController>().updateText();
    }

    void updateSongChords(){
        songController.GetComponent<songController>().refreshSongChords();
    }

    public void switchOn(){
        songMidi.GetComponent<songMIDI>().pause();
        infoBox.SetActive(true);
        getChordDetails();
        updateText();
        updatePositionText();
        updateSongChords();
    }

    public void switchOnOrWait(){
        if (chord == 0){
            switchOn();
        }
    }

    public void switchOff(){
        songMidi.GetComponent<songMIDI>().pause();
        chord = 0;
        seventh = false;
        majMinFlip = false;
        updateSongChords();
        infoBox.SetActive(false);
    }
}
