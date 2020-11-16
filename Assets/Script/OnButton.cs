using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class OnButton : MonoBehaviour
{
    
    public GameObject[] onOffButtons;
    private bool musicOn=true;
    private bool soundEffectsOn=true;
    
    void Start()
    {
        onOffButtons[0].GetComponent<Image>().color = Color.green;
        onOffButtons[1].GetComponent<Image>().color = Color.green;
    }

    
    void Update()
    {
       
        
        
    }

    public void Music()
    {
        
        musicOn = !musicOn;
        onOffButtons[0].transform.Rotate(0,0,180);
        if (musicOn)
        {
            onOffButtons[0].GetComponent<Image>().color = Color.green;
           
        }
        else
        {
            onOffButtons[0].GetComponent<Image>().color = Color.white;
            
        }

    }

    public void SoundEffects()
    {
        soundEffectsOn = !soundEffectsOn;
        onOffButtons[1].transform.Rotate(0,0,180);
        if (soundEffectsOn)
        {
            onOffButtons[1].GetComponent<Image>().color = Color.green;
           
        }
        else
        {
            onOffButtons[1].GetComponent<Image>().color = Color.white;
            
        }

    }
}
