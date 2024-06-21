using UnityEngine;
using UnityEngine.UI;

public class ClassHandler : MonoBehaviour
{
    public Button classButton; // Inspector���� �ش� ��ư�� �Ҵ�

    void Start()
    {
        if (classButton != null)
        {
            string buttonObjectName = classButton.gameObject.name;

            // ��ư�� Ŭ���� �� �ش� ��ư�� �̸��� SceneDataHandler�� ����
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
    private static string buttonObjectName; // ��ư ������Ʈ�� �̸��� ������ ����

    // ��ư ������Ʈ�� �̸��� ����
    public static void SaveButtonObjectName(string name)
    {
        buttonObjectName = name;
    }

    // ��ư ������Ʈ�� �̸� �ҷ�����
    public static string LoadButtonObjectName()
    {
        return buttonObjectName;
    }
}