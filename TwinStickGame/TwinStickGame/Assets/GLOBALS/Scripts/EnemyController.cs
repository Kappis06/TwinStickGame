using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed = 2.0f;
    public bool Vertical;
    public bool Both;
    public float BackAndForthVertical = 5f;
    public float BackAndForthHorizontal = 5f;

    Rigidbody2D _rigidbody2D;
    float _totalTime;
    Vector2 _lastPos;
    

// Start is called before the first frame update
void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector2 position = _rigidbody2D.position;
        _totalTime += Time.fixedDeltaTime;

        if (Vertical && !Both)
        {
            //position.y = position.y + Time.deltaTime * Speed * _direction;
            position.y = position.y + Mathf.Cos(_totalTime * Speed) * (BackAndForthVertical / 100);
        }
        else if (Both && !Vertical)
        {
            position.y = position.y + Mathf.Cos(_totalTime * Speed) * (BackAndForthVertical / 100);
            position.x = position.x + Mathf.Cos(_totalTime * Speed + (Mathf.PI / 2)) * (BackAndForthVertical / 100);
        }
        else
        {
            //position.x = position.x + Time.deltaTime * Speed * _direction;
            position.x = position.x + Mathf.Cos(_totalTime * Speed) * (BackAndForthVertical / 100);
        }

        Act();
        _lastPos = _rigidbody2D.position;
        _rigidbody2D.MovePosition(position);
    }

    void Act()
    {
        //_rigidbody2D.MovePosition(_rigidbody2D.position + _movement * _playerSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = new Vector2((_rigidbody2D.position.x - _lastPos.x),(_rigidbody2D.position.y - _lastPos.y));
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
        _rigidbody2D.rotation = angle;
    }
}
