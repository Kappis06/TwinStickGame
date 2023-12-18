using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform player;
    
    [SerializeField] float minThreshold;
    [SerializeField] float maxThreshold;

    float threshold;



    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            threshold = maxThreshold;
        else
            threshold = minThreshold;



        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 joystickMulti = new Vector3(14, 7, 0);
        //Vector3 joystickInput = new Vector3(Input.GetAxis(""), Input.GetAxis(""));
        //Vector3 joystickResult = new Vector3(joystickMulti.x * joystickInput.x, joystickMulti.y * joystickInput.y, joystickMulti.z * joystickInput.z);

        Vector3 targetPos = (player.position + /*joystickResult*/ mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, - threshold + player.position.x, threshold + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, - threshold + player.position.y, threshold + player.position.y);

        this.transform.position = targetPos;
    }
}
