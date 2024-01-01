using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform player;
    
    [SerializeField] private float minThreshold;
    [SerializeField] private float maxThreshold;

    private float threshold;

    public Vector3 joystickInput;
    public Vector3 mousePos;
    public Vector3 targetPos;



    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Aim"))
            threshold = maxThreshold;
        else
            threshold = minThreshold;


        joystickInput = new Vector3((Screen.width / 2) * Input.GetAxisRaw("Horizontal_R"), (Screen.height / 2) * Input.GetAxisRaw("Vertical_R"), 0);
        /*if (Mathf.Abs(joystickInput.x) < 20)
        {
            joystickInput.x = 0;
        }
        if (Mathf.Abs(joystickInput.y) < 20)
        {
            joystickInput.y = 0;
        }*/

        mousePos = cam.ScreenToWorldPoint(/*Input.mousePosition*/ joystickInput);


        //joystickMulti = new Vector3(14, 7, 0);
        //joystickInput = new Vector3(Input.GetAxis("Horizontal_R"), Input.GetAxis("Vertical_R"), 0);
        //joystickResult = new Vector3(joystickMulti.x * joystickInput.x, joystickMulti.y * joystickInput.y, 0);

        targetPos = (player.position + joystickInput /*mousePos*/) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, - threshold + player.position.x, threshold + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, - threshold + player.position.y, threshold + player.position.y);

        this.transform.position = targetPos;
    }
}
