using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectButton : Photon.MonoBehaviour {

    GameObject button;
    GameObject userName;

	// Use this for initialization
	void Start () {
        button = GameObject.Find("ConnectButton");
        button.GetComponent<Button>().interactable = false;
        userName = GameObject.Find("InputField");
        PhotonNetwork.ConnectUsingSettings ("alpha 0.1");
    }

    // Update is called once per frame
    void Update () {
		if(userName.GetComponent<InputField>().text.Length > 1)
        {
            button.GetComponent<Button>().interactable = true;
        }
        else
        {
            button.GetComponent<Button>().interactable = false;
        }
	}

    public void OnClick()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.player.NickName = userName.GetComponent<InputField>().text;
        SceneManager.LoadScene("Menu");
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}
