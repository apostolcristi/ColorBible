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

    public Sprite on;
    public Sprite off;
    
    void Start()
    {
        
        musicOn = PlayerPrefs.GetInt("musicOn")==1 ? false : true;
        soundEffectsOn = PlayerPrefs.GetInt("soundEffectsOn") == 1 ? false : true;
        
      
        
    }

    
    void Update()
    {
        if (musicOn)
        {
            onOffButtons[0].GetComponent<Image>().sprite = on;
        }
        else
        {
            onOffButtons[0].GetComponent<Image>().sprite = off;
        }

        if (soundEffectsOn)
        {
            onOffButtons[1].GetComponent<Image>().sprite = on;
        }
        else
        {
            onOffButtons[1].GetComponent<Image>().sprite = off;
        }
    }

    public void Music()
    {
        musicOn = !musicOn;
        PlayerPrefs.SetInt("musicOn", musicOn?0:1);
    }

    public void SoundEffects()
    {
        soundEffectsOn = !soundEffectsOn;
        PlayerPrefs.SetInt("soundEffectsOn", soundEffectsOn?0:1);
    }
}
