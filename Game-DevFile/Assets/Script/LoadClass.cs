using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadClass : MonoBehaviour
{
    public GameObject warrior;
    public GameObject assassin;
    public GameObject archer;
    public GameObject wizard;

    public Sprite warriorImg;
    public Sprite assassinImg;
    public Sprite archerImg;
    public Sprite wizardImg;
    public Image charImg;

    void Start()
    {
        // SceneDataHandler에서 저장된 버튼 이름 불러오기
        string className = SceneDataHandler.LoadButtonObjectName();

        if (className == "Warrior")
        {
            warrior.SetActive(true);
            assassin.SetActive(false);
            archer.SetActive(false);
            wizard.SetActive(false);
            charImg.sprite = warriorImg;

        }
        else if (className == "Assassin")
        {
            warrior.SetActive(false);
            assassin.SetActive(true);
            archer.SetActive(false);
            wizard.SetActive(false);
            charImg.sprite = assassinImg;
        }
        else if (className == "Archer")
        {
            warrior.SetActive(false);
            assassin.SetActive(false);
            archer.SetActive(true);
            wizard.SetActive(false);
            charImg.sprite = archerImg;
        }
        else if (className == "Wizard")
        {
            warrior.SetActive(false);
            assassin.SetActive(false);
            archer.SetActive(false);
            wizard.SetActive(true);
            charImg.sprite = wizardImg;
        }
    }
}
