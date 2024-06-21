using UnityEngine;
using UnityEngine.UI;

public class BonusState : MonoBehaviour
{
    public Button[] starButtons; // �� ��ư���� �迭�� �������ּ���
    public Button plusButton; // + ��ư�� �������ּ���
    public Button minusButton; // - ��ư�� �������ּ���
    public Sprite filledStarSprite; // ä���� �� �̹����� �������ּ���
    public Sprite emptyStarSprite; // ����ִ� �� �̹����� �������ּ���


    private int selectedStarIndex = -1; // ���õ� ���� �ε���
    private int totalStars = 5; // ���� �� ���� (���÷� 5�� ����)

    void Start()
    {
        EnableStarRating();
        EnablePlusMinusButtons();
    }

    // ���� �ý��� Ȱ��ȭ
    private void EnableStarRating()
    {
        // �� ��ư�鿡 ���� �̺�Ʈ ������ �߰�
        for (int i = 0; i < starButtons.Length; i++)
        {
            int starIndex = i; // Ŭ���� ������ �ε��� ����
            starButtons[i].onClick.AddListener(() => OnStarButtonClick(starIndex));
        }
    }

    // +, - ��ư Ȱ��ȭ
    private void EnablePlusMinusButtons()
    {
        if (plusButton != null)
        {
            plusButton.onClick.AddListener(IncrementStarRating);
        }

        if (minusButton != null)
        {
            minusButton.onClick.AddListener(DecrementStarRating);
        }
    }

    // ���� �ý��� ��Ȱ��ȭ
    private void DisableStarRating()
    {
        // �� ��ư�鿡 ���� �̺�Ʈ ������ ����
        for (int i = 0; i < starButtons.Length; i++)
        {
            starButtons[i].onClick.RemoveAllListeners();
        }
    }

    // +, - ��ư ��Ȱ��ȭ
    private void DisablePlusMinusButtons()
    {
        if (plusButton != null)
        {
            plusButton.onClick.RemoveAllListeners();
        }

        if (minusButton != null)
        {
            minusButton.onClick.RemoveAllListeners();
        }
    }

    // �� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    private void OnStarButtonClick(int clickedStarIndex)
    {
        if (selectedStarIndex == clickedStarIndex)
            return;

        selectedStarIndex = clickedStarIndex;

        for (int i = 0; i <= clickedStarIndex; i++)
        {
            Image starImage = starButtons[i].GetComponent<Image>();
            if (starImage != null)
            {
                starImage.sprite = filledStarSprite;
            }
        }

        for (int i = clickedStarIndex + 1; i < starButtons.Length; i++)
        {
            Image starImage = starButtons[i].GetComponent<Image>();
            if (starImage != null)
            {
                starImage.sprite = emptyStarSprite;
            }
        }
    }

        // + ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    private void IncrementStarRating()
    {
        if (selectedStarIndex < totalStars - 1)
        {
            selectedStarIndex++;
            UpdateStarImages();
        }
    }

    // - ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    private void DecrementStarRating()
    {
        if (selectedStarIndex > -1)
        {
            selectedStarIndex--;
            UpdateStarImages();
        }
    }

    private void UpdateStarImages()
    {
        for (int i = 0; i < starButtons.Length; i++)
        {
            Image starImage = starButtons[i].GetComponent<Image>();
            if (starImage != null)
            {
                if (i <= selectedStarIndex)
                {
                    starImage.sprite = filledStarSprite;
                }
                else
                {
                    starImage.sprite = emptyStarSprite;
                }
            }
        }
    }
}