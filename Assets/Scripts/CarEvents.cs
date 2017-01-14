using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEvents : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.Instantiate("Detonator-Wide", gameObject.transform.position, gameObject.transform.rotation, 0);
        Destroy(gameObject);
    }
    
}
