using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICamera : MonoBehaviour
{
    public Camera mainCamera; // ǥ���� ī�޶�
    public RawImage canvasImage; // ī�޶� ȭ���� ǥ���� Canvas�� RawImage

    private RenderTexture renderTexture;

    void Start()
    {
        // RenderTexture ����
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mainCamera.targetTexture = renderTexture;

        // Canvas�� RawImage�� �ؽ�ó ����
        canvasImage.texture = renderTexture;
    }

    void Update()
    {
        
    }
}