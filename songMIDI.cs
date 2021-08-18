using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songMIDI : MonoBehaviour
{
    public int globalKey;
    public GameObject musicTheoryTranslator;
    public AudioHelm.Sequencer sequencer;
    public GameObject songInformation;
    public GameObject sequencerToggle;
    public AudioHelm.AudioHelmClock clock;
    public GameObject drumsActivator;
    public bool songPlaying = false;

    void Awake(){
        globalKey = musicTheoryTranslator.GetComponent<musicTheoryTranslator>().globalKey;
        sequencer.length = 64;
        sequencer.Clear();
    }

    public void pause(){
        songPlaying = false;
        drumsActivator.GetComponent<drumsActivator>().stopDrums();
        sequencer.Clear();
        clock.Reset();
        sequencerToggle.SetActive(false);
    }

    public void playOrPause(){
        sequencer.Clear();
        switch(songPlaying){
            case false:
                songPlaying = true;
                for (int i = 0; i<8; i++){
                    int start = i * 8; 
                    int end = i * 8 + 8;
                    int chord = songInformation.GetComponent<songController>().chords[i];
                    if (chord != 0){
                        bool seventh = songInformation.GetComponent<songController>().sevenths[i];
                        bool majMinFlip = songInformation.GetComponent<songController>().majMinFlips[i];
                        int note1 = musicTheoryTranslator.GetComponent<musicTheoryTranslator>().getChordNote(chord, 1, majMinFlip);
                        int note3 = musicTheoryTranslator.GetComponent<musicTheoryTranslator>().getChordNote(chord, 3, majMinFlip);
                        int note5 = musicTheoryTranslator.GetComponent<musicTheoryTranslator>().getChordNote(chord, 5, majMinFlip);
                        int note7 = musicTheoryTranslator.GetComponent<musicTheoryTranslator>().getChordNote(chord, 7, majMinFlip);
                        int keyOctave = musicTheoryTranslator.GetComponent<musicTheoryTranslator>().getKeyOctave();
                        if (chord == 1 && seventh == false){
                            sequencer.AddNote(note1, start, end, 1.0f);
                            sequencer.AddNote(note1 + 12, start, end, 1.0f);
                            sequencer.AddNote(note3 + 12, start, end, 1.0f);
                            sequencer.AddNote(note5, start, end, 1.0f);

                        }
                        else if (seventh == false){
                            sequencer.AddNote(note1, start, end, 1.0f);
                            sequencer.AddNote(note1 + 12, start, end, 1.0f);
                            sequencer.AddNote(note3 + 12, start, end, 1.0f);
                            sequencer.AddNote(note5, start, end, 1.0f);
                        }
                        else {
                            sequencer.AddNote(note1, start, end, 1.0f);
                            sequencer.AddNote(note3 + 12, start, end, 1.0f);
                            sequencer.AddNote(note5, start, end, 1.0f); 
                            sequencer.AddNote(note7, start, end, 1.0f);                
                        }
                    }
                }
                clock.Reset();
                sequencerToggle.SetActive(true);
                drumsActivator.GetComponent<drumsActivator>().playDrums();
                break;
            case true:
            songPlaying = false;
            sequencer.Clear();
            sequencerToggle.SetActive(false);
            drumsActivator.GetComponent<drumsActivator>().stopDrums();
            break;
        }
    }
}
