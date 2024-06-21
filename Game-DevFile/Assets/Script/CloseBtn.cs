using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BtnUnsetActive : MonoBehaviour
{
    public GameObject activeObj; // Ȱ��ȭ�� ������Ʈ
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(UnsetActiveObj);
        }
    }

    // ��ư Ŭ��
    private void UnsetActiveObj()
    {
        if (activeObj != null)
        {
            Debug.Log("��ưŬ��");
            // ������Ʈ�� �������� 0���� ����
            activeObj.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    // �� ��ũ��Ʈ�� ��Ȱ��ȭ�� �� ȣ��Ǵ� �Լ�
    private void OnDestroy()
    {
        if (button != null)
        {
            // ������ �̺�Ʈ �����ʸ� ����
            button.onClick.RemoveListener(UnsetActiveObj);
        }
    }
}