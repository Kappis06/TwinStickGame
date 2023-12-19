using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UIElements;

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
   public  bool _idle = true;
    

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
        


        

        Act();
       
    }

    /// <summary>
    /// Rotates the sprite depending on the velocity
    /// </summary>
    void Act()
    {
        Vector2 position = _rigidbody2D.position;

        if (_idle)
        {
            if (Vertical && !Both)
            {
                //position.y = position.y + Time.deltaTime * Speed * _direction;
                position.y = position.y + Mathf.Cos(Time.time * Speed) * (BackAndForthVertical / 100);
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

            Vector2 lookDir = new Vector2(_rigidbody2D.position.x - _lastPos.x, _rigidbody2D.position.y - _lastPos.y);
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            _rigidbody2D.rotation = angle;
        }
        else if (!_idle)
        {
            Transform target = GameObject.Find("Player").transform;            
            Vector2 lookDir = (Vector2)target.position - _rigidbody2D.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            _rigidbody2D.rotation = angle;
            Debug.Log(angle);

            //position = new Vector2((GameObject.Find("Player").transform.position.x - position.x) + Time.fixedDeltaTime * Speed,
            //                                     (GameObject.Find("Player").transform.position.y - position.y) + Time.fixedDeltaTime * Speed);
            
            
           // _rigidbody2D.velocity = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * Speed ;
            _rigidbody2D.position += new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Speed * Time.deltaTime;
        }

        _lastPos = _rigidbody2D.position;
        //_rigidbody2D.MovePosition(position);
    }
}
