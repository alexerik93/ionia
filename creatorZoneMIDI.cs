using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatorZoneMIDI : MonoBehaviour
{
    public AudioHelm.HelmController helmController;
    public AudioHelm.Sequencer sequencer;
    public GameObject translator;
    public int chord;
    public int key;
    public GameObject songMidi;

    // Start is called before the first frame update
    void Start()
    {
        helmController.SetPolyphony(5);
    }

    public void playChord(int chord, bool seventh, bool majMinFlip){
        songMidi.GetComponent<songMIDI>().pause();
        helmController.AllNotesOff();
        int note1 = translator.GetComponent<musicTheoryTranslator>().getChordNote(chord, 1, majMinFlip);
        int note3 = translator.GetComponent<musicTheoryTranslator>().getChordNote(chord, 3, majMinFlip);
        int note5 = translator.GetComponent<musicTheoryTranslator>().getChordNote(chord, 5, majMinFlip);
        int note7 = translator.GetComponent<musicTheoryTranslator>().getChordNote(chord, 7, majMinFlip);
        int keyOctave = translator.GetComponent<musicTheoryTranslator>().getKeyOctave();
        if (chord == 1 && seventh == false){
            helmController.NoteOn(note1, 1.0f, 2);
            helmController.NoteOn(note1 + 12, 1.0f, 2);
            helmController.NoteOn(note3 + 12, 1.0f, 2);
            helmController.NoteOn(note5, 1.0f, 2);
        }
        else if (chord != 1 && seventh == false){
            helmController.NoteOn(note1, 1.0f, 2);
            helmController.NoteOn(note1 + 12, 1.0f, 2);
            helmController.NoteOn(note3 + 12, 1.0f, 2);
            helmController.NoteOn(note5, 1.0f, 2);      
        }
        else {
            helmController.NoteOn(note1, 1.0f, 2);
            helmController.NoteOn(note3 + 12, 1.0f, 2);
            helmController.NoteOn(note5, 1.0f, 2);
            helmController.NoteOn(note7, 1.0f, 2);            
        }
    }
}
