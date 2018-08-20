using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhotonMove : Photon.MonoBehaviour
{
    Vector3 position;
    Quaternion rotation;
    bool getState;
    Animator otherAim;

    public float lerpSpeed = 5;
  

    //Transform camera;
    // Use this for initialization
    Transform move;
    void Start()
    {
       

        //  PhotonManager.test.text = "isMine";
     
        if (photonView.isMine)
        {

            // GetComponent<Player1Move>().enabled = true;

            GetComponent<DropnFireActive>().enabled = true;
            GetComponent<PlayerMove>().enabled = true;
            GetComponentInChildren<FireCtrl>().enabled = true;
            GetComponentInChildren<CamRotate>().enabled = true;
            GetComponentInChildren<Camera>().enabled = true;
            GetComponentInChildren<Camera>().gameObject.tag = "MainCamera";
            gameObject.tag = "Me";

        }
        else
        {
            gameObject.tag = "Enemy";
            //   move =GetComponentInChildren<Camera>().transform;
            move = GetComponent<Transform>();
            otherAim = GetComponent<Animator>();
        }
    }
    bool isChange = false;
    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine == false)
        {
            transform.position = Vector3.Lerp(transform.position, position, lerpSpeed * Time.deltaTime);

          //  Quaternion qua = new Quaternion(0, rotation.y, 0, 0);
            move.rotation = Quaternion.Lerp(move.rotation, rotation, lerpSpeed * Time.deltaTime);
            if (isChange)
            {
                otherAim.SetBool("isRun", getState);
                isChange = false;
            }

        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            //  stream.SendNext(Camera.main.transform.rotation);
            stream.SendNext(transform.rotation);
            stream.SendNext(PlayerMove.sendState);


        }
        else
        {

            position = (Vector3)stream.ReceiveNext();
            rotation = (Quaternion)stream.ReceiveNext();
            bool state = (bool)stream.ReceiveNext();
            if (getState != state)
            {
                getState = state;
                isChange = true;
            }
            print(isChange + "----------------------> " + getState);
        }
    }
    [PunRPC]
    void Shot()
    {
        Debug.Log("You Win");
        //파괴.
       FireCtrl.judge = 2;

        GetComponentInChildren<Camera>().enabled = true;
        GetComponentInChildren<Camera>().gameObject.tag = "MainCamera";
        PhotonNetwork.Destroy(gameObject); // 네트워크에 알려서 제거한다는걸 알려줌
       

    }
}
