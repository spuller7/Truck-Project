using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnlineButton : MonoBehaviour {

	// Use this for initialization
	public void OnClick()
    {
        PhotonNetwork.JoinRoom("test");
    }

    void OnPhotonJoinRoomFailed()
    {
        PhotonNetwork.CreateRoom("test");
    }

    void OnJoinedRoom()
    {
        SceneManager.LoadScene("Map_1");
    }
}
