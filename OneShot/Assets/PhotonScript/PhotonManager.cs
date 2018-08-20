using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviour
{

    public GameObject canvas;
    private Text state;
    public Text inOut;
    // public static Text  test;
    //  public GameObject Player1, Player2;
    public static bool selCharacter;
    //   GameObject Player1, Player2;
    public Transform stage, stage2;
    string roomName = "gogo";
    RoomOptions ro;
    public Camera scenceCamera;
   // public static GameObject P1, P2;
    public GameObject createBullet;
    public Button btn1, btn2;
    public Image mainImg,winImg,loseImg;
    


    //public static PhotonView  photonView;

    // Use this for initialization
    void Start()
    {


        Debug.Log("start");
        state = canvas.GetComponentInChildren<Text>();

        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("1.0");
        ro = new RoomOptions { IsVisible = false, MaxPlayers = 2 };


    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        state.text = PhotonNetwork.connectionStateDetailed.ToString();


        if (FireCtrl.judge == 1)
        {

            winImg.gameObject.SetActive(true);
        }
        else if (FireCtrl.judge == 2)
        {
            loseImg.gameObject.SetActive(true);
        }


    }



    public void goRoom()
    {
        Debug.Log("goRoom");
        selCharacter = true;
        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
        PhotonNetwork.player.NickName = "1p";

      
    }

    public void goRoom2()
    {
        Debug.Log("goRoom2");
        selCharacter = false;
        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
        PhotonNetwork.player.NickName = "2P";
      
    }

    void OnJoinedLobby()
    {
        Debug.Log("j.Lobby");
        scenceCamera.enabled = true;
    }

    void OnJoinedRoom()
    {
        Debug.Log("j.Room");
        if (PhotonNetwork.room.PlayerCount == 1)
        {

            createBullet.SetActive(true);
        }



        foreach (Button btn in canvas.GetComponentsInChildren<Button>())
        {
            Debug.Log("foreach");
            btn.gameObject.SetActive(false);
        }

        mainImg.gameObject.SetActive(false);

        //  SceneManager.LoadScene("Playing", LoadSceneMode.Single);

        scenceCamera.enabled = false;



        if (selCharacter)
        {
            Debug.Log("selChar");
            //  test.text = "1P";

            PhotonNetwork.Instantiate("Player1", stage.position, stage.rotation, 0);
        

           

        }
        else
        {
            PhotonNetwork.Instantiate("Player2", stage2.position, stage2.rotation, 0);
           
           
        }

        

     
    }

    void OnPhotonPlayerConnected(PhotonPlayer NewPlayer)
    {

        Debug.Log(NewPlayer.NickName +"연결");
        inOut.text = NewPlayer.NickName + " " + "님이 방에 들어오셨습니다.";

    }

    void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        inOut.text = otherPlayer.NickName + " " + "님이 방을 나가셨습니다.";



    }
}



