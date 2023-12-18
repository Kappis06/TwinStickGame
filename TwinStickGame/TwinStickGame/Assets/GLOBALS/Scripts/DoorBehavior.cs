using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    public Collision2D _collision;
    public Collider2D _colider;

    [SerializeField] public bool coliding = false;

    private bool _openDoor;

    // Start is called before the first frame update
    void Start()
    {
        _colider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        _openDoor = Input.GetKey(KeyCode.JoystickButton1);
        coliding = false;
    }

    void FixedUpdate()
    {
        
        

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_openDoor)
        {
            _colider.enabled = false;
        }
        coliding = true;
    }
}
