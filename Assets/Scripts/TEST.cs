using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : Photon.MonoBehaviour {

    GameObject test;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space"))
        {
            GameObject myCar = PhotonNetwork.Instantiate("CamaroSS69_DOOM", Vector3.zero, Quaternion.identity, 0);
            Camera.main.GetComponent<CameraFollow>().target = myCar.transform;

            //    test = GameObject.Find("CamaroSS69_DOOM");
            //    Instantiate(test, Vector3.zero, Quaternion.identity);
        }
	}
}
