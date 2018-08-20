using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireCtrl : MonoBehaviour
{

    //public GameObject bullet;
    public Transform firePos;
    public GameObject bulletEffect;
    public Transform[] bulletPos2;
    PhotonView pv;
    public static int judge;

    //public AudioSource dieShot;
    public AudioClip misShot;
    public AudioClip dieShot;

    public AudioSource source;
   
    //지금여기에 넣어야하는데 이스크립트가
    //ㅇㅇ
    //ㅇㅇ아 그렇게해야되는거임?
    //플레이어자체에 그냥 바로 넣으면안되나
    //ㅇㅇ

    /*
     GameObject canvas2;
     Image[] gameImage;
     */
    void Start()
    {
        //   canvas2 = GameObject.Find("Canvas");
        // gameImage = canvas2.GetComponentsInChildren <Image> ();
        //    gameImage[2].gameObject.SetActive(true);

        Debug.Log("================"+judge.ToString());
    }
   
     
    void Update()
    {
        Debug.Log("OnFire");
        if (Input.GetMouseButtonDown(0))
        {

           
            if (DropnFireActive.hasGun == true)
            {
                
                Debug.Log("onDraw");
                Debug.DrawRay(firePos.position, firePos.forward * 100f, Color.red);
                Debug.Log("hasGun");

                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit hitInfo;

                int layer = 1 << LayerMask.NameToLayer("Player");
                if (Physics.Raycast(ray, out hitInfo, 100, ~layer))
                {
                    

                    if (hitInfo.transform.tag == "Enemy")
                    {

                        source.clip = dieShot;
                        source.Play();
                        //SOUND
                        //source = GetComponent<AudioSource>();
                        //source.PlayOneShot(dieShot, 1.0f);
                        //dieShot.Play();

                        Debug.Log("====hit====");
                        pv = hitInfo.transform.GetComponent<PhotonView>();
                        pv.RPC("Shot", PhotonTargets.Others);

                        judge = 1;
                        //gameImage[2].gameObject.SetActive(true);

                    }               
                    else
                    {
                        source.clip = misShot;
                        source.Play();

                        //source2 = GetComponent<AudioSource>();
                        //source2.PlayOneShot(misShot, 1.0f);

                        //그렇지 않으면 닿은 지점에 효과 주기
                        GameObject effect = Instantiate(bulletEffect);
                        effect.transform.position = hitInfo.point;
                        effect.transform.forward = hitInfo.normal; //normal 닿은 지점에서  수직으로 향하고 있는 방향

                        DropnFireActive.hasGun = false;


                        int ranPos2 = Random.Range(0, bulletPos2.Length);
                        PhotonNetwork.Instantiate("RBullet", bulletPos2[ranPos2].position, bulletPos2[ranPos2].rotation, 0);



                    }

                    //else if (hitInfo.transform.tag == "Player1")
                    //{
                    //    Debug.Log("hit1");
                    //    PhotonView pv = hitInfo.transform.GetComponent<PhotonView>();
                    //    pv.RPC("Shot", PhotonTargets.All);
                    //}
                    //else
                    //{

                    //}
                }

            }
        }
Debug.Log("goRPC");

    }
    
   
    }

  

