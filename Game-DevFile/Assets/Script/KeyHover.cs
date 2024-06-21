using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeToggleColor : MonoBehaviour
{
    public Button button; // ������ ������ ��ư
    public Color newColor; // ������ ����
    public KeyCode targetKey; // ���ϴ� Ű
    private Color originalColor; // ���� ����

    private bool isKeyPressed = false;

    void Start()
    {
        ColorBlock colors = button.colors;
        originalColor = colors.normalColor;
    }

    void Update()
    {
        if (Input.GetKeyDown(targetKey) && button != null)
        {
            isKeyPressed = true;
        }
        else if (Input.GetKeyUp(targetKey))
        {
            isKeyPressed = false;
        }

        if (isKeyPressed)
        {
            if (button != null)
            {
                newColor.a = 1f;
                ColorBlock colors = button.colors;
                colors.normalColor = newColor;
                button.colors = colors;
            }
        }
        else
        {
            if (button != null)
            {
                newColor.a = 1f;
                ColorBlock colors = button.colors;
                colors.normalColor = originalColor;
                button.colors = colors;
            }
        }
    }
}
