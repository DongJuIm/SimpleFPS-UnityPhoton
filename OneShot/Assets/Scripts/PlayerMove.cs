using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator anim;
   public static bool sendState;
   float LR,LR2;
    public static float mouseSpeed=50;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //float y = Input.GetAxis("Mouse X");

        LR = Input.GetAxis("Mouse X");
        LR2 += LR * mouseSpeed* Time.deltaTime;


        transform.Translate(x * 0.3f, 0, z * 0.4f);
       // transform.Rotate(0, LR2, 0);
       transform.eulerAngles=new Vector3(0, LR2, 0);

        if (x > 0.1f)
        {
        anim.SetBool("isRun", true);
            sendState = true;
        }
        else if (x < -0.1f)
        {
            anim.SetBool("isRun", true);
            sendState = true;
        }
        else if (z > 0.1f)
        {
            anim.SetBool("isRun", true);
            sendState = true;
        }
        else if (z < -0.1f)
        {
            anim.SetBool("isRun", true);
            sendState = true;
        }
        else
        {
            anim.SetBool("isRun", false);
            sendState = false;
        }
    }
}
