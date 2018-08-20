using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour {


  
    float mx, my;
    public Camera cam;

    void Update()
    {
        float x = Input.GetAxis("Mouse X");

        float y = Input.GetAxis("Mouse Y");




        mx += x * PlayerMove.mouseSpeed * Time.deltaTime;
        my += y *PlayerMove.mouseSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90, 90);
        //   mx = Mathf.Clamp(mx, -90, 90);

        transform.eulerAngles = new Vector3(my * -1, mx, 0);
    }
}
