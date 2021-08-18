using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicTheoryTranslator : MonoBehaviour
{
    public int globalKey = 60;
    public GameObject keySelector;

    private List<string> sharpNames = new List<string>();
    private List<string> flatNames = new List<string>();

    void Awake(){
        sharpNames.Add("C");
        sharpNames.Add("C#");
        sharpNames.Add("D");
        sharpNames.Add("D#");
        sharpNames.Add("E");
        sharpNames.Add("F");
        sharpNames.Add("F#");
        sharpNames.Add("G");
        sharpNames.Add("G#");
        sharpNames.Add("A");
        sharpNames.Add("A#");
        sharpNames.Add("B");
        flatNames.Add("C");
        flatNames.Add("Db");
        flatNames.Add("D");
        flatNames.Add("Eb");
        flatNames.Add("E");
        flatNames.Add("F");
        flatNames.Add("Gb");
        flatNames.Add("G");
        flatNames.Add("Ab");
        flatNames.Add("A");
        flatNames.Add("Bb");
        flatNames.Add("B");
    }

    public void setGlobalkey(){
        int value = keySelector.GetComponent<Dropdown>().value;
        switch (value){
            case 0: 
            globalKey = 48;
            break;
            case 1: 
            globalKey = 50;
            break;
            case 2: 
            globalKey = 52;
            break;
            case 3: 
            globalKey = 53;
            break;
            case 4: 
            globalKey = 55;
            break;
            case 5: 
            globalKey = 45;
            break;
            case 6: 
            globalKey = 47;
            break;
        }
    }

    public int chordToRootIndex(int chord){
        List<int> notes = new List<int>();
        int result;
        notes.Add(0);
        notes.Add(2);
        notes.Add(4);
        notes.Add(5);
        notes.Add(7);
        notes.Add(9);
        notes.Add(11);
        if (chord == 0){
            result = 0;
        }
        else result = notes[chord - 1];
        return result;
    }

    public int getKeyOctave(){
        return globalKey + 12;
    }

    public int getChordNote(int chord, int position, bool majMinFlip){
        int result = 0;
        if (position == 5){
            result = globalKey + chordToRootIndex(chord) + 7;
        }
        else if (position == 1){
            result = globalKey + chordToRootIndex(chord);
        }
        else if (position == 3){
            if(chord == 1 || chord == 4 || chord == 5){
                if (majMinFlip == true){
                    result = globalKey + chordToRootIndex(chord) + 3;
                }
                else result = globalKey + chordToRootIndex(chord) + 4;
            }
            else {
                if (majMinFlip == true){
                    result = globalKey + chordToRootIndex(chord) + 4;
                }
                else result = globalKey + chordToRootIndex(chord) + 3;
            }
        }
        else if (position == 7){
            if (chord == 1 || chord == 4){
                result = globalKey + chordToRootIndex(chord) + 11;
            }
            else result = globalKey + chordToRootIndex(chord) + 10;
        }
        return result;
    }

    public bool flatKey(){
        int i = globalKey % 12;
        if (i == 1 || i == 7 || i == 2 || i == 9 || i == 4 || i == 11 || i == 6){
            return false;
        }
        else return true;
    }

    public string getNoteName(int midiNote, bool flatKey){
        string name;
        int i = midiNote % 12;
        if (flatKey == false){
            name = sharpNames[i];
        }
        else name = flatNames[i];
        return name;
    }

    public string getChordName(int chord, bool seventh, bool majMinFlip){
        string name;
        int note = getChordNote(chord, 1, false);
        name = getNoteName(note, flatKey());
        if (seventh == false && majMinFlip == false){
            if (chord == 1 || chord == 4 || chord == 5){
                return name;
            }
            else {
                name = name + " Minor";
                return name;
            }
        }
        else if (majMinFlip == true && seventh == false){
            if (chord == 1 || chord == 4 || chord == 5){
                name = name + " Minor";
                return name;
            }
            else return name;
        }
        else if (seventh == true && majMinFlip == false){
            if (chord == 1 || chord == 4){
                name = name + " Major 7th";
                return name;
            }
            else if (chord == 2 || chord == 3 || chord == 6){
                name = name + " Minor 7th";
                return name;
            }
            else {
                name = name + " 7th";
                return name;
            }
        }
        else {
            if (chord == 1 || chord == 4){
                name = name + " Minor Major 7th";
                return name;
            }
            else if (chord == 2 || chord == 3 || chord == 6){
                name = name + " 7th";
                return name;
            }
            else {
                name = name + " Minor 7th";
                return name;
            }
        }
    }
}
