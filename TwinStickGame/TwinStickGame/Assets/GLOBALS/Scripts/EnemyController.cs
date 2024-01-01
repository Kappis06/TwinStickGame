using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public float IdleSpeed = 1.0f;
    public float HuntPlaySpeed = 3.0f;
    public float LastSeenHuntSpeed = 2.5f;
    public bool Vertical;
    public bool Both;
    public float BackAndForthVertical = 5f;
    public float BackAndForthHorizontal = 5f;

    public static int Idle = 1;
    public static float _angle;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _lastPos;



    public static float Angle
    {
        get
        {
            return _angle;
        }
    }



    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Act();
    }

    /// <summary>
    /// Rotates the sprite according to the velocity
    /// </summary>
    void Act()
    {
        Vector2 position = _rigidbody2D.position;

        if (Idle == 1) //Idle on one position
        {
            if (Vertical && !Both)
            {
                //position.y = position.y + Time.deltaTime * Speed * _direction;
                position.y = position.y + Mathf.Sin(Time.fixedTime * IdleSpeed) * (BackAndForthVertical / 100);
            }
            else if (Both && !Vertical)
            {
                position.y = position.y + Mathf.Sin(Time.fixedTime * IdleSpeed) * (BackAndForthVertical / 100) * IdleSpeed;
                position.x = position.x + Mathf.Cos(Time.fixedTime * IdleSpeed) * (BackAndForthHorizontal / 100) * IdleSpeed;
            }
            else
            {
                //position.x = position.x + Time.deltaTime * Speed * _direction;
                position.x = position.x + Mathf.Cos(Time.fixedTime * IdleSpeed) * (BackAndForthVertical / 100);
            }

            Vector2 lookDir = new Vector2(_rigidbody2D.position.x - _lastPos.x, _rigidbody2D.position.y - _lastPos.y);
            _angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            _rigidbody2D.rotation = _angle;

            _lastPos = _rigidbody2D.position;
            _rigidbody2D.MovePosition(position);
        }
        else if (Idle == 0) //Hunting player
        {
            Transform target = GameObject.Find("Player").transform;
            
            Vector2 lookDir = (Vector2)target.position - _rigidbody2D.position;
            _angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            _rigidbody2D.rotation = _angle;
            
            _rigidbody2D.velocity = transform.up * HuntPlaySpeed;
        }
        else if (Idle == 2) //Hunting players last seen position
        {
            Vector2 lookDir = EnemyRaycast.LastSeenPos - _rigidbody2D.position;
            _angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            _rigidbody2D.rotation = _angle;
            
            _rigidbody2D.velocity = transform.up * LastSeenHuntSpeed;
        }
    }
}
