using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.ComponentModel;

public class TabBtn : MonoBehaviour
{
    public Button button; // �ǹ�ư
    public GameObject innerImg;
    public Color fireColor; 
    public Color iceColor;
    public Sprite fireImage;
    public Sprite iceImage;

    void Start()
    {
        
    }

    private void SetFire() 
    {
        if (button != null)
        {
            Debug.Log("�ҷ� ����");
            ColorBlock colors = button.colors;
            colors.normalColor = fireColor;
            button.colors = colors;
            Image btnImage = innerImg.GetComponent<Image>();
            btnImage.sprite = fireImage;
            button.onClick.RemoveListener(SetFire);
        }
    }

    private void SetIce()
    {
        if (button != null)
        {
            Debug.Log("�������� ����");
            ColorBlock colors = button.colors;
            colors.normalColor = iceColor;
            button.colors = colors;
            Image btnImage = innerImg.GetComponent<Image>();
            btnImage.sprite = iceImage;
            button.onClick.RemoveListener(SetIce);
        }
    }
    void Update()
    {
        ColorBlock colors = button.colors;
        Color normalColor = colors.normalColor;
        if (button != null)
        {
            if (normalColor == iceColor)
            {
                button.onClick.AddListener(SetFire);
            }
            else if (normalColor == fireColor)
            {
                button.onClick.AddListener(SetIce);
            }
            else
            {
                normalColor = iceColor;
                button.onClick.AddListener(SetFire);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) && button != null)
        {
            button.onClick.Invoke();
        }
        /* UI ��ҿ� ����Ʈ �߻�
        if (Input.GetKeyDown(KeyCode.Tab) && tabBtn != null)
        {
            // ����Ʈ�� �߻���ų ��ġ�� �����ɴϴ�.
            Vector3 effectPosition = tabBtn.transform.position;

            // UI ��ҿ� ���콺 Enter �̺�Ʈ�� �߻���ŵ�ϴ�.
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = effectPosition;

            // ����Ʈ�� ��Ÿ������ �ϴ� UI ��ҿ� ���� �̺�Ʈ ȣ��
            ExecuteEvents.Execute(tabBtn, pointerEventData, ExecuteEvents.pointerEnterHandler);
        }
        */
    }
}
