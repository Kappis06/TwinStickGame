using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed = 2.0f;
    public bool Vertical;
    public bool Both;
    public float ChangeTime = 3.0f;
    public float BackAndForthVertical = 5f;
    public float BackAndForthHorizontal = 5f;

    Rigidbody2D _rigidbody2D;
    float _timer;
    int _direction = 1;
    float _totalTime;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _timer = ChangeTime;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        

        if (_timer < 0)
        {
            _direction = -_direction;
            _timer = ChangeTime;
        }
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

        _rigidbody2D.MovePosition(position);
    }
}
