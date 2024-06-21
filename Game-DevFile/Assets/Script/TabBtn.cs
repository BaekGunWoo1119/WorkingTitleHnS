using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.ComponentModel;

public class TabBtn : MonoBehaviour
{
    public Button button; // 탭버튼
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
            Debug.Log("불로 변경");
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
            Debug.Log("얼음으로 변경");
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
        /* UI 요소에 이펙트 발생
        if (Input.GetKeyDown(KeyCode.Tab) && tabBtn != null)
        {
            // 이펙트를 발생시킬 위치를 가져옵니다.
            Vector3 effectPosition = tabBtn.transform.position;

            // UI 요소에 마우스 Enter 이벤트를 발생시킵니다.
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = effectPosition;

            // 이펙트를 나타내고자 하는 UI 요소에 대한 이벤트 호출
            ExecuteEvents.Execute(tabBtn, pointerEventData, ExecuteEvents.pointerEnterHandler);
        }
        */
    }
}
