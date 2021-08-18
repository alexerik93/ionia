using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class synthSoundController : MonoBehaviour
{
    public AudioHelm.HelmController helmController;
    public GameObject toggle;
    public AudioHelm.HelmPatch patchObject;
    public AudioHelm.HelmPatch patchObject2;
    public AudioHelm.HelmPatch patchObject3;
    public AudioHelm.HelmPatch patchObject4;
    public AudioHelm.HelmPatch patchObject5;
    public GameObject songController;

    void Awake(){
        helmController.AllNotesOff();
        helmController.LoadPatch(patchObject); 
    }

    public void setHelmPatch(){
        helmController.AllNotesOff();
        songController.GetComponent<songMIDI>().pause();
        int value = toggle.GetComponent<Dropdown>().value;
        switch(value){
            case 0:
            helmController.LoadPatch(patchObject); 
            break;
            case 1:
            helmController.LoadPatch(patchObject2); 
            break;
            case 2: 
            helmController.LoadPatch(patchObject3); 
            break;
            case 3: 
            helmController.LoadPatch(patchObject4); 
            break;
            case 4:
            helmController.LoadPatch(patchObject5); 
            break;
        }   
    }
}
