using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnlineButton : MonoBehaviour {

	// Use this for initialization
	public void OnClick()
    {
        PhotonNetwork.CreateRoom(null);
        SceneManager.LoadScene("Map_1");
    }
}
