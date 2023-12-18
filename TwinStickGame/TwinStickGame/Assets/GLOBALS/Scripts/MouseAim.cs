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
        Vector3 targetPos = (player.position + mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, - threshold + player.position.x, threshold + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, - threshold + player.position.y, threshold + player.position.y);

        this.transform.position = targetPos;
    }
}
