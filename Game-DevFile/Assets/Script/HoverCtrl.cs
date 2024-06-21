using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageHoverCtrl : MonoBehaviour
{
    public GameObject activeObj; // Ȱ��ȭ ��ų ������Ʈ
    private Image imageComponent; // ��� �ؽ�Ʈ
    private Vector3 originalScale; // ������Ʈ�� ���� ������

    void Start()
    {
        originalScale = activeObj.transform.localScale;
        activeObj.transform.localScale = new Vector3(0, 0, 0);
        // Image ������Ʈ�� ������
        imageComponent = GetComponent<Image>();

        // EventTrigger ������Ʈ �߰�
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();

        // PointerEnter �̺�Ʈ �߰�
        EventTrigger.Entry entryEnter = new EventTrigger.Entry();
        entryEnter.eventID = EventTriggerType.PointerEnter;
        entryEnter.callback.AddListener((data) => { OnPointerEnter(); });
        trigger.triggers.Add(entryEnter);

        // PointerExit �̺�Ʈ �߰�
        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((data) => { OnPointerExit(); });
        trigger.triggers.Add(entryExit);
    }

    // ���콺�� �÷��� ��
    public void OnPointerEnter()
    {
        activeObj.transform.localScale = originalScale; // ���� �����Ϸ� �ǵ���
    }

    // ���콺�� ������ ��
    public void OnPointerExit()
    {
        activeObj.transform.localScale = new Vector3(0, 0, 0); // ������ 0 ó��
    }
}
