using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    public Collision2D _collision;
    public Collider2D _colider;
    
    private GameObject _player;
    private GameObject _playerKeycard;

    private Animator _animator;

    private bool _openDoor;
    private bool _doorIsOpen = false;



    void Start()
    {
        _colider.enabled = true;
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _playerKeycard = _player.GetComponent<PlayerBelongings>().Keycard;
        _openDoor = Input.GetButton("Interact") && _playerKeycard != null;


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_openDoor && !_doorIsOpen)
        {
            _colider.enabled = false;
            _doorIsOpen = true;
            Destroy(_playerKeycard);
            _animator.SetBool("Open", true);
        }
    }
}
