using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Button specificButton; // 특정 Button을 지정해주세요
    public string sceneName; // 이동할 Scene의 이름을 지정해주세요

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
        // Scene을 비동기적으로 로드합니다.
        SceneManager.LoadScene(sceneName);
    }
}