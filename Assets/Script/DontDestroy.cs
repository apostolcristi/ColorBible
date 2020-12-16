using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private bool musicOn;
    private static DontDestroy instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

   
    }

    private void Update()
    {
            musicOn = PlayerPrefs.GetInt("musicOn")==1?true:false;
        if (musicOn)
        {
            gameObject.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().mute = true;
        }
    }
}
