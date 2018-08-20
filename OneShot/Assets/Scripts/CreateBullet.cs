using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour {

    public Transform[] bulletPos;

    
    void Start ()
    {
        int ranPos= Random.Range(0, bulletPos.Length);
        //GameObject tmp = PhotonNetwork.Instantiate("Bullet 0.45 (LP)", bulletPos[ranPos].position, bulletPos[ranPos].rotation, 0);

      PhotonNetwork.Instantiate("RBullet", bulletPos[ranPos].position, bulletPos[ranPos].rotation, 0);

    }

    //void Update () {

    //}

}
