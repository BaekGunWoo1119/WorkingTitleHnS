using UnityEngine;
using UnityEngine.UI;

public class ClassHandler : MonoBehaviour
{
    public Button classButton; // Inspector에서 해당 버튼을 할당

    void Start()
    {
        if (classButton != null)
        {
            string buttonObjectName = classButton.gameObject.name;

            // 버튼이 클릭될 때 해당 버튼의 이름을 SceneDataHandler에 저장
            classButton.onClick.AddListener(() =>
            {
                SceneDataHandler.SaveButtonObjectName(buttonObjectName);
            });
        }
        else
        {
            Debug.LogError("Button reference is not assigned!");
        }
    }
}

public static class SceneDataHandler
{
    private static string buttonObjectName; // 버튼 오브젝트의 이름을 저장할 변수

    // 버튼 오브젝트의 이름을 저장
    public static void SaveButtonObjectName(string name)
    {
        buttonObjectName = name;
    }

    // 버튼 오브젝트의 이름 불러오기
    public static string LoadButtonObjectName()
    {
        return buttonObjectName;
    }
}