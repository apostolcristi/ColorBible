using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Toast : MonoBehaviour
{
    public GameObject a;
    public TextMeshProUGUI txt;

    private void Start()
    {
      a.SetActive(false);
    }

    public void showToast(string text,
        int duration)
    {
    
        StartCoroutine(showToastCOR(text, duration));
       
    }

    private IEnumerator showToastCOR(string text,
        int duration)
    {
        a.SetActive(true);
        Color orginalColor = txt.color;

        txt.text = text;
        txt.enabled = true;

        //Fade in
        yield return fadeInAndOut(txt, true, 0.5f);

        //Wait for the duration
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Fade out
        yield return fadeInAndOut(txt, false, 0.5f);
        a.SetActive(false);
        txt.enabled = false;
        txt.color = orginalColor;
    }

    IEnumerator fadeInAndOut(TextMeshProUGUI targetText, bool fadeIn, float duration)
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }

        Color currentColor = Color.clear;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }
}
