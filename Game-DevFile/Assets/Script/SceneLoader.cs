using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Button specificButton; // Ư�� Button�� �������ּ���
    public string sceneName; // �̵��� Scene�� �̸��� �������ּ���

    void Start()
    {
        if (specificButton != null)
        {
            specificButton.onClick.AddListener(LoadTargetScene);
        }
        else
        {
            Debug.LogError("specificButton is not assigned!");
        }
    }

    void LoadTargetScene()
    {
        // Scene�� �񵿱������� �ε��մϴ�.
        SceneManager.LoadScene(sceneName);
    }
}