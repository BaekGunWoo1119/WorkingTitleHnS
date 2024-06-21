using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MBTIManager : MonoBehaviour
{
    private float energyValue;
    private float inputValue;
    private float judgeValue;
    private float doingValue;

    private string energy;
    private string input;
    private string judge;
    private string doing;

    public TMP_Text mbtiText;
    // Start is called before the first frame update
    void Start()
    {
        energyValue = PlayerPrefs.GetFloat("���������");
        inputValue = PlayerPrefs.GetFloat("�νı��");
        judgeValue = PlayerPrefs.GetFloat("�Ǵܱ��");
        doingValue = PlayerPrefs.GetFloat("������");
        Debug.Log(energyValue);
        Debug.Log(inputValue);
        Debug.Log(judgeValue);
        Debug.Log(doingValue);
        MBTISelect();
    }

    private void MBTISelect()
    {
        if(energyValue < 0.5)
        {
            energy = "I";
        }
        else
        {
            energy = "E";
        }

        if (inputValue < 0.5)
        {
            input = "N";
        }
        else
        {
            input = "S";
        }

        if (judgeValue < 0.5)
        {
            judge = "F";
        }
        else
        {
            judge = "T";
        }

        if (doingValue < 0.5)
        {
            doing = "P";
        }
        else
        {
            doing = "J";
        }
        
        mbtiText.text = energy + input + judge + doing;

        if(energyValue >= 0.5 && doingValue >= 0.5) 
        {
            PlayerPrefs.SetInt("SelectedGroupIndex", 0);
        }
        else if(energyValue >= 0.5 && doingValue < 0.5)
        {
            PlayerPrefs.SetInt("SelectedGroupIndex", 1);
        }
        else if(energyValue < 0.5 && doingValue >= 0.5)
        {
            PlayerPrefs.SetInt("SelectedGroupIndex", 3);
        }
        else
        {
            PlayerPrefs.SetInt("SelectedGroupIndex", 2);
        }
    }
}
