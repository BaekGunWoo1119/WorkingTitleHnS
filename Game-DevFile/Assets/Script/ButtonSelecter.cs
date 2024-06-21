using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ButtonSelector : MonoBehaviour
{
    public List<Button> buttonGroups; // 버튼 리스트
    public string sceneName;

    void Start()
    {
        // 버튼에 대한 클릭 이벤트 리스너 추가
        for (int i = 0; i < buttonGroups.Count; i++)
        {
            int groupIndex = i; // 클로저 변수로 인덱스 보존
            buttonGroups[i].onClick.AddListener(() => OnGroupButtonClick(groupIndex));
        }
    }

    void OnGroupButtonClick(int clickedGroupIndex)
    {
        // 클릭한 그룹 정보를 저장하거나 다음 Scene으로 전달
        Debug.Log("Selected Group: " + clickedGroupIndex);
        PlayerPrefs.SetInt("SelectedGroupIndex", clickedGroupIndex);
        SceneManager.LoadScene(sceneName);
    }
}