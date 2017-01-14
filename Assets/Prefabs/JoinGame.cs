using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinGame : Photon.MonoBehaviour {

    public GameObject RoomName;
    GameObject RoomList;
    GameObject RoomLobby;

	public void JoinGameOnClick()
    {
        PhotonNetwork.JoinRoom(RoomName.GetComponent<Text>().text);
        RoomList = GameObject.Find("RoomList");
        GameObject[] list = Resources.FindObjectsOfTypeAll<GameObject>();
        for (int i = 0; i<list.Length; i++)
        {
            if (list[i].name.Equals("RoomLobby"))
            {
                RoomLobby = list[i];
            }
        }
        RoomLobby.transform.GetChild(0).GetComponent<Text>().text = RoomName.GetComponent<Text>().text;
        RoomList.SetActive(false);
        RoomLobby.SetActive(true);

    }
}
