using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : Photon.MonoBehaviour {

    string spawn;
    bool gameStart = false;

    // Use this for initialization
    void Start () {
       // GameObject myCar = PhotonNetwork.Instantiate("CamaroSS69_DOOM", Vector3.zero, Quaternion.identity, 0);
       // Camera.main.GetComponent<CameraFollow>().target = myCar.transform;

        

        if (PhotonNetwork.player.NickName != "Jake")
        {
            spawn = "Spawn6";
        }
        else
        {
            spawn = "Spawn7";
        }
         //GameObject myCar = PhotonNetwork.Instantiate("CamaroSS69_DOOM", GameObject.Find(spawn).transform.position, Quaternion.identity, 0);
         //Camera.main.GetComponent<CameraFollow>().target = myCar.transform;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && PhotonNetwork.room.PlayerCount == 2)
        {
            GameObject myCar = PhotonNetwork.Instantiate("CamaroSS69_DOOM", Vector3.zero, Quaternion.identity, 0);
            Camera.main.GetComponent<CameraFollow>().target = myCar.transform;
        }

        if (PhotonNetwork.room.PlayerCount == 2 && !gameStart)
        {
            GameObject myCar = PhotonNetwork.Instantiate("CamaroSS69_DOOM", GameObject.Find(spawn).transform.position, Quaternion.identity, 0);
            Camera.main.GetComponent<CameraFollow>().target = myCar.transform;
            gameStart = true;
        }
	}

}
