using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnSetActive : MonoBehaviour
{
    public GameObject activeObj; // Ȱ��ȭ�� ������Ʈ
    private Vector3 originalScale;
    private Button button;

    private void Start()
    {
        // ������Ʈ�� ������ ����
        if (activeObj != null)
        {
            originalScale = activeObj.transform.localScale;
            activeObj.transform.localScale = new Vector3(0, 0, 0);
        }

        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(SetActiveObj);
        }
    }

    // ��ư Ŭ��
    private void SetActiveObj()
    {
        if (activeObj != null)
        {
            // ������Ʈ�� �������� �ʱ� �����Ϸ� ����
            activeObj.transform.localScale = originalScale;
        }
    }

    // �� ��ũ��Ʈ�� ��Ȱ��ȭ�� �� ȣ��Ǵ� �Լ�
    private void OnDestroy()
    {
        if (button != null)
        {
            // ������ �̺�Ʈ �����ʸ� ����
            button.onClick.RemoveListener(SetActiveObj);
        }
    }
}
