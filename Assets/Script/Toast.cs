using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Toast : MonoBehaviour
{
    public GameObject restore;


    private void Start()
    {
#if UNITY_EDITOR
        restore.SetActive(false);
#endif
    }
}
