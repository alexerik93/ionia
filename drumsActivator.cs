using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drumsActivator : MonoBehaviour
{
    public GameObject drumSequencer1;
    public GameObject drumSequencer2;
    public GameObject drumSequencer3;
    // public GameObject songController;
    // public GameObject drumSelectorDropdown;
    public GameObject speedSlider;

    public void playDrums(){
        if (speedSlider.GetComponent<Slider>().value > 120){
            drumSequencer2.SetActive(true);
        }
        else {
            drumSequencer1.SetActive(true);
        }
    }

    public void stopDrums(){
        drumSequencer2.SetActive(false);
        drumSequencer1.SetActive(false);
    }
}
