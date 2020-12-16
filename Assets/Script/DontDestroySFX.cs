using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySFX : MonoBehaviour
{
    private AudioClip audioClip;
    private bool soundEffectsOn;
    
    public void ButtonPress()
    {
      soundEffectsOn = PlayerPrefs.GetInt("soundEffectsOn") == 1 ? true : false;
      if (soundEffectsOn)
      {
          gameObject.GetComponent<AudioSource>().mute = false;
          gameObject.GetComponent<AudioSource>().Play();
          Debug.Log("ok");
      
      }
      else
      {
          gameObject.GetComponent<AudioSource>().mute = true;
      }
    
        
    }
}

   
