using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySFX : MonoBehaviour
{

    private bool soundEffectsOn;

    private void Update()
    {
        soundEffectsOn = PlayerPrefs.GetInt("soundEffectsOn") == 1 ? false : true;
    }

    public void ButtonPress()
    {

      if (soundEffectsOn)
      {      gameObject.GetComponent<AudioSource>().Play();
        
      
      }
     }

    
}

   
