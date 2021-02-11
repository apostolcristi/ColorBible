using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Security : MonoBehaviour
{
    public TextMeshProUGUI firstNumText, secNumText;
    public TMP_InputField resultField;
    public GameObject yes;
    public TextMeshProUGUI operation;
    private int firstNum, secNum;
    private int result;
    private int sumOrSubstrac=-1;

    private void Start()
    {
        Verify();
    }

    private void Update()
    {
    
        if (!resultField.text.Equals("?"))
        {
            int resultInput;
            int.TryParse(resultField.text,out resultInput);
            if (result == resultInput)
            {
                yes.SetActive(true);
            }
            else
            {
                yes.SetActive(false);
            }
        }
    
    }

    void Verify()
    {
        firstNum = Random.Range(4, 100);
        secNum = Random.Range(4, 100);
        sumOrSubstrac = Random.Range(0,2);
        if (sumOrSubstrac == 1)
        {
            result = firstNum + secNum;
            operation.text = "+";
        }
        else if(sumOrSubstrac ==0)
        {
            if (firstNum < secNum)
            {
                int aux = firstNum;
                firstNum = secNum;
                secNum = aux;
                result = firstNum - secNum;
            }
            else if (firstNum == secNum)
            {
                firstNum += 15;
                result = firstNum - secNum;
            }
            else
            {
                result = firstNum - secNum;
            }
            operation.text = "-";
        }
        
        firstNumText.text = firstNum.ToString();
        secNumText.text = secNum.ToString();
        yes.SetActive(false);
    }
}
