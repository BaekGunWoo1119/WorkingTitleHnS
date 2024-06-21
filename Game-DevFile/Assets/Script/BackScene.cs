using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour
{
    string previousSceneName; // ���� Scene�� �̸��� ����

    public Button backButton;
    void Start()
    {
        // ���� Scene�� �̸��� ����
        previousSceneName = PlayerPrefs.GetString("PreviousScene", "DefaultSceneName");

        // ���� Scene�� �̸��� ���� (���� Scene���� ���ư� �� ���)
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);

        if (backButton != null)
        {
            backButton.onClick.AddListener(GoBackToPreviousScene);
        }
    }

    public void GoBackToPreviousScene()
    {
        if (!string.IsNullOrEmpty(previousSceneName))
        {
            SceneManager.LoadScene(previousSceneName);
        }
        else
        {
            Debug.LogWarning("PreviousSceneName is not found or invalid!");
        }
    }
}