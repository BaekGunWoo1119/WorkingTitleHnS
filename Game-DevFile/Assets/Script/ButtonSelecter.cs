using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ButtonSelector : MonoBehaviour
{
    public List<Button> buttonGroups; // ��ư ����Ʈ
    public string sceneName;

    void Start()
    {
        // ��ư�� ���� Ŭ�� �̺�Ʈ ������ �߰�
        for (int i = 0; i < buttonGroups.Count; i++)
        {
            int groupIndex = i; // Ŭ���� ������ �ε��� ����
            buttonGroups[i].onClick.AddListener(() => OnGroupButtonClick(groupIndex));
        }
    }

    void OnGroupButtonClick(int clickedGroupIndex)
    {
        // Ŭ���� �׷� ������ �����ϰų� ���� Scene���� ����
        Debug.Log("Selected Group: " + clickedGroupIndex);
        PlayerPrefs.SetInt("SelectedGroupIndex", clickedGroupIndex);
        SceneManager.LoadScene(sceneName);
    }
}