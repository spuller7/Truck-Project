using UnityEngine;
using System.Collections;

public class PlayerSetup : Photon.MonoBehaviour
{

    [SerializeField]
    Behaviour[] componentsToDisable;


    void Start()
    {
        DisableComponents();
        //Here you would call a function to assign the camera to follow this ship because every camera is unique to the local player

    }
    void DisableComponents()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            if (photonView.isMine == false)
            {
                componentsToDisable[i].enabled = false;
            }
        }
    }
}