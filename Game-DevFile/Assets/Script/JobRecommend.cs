using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobRecommend : MonoBehaviour
{
    public TMP_Text textToRec1;
    public TMP_Text textToRec2;
    public TMP_Text textToRec3;
    public TMP_Text textToRec4;

    void Start()
    {
        int selectedGroupIndex = PlayerPrefs.GetInt("SelectedGroupIndex", -1);

        if (selectedGroupIndex != -1)
        {
            ChangeTextColor(selectedGroupIndex);
        }
        else
        {
            Debug.LogWarning("SelectedGroupIndex not found!");
        }
    }

    void ChangeTextColor(int selectedGroupIndex)
    {
        //MBTI에 따라 추천 표시
        switch (selectedGroupIndex)
        {
            case 0:
                textToRec1.color = Color.yellow;
                break;
            case 1:
                textToRec2.color = Color.yellow;
                break;
            case 2:
                textToRec3.color = Color.yellow;
                break;
            case 3:
                textToRec4.color = Color.yellow;
                break;
            default:
                break;
        }
    }
}