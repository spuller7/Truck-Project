using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayNetworkStatus : Photon.MonoBehaviour {

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString() + " | Connected as: " + PhotonNetwork.player.NickName);
    }
}
