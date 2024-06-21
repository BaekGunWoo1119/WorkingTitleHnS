using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICamera : MonoBehaviour
{
    public Camera mainCamera; // 표시할 카메라
    public RawImage canvasImage; // 카메라 화면을 표시할 Canvas의 RawImage

    private RenderTexture renderTexture;

    void Start()
    {
        // RenderTexture 생성
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mainCamera.targetTexture = renderTexture;

        // Canvas의 RawImage에 텍스처 설정
        canvasImage.texture = renderTexture;
    }

    void Update()
    {
        
    }
}