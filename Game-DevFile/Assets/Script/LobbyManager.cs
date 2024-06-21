using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyManagerr : MonoBehaviour
{
    public Button playerButton;
    public Button clickButton;
    public Sprite newButtonImage;
    public GameObject anotherPlayer;

    void Update()
    {
        RoomLeaderExists();
    }

    void RoomLeaderExists()
    {
        GameObject[] roomLeaders = GameObject.FindGameObjectsWithTag("RoomLeader");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // RoomLeader �±׸� ���� ������Ʈ�� �ϳ� �̻� �����ϴ� ���
        if (roomLeaders != null && roomLeaders.Length > 0)
        {
            // Player Ready��ư�� �Ҵ�Ǿ� �ְ�, Ȱ��ȭ�� ���
            if (playerButton != null && playerButton.gameObject.activeSelf)
            {
                playerButton.gameObject.SetActive(false); // ��ư ��Ȱ��ȭ
            }

            Image buttonImage = clickButton.GetComponent<Image>();
            TMP_Text buttonText = clickButton.GetComponentInChildren<TMP_Text>();
            if (buttonImage != null && newButtonImage != null && buttonText != null)
            {
                buttonImage.sprite = newButtonImage;
                buttonText.text = "Start";
            }

        }

        // Player �±׸� ���� ������Ʈ�� �ϳ� �̻� �����ϴ� ���
        if (players != null && players.Length > 0)
        {
            anotherPlayer.gameObject.SetActive(true);
        }

        else 
        {
            // �÷��̾� ���� �Ҵ�Ǿ� �ְ�, Ȱ��ȭ�� ���
            if (anotherPlayer != null && anotherPlayer.gameObject.activeSelf)
            {
                anotherPlayer.gameObject.SetActive(false); // ��ư ��Ȱ��ȭ
            }
        }
    }
}