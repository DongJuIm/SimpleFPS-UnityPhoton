using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropnFireActive : MonoBehaviour {

    public GameObject rBullet;
    public static bool hasGun;
    private Transform tr;

    void Start()
    {
        Debug.Log("instantiate");
      //  rBullet = (GameObject)Instantiate(rBullet);
    }
    //    void Update()
    //    {
    //        Debug.Log("go");

    //		Debug.Log ("go2");
    //		GetComponent<"FireCtrl1">.

    //    }
    void OnCollisionStay(Collision coll)
    {
        Debug.Log("go2");
        if (coll.collider.tag == "BULLET" && Input.GetKey(KeyCode.F))
        {
            Debug.Log("des");
            Destroy(coll.gameObject);        
            hasGun = true;
           
        }
    }
}
