using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    private GameObject _player;
    private bool _hasLineOfSight = false;
    public static Vector2 LastSeenPos = new Vector2(0, 0);
    private bool _onLastSeenPos = true;

    

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player") ;
    }

    void Update()
    {
        if (_hasLineOfSight)
        {
            EnemyController.Idle = 0;
            _onLastSeenPos = false;
        }
        //else if ((Vector2)transform.position != LastSeenPos&& !_onLastSeenPos)
        //else if (transform.position.x < (_player.transform.position.x - 2) || transform.position.x > (_player.transform.position.x + 2) ||
        //            transform.position.y < (_player.transform.position.y - 2) || transform.position.y > (_player.transform.position.y + 2) && 
        //            !_onLastSeenPos)
        else if (Mathf.Abs(LastSeenPos.x - transform.position.x) > 0.3f &&
                    Mathf.Abs(LastSeenPos.y - transform.position.y) > 0.3f && 
                    !_onLastSeenPos)
        {
            EnemyController.Idle = 2;
        }
        else
        {
            EnemyController.Idle = 1;
            _onLastSeenPos = true;
        }
    }
    
    void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, _player.transform.position - transform.position);


        if (ray.collider != null)
        {
            _hasLineOfSight = ray.collider.CompareTag("Player") && Mathf.Sqrt(Mathf.Pow(_player.transform.position.x - transform.position.x, 2) +
                                                                                                                        Mathf.Pow(_player.transform.position.y - transform.position.y, 2)) < 10; ;

            if (_hasLineOfSight)
            {
                Debug.DrawRay(transform.position, _player.transform.position - transform.position, Color.green);
                LastSeenPos = _player.transform.position;
            }
            else if (Mathf.Abs(LastSeenPos.x - transform.position.x) > 0.3f &&
                        Mathf.Abs(LastSeenPos.y - transform.position.y) > 0.3f &&
                        !_onLastSeenPos)
            {
                Debug.DrawRay(transform.position, LastSeenPos - (Vector2)transform.position, Color.yellow);
                Debug.DrawRay(transform.position, _player.transform.position - transform.position, Color.red);

            }
            else
            {
                Debug.DrawRay(transform.position, _player.transform.position - transform.position, Color.red);

            }
        }
    }
}
