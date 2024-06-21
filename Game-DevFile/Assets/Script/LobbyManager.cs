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

        // RoomLeader 태그를 가진 오브젝트가 하나 이상 존재하는 경우
        if (roomLeaders != null && roomLeaders.Length > 0)
        {
            // Player Ready버튼이 할당되어 있고, 활성화된 경우
            if (playerButton != null && playerButton.gameObject.activeSelf)
            {
                playerButton.gameObject.SetActive(false); // 버튼 비활성화
            }

            Image buttonImage = clickButton.GetComponent<Image>();
            TMP_Text buttonText = clickButton.GetComponentInChildren<TMP_Text>();
            if (buttonImage != null && newButtonImage != null && buttonText != null)
            {
                buttonImage.sprite = newButtonImage;
                buttonText.text = "Start";
            }

        }

        // Player 태그를 가진 오브젝트가 하나 이상 존재하는 경우
        if (players != null && players.Length > 0)
        {
            anotherPlayer.gameObject.SetActive(true);
        }

        else 
        {
            // 플레이어 탭이 할당되어 있고, 활성화된 경우
            if (anotherPlayer != null && anotherPlayer.gameObject.activeSelf)
            {
                anotherPlayer.gameObject.SetActive(false); // 버튼 비활성화
            }
        }
    }
}