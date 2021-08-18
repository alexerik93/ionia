using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isPlayingColour : MonoBehaviour
{
    public GameObject songMIDI;
    public bool songPlaying;
    public Image image;

    void Awake(){
        image = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        songPlaying = songMIDI.GetComponent<songMIDI>().songPlaying;
        switch(songPlaying){
            case true:
            image.color = new Color32(0,143,255,255);
            break;
            case false:
            image.color = new Color32(100,100,100,50);
            break;
        }
    }
}
