using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HyperLink : MonoBehaviour
{
    public bool allowed=true;
   

    
    
    private void Update()
    {
        
        if(allowed)
            StartCoroutine("pulsing");
        
    }


    private IEnumerator pulsing()
    {
        
        allowed = false;
        for (float i = 0.1f; i <= 0.2f; i += 0.005f)
        {
            transform.localScale = new Vector2(
                Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.025f, Mathf.SmoothStep(0f, 1f, i)),
                Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.025f, Mathf.SmoothStep(0f, 1f, i)));
            yield return new WaitForSeconds(0.05f);
        }
        for (float i = 0.1f; i <= 0.2f; i += 0.005f)
        {
            transform.localScale = new Vector2(
                Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.025f, Mathf.SmoothStep(0f, 1f, i)),
                Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.025f, Mathf.SmoothStep(0f, 1f, i)));
            yield return new WaitForSeconds(0.05f);
        }

        allowed = true;
    }


   public void URL()
    {
        Application.OpenURL("https://funbible.net/home?ref=colorbible");
    }
}
