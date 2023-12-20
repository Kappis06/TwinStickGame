using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    public Collision2D _collision;
    public Collider2D _colider;
    


    GameObject _player;
    GameObject _playerKeycard;



    private bool _openDoor;

    // Start is called before the first frame update
    void Start()
    {
        _colider.enabled = true;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _playerKeycard = _player.GetComponent<PlayerBelongings>().Keycard;
        _openDoor = Input.GetKey(KeyCode.JoystickButton1) && _playerKeycard != null;


    }

    void FixedUpdate()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_openDoor)
        {
            _colider.enabled = false;
            Destroy(_playerKeycard);
        }
    }
}
