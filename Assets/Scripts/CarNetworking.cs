using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNetworking : Photon.MonoBehaviour {

    double m_LastNetworkDataReceivedTime;
    Vector3 m_NetworkPosition;
    Quaternion m_NetworkRotation;

    void FixedUpdate()
    {
        if (!photonView.isMine)
        {
            UpdateNetworkedPosition();
            UpdateNetworkedRotation();
        }
    }

    void UpdateNetworkedPosition()
    {
        //Here we try to predict where the player actually is depending on the data we received through the network
        float pingInSeconds = (float)PhotonNetwork.GetPing() * 0.001f;
        float timeSinceLastUpdate = (float)(PhotonNetwork.time - m_LastNetworkDataReceivedTime);
        float totalTimePassed = pingInSeconds + timeSinceLastUpdate;

        if (m_NetworkPosition == Vector3.zero) return;

        //Update remote player (smooth this, this looks good, at the cost of some accuracy)
        transform.position = Vector3.Lerp(transform.position, m_NetworkPosition, Time.deltaTime * 5);
    }

    void UpdateNetworkedRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,m_NetworkRotation, Time.deltaTime * 5);
    }

    static float Lerp(float from, float to, float value)
    {
        if (value < 0.0f) return from;
        else if (value > 1.0f) return to;
        return (to - from) * value + from;
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        SerializeState(stream, info);
    }

    void SerializeState(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting == true)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            m_NetworkPosition = (Vector3)stream.ReceiveNext();
            m_NetworkRotation = (Quaternion)stream.ReceiveNext();
            m_LastNetworkDataReceivedTime = info.timestamp;
        }

    }
}
