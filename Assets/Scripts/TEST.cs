using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : Photon.MonoBehaviour {

    string spawn;
    bool gameStart = false;

    // Use this for initialization
    void Start () {

        PhotonPlayer[] players = PhotonNetwork.playerList;
        ArrayList spawns = new ArrayList();
        spawns.Sort();
        for (int i = 0; i<players.Length; i++)
        {
            spawns.Add(players[i].NickName);
        }
        
        spawn = "Spawn" + (spawns.IndexOf(PhotonNetwork.player.NickName) + 1);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && gameStart)
        {
            GameObject myCar = PhotonNetwork.Instantiate("CamaroSS69_DOOM", Vector3.zero, Quaternion.identity, 0);
            Camera.main.GetComponent<CameraFollow>().target = myCar.transform;
        }

        if (!gameStart)
        {
            GameObject myCar = PhotonNetwork.Instantiate("CamaroSS69_DOOM", GameObject.Find(spawn).transform.position, GameObject.Find(spawn).transform.rotation, 0);
            Camera.main.GetComponent<CameraFollow>().target = myCar.transform;
            gameStart = true;
        }
	}

}
