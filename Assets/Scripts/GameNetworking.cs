using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameNetworking : Photon.MonoBehaviour {

    public GameObject RoomName;
    public GameObject NumPlayers;
    public GameObject JoinRoomName;
    public GameObject RoomNameTextDisplay;

    public void CreateGame()
    {
        RoomOptions roomOpts = new RoomOptions();
        roomOpts.MaxPlayers = (byte)(NumPlayers.GetComponent<Dropdown>().value + 2);
        PhotonNetwork.CreateRoom(RoomName.GetComponent<InputField>().text, roomOpts,null);
        RoomNameTextDisplay.GetComponent<Text>().text = RoomName.GetComponent<InputField>().text;
    }

    public void LeaveGame()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void JoinGame()
    {
        //Debug.Log(JoinRoomName.GetComponent<Text>().text);
        //PhotonNetwork.JoinRoom(JoinRoomName.GetComponent<Text>().text);
    }

}
