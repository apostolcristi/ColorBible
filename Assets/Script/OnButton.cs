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

    private Color musicColor;
    private Color soundEffectsOnColor;
    
    void Start()
    {
        musicColor = onOffButtons[0].GetComponent<Image>().color;
        soundEffectsOnColor = onOffButtons[1].GetComponent<Image>().color;
        musicOn = PlayerPrefs.GetInt("musicOn")==1?true:false;
        soundEffectsOn = PlayerPrefs.GetInt("soundEffectsOn") == 1 ? true : false;
        
    }

    
    void Update()
    {
        if (musicOn)
        {
            onOffButtons[0].transform.rotation = new Quaternion(0,0,0,0);
            onOffButtons[0].GetComponent<Image>().color = Color.green;
        }
        else
        {
            onOffButtons[0].transform.rotation = new Quaternion(0,0,180,0);
            onOffButtons[0].GetComponent<Image>().color = Color.white;
        }

        if (soundEffectsOn)
        {
            onOffButtons[1].transform.rotation = new Quaternion(0,0,0,0);
            onOffButtons[1].GetComponent<Image>().color = Color.green;
        }
        else
        {
            onOffButtons[1].transform.rotation = new Quaternion(0f,0f,180f,0f);
            onOffButtons[1].GetComponent<Image>().color = Color.white;
        }
    }

    public void Music()
    {
        musicOn = !musicOn;
        PlayerPrefs.SetInt("musicOn", musicOn?1:0);
    }

    public void SoundEffects()
    {
        soundEffectsOn = !soundEffectsOn;
        PlayerPrefs.SetInt("soundEffectsOn", soundEffectsOn?1:0);
    }
}
