using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuDisplayHandler : Photon.MonoBehaviour {

    [SerializeField]
    private GameObject[] Menus;

    public GameObject CreateGameUI;
    public GameObject CreateGameUIButton;
    public GameObject JoinGameUI;
    public GameObject JoinGameUIButton;
    public GameObject JoinGameButton;
    public GameObject CreateGameButton;
    public GameObject BackButton;
    public GameObject OnlineButton;
    public GameObject RoomName;
    public GameObject JoinRoomName;
    public GameObject RoomLobby;
    public GameObject RoomList;
    public GameObject StartGameButton;
    public GameObject RoomNotAvailableText;

    private void Start()
    {
        for (int i = 0; i < Menus.Length; i++)
        {
            Menus[i].SetActive(false);
        }
        CreateGameUI.SetActive(false);
        RoomLobby.SetActive(false);
    }

    void Update()
    {
        if (CreateGameUI.activeSelf)
        {
            if (RoomName.GetComponent<InputField>().text.Length > 1)
            {
                CreateGameButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                CreateGameButton.GetComponent<Button>().interactable = false;
            }
        }

        if (JoinGameUI.activeSelf)
        {
            if (JoinRoomName.GetComponent<InputField>().text.Length > 1)
            {
                JoinGameButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                JoinGameButton.GetComponent<Button>().interactable = false;
            }
        }

        if (RoomLobby.activeSelf)
        {
            if (PhotonNetwork.isMasterClient)
            {
                StartGameButton.SetActive(true);
            }
            else
            {
                StartGameButton.SetActive(false);
            }
        }
    }
    // This opens the menu to create a game
    public void OnCreateGameUIClick()
    {
        Menus[1].SetActive(false);
        CreateGameUI.SetActive(true);
    }

    //This is when a game is created and loads the lobby
    public void OnCreateGameClick()
    {
        CreateGameUI.SetActive(false);
        RoomLobby.SetActive(true);
        RoomNotAvailableText.SetActive(false);
    }
    public void OnMenuButtonClick(int a)
    {
        for (int i = 0; i < Menus.Length; i++)
        {
            Menus[i].SetActive(false);
        }
        Menus[a].SetActive(true);
    }

    public void OnBackButtonClick()
    {
        Menus[1].SetActive(true);
        CreateGameUI.SetActive(false);
        RoomList.SetActive(false);
    }

    public void OnJoinGameUIClick()
    {
        Menus[1].SetActive(false);
        RoomList.SetActive(true);
    }

    public void OnJoinGameClick()
    {
        JoinGameUI.SetActive(false);
        RoomLobby.SetActive(true);
    }

    public void OnLeaveGameClick()
    {
        RoomLobby.SetActive(false);
        Menus[1].SetActive(true);
    }

    public void OnStartGameClick()
    {
        this.photonView.RPC("LoadGame", PhotonTargets.All);
    }

    public void OnCreatedRoom() {
        OnCreateGameClick();
    }

    public void OnPhotonCreateRoomFailed()
    {
        RoomNotAvailableText.SetActive(true);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    [PunRPC]
    void LoadGame()
    {
        SceneManager.LoadScene("Map_1");
    }
}