using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    GameObject _player;
    bool _hasLineOfSight = false;
    public static Vector2 LastSeenPos = new Vector2(0, 0);

    bool _onLastSeenPos = true;

    RaycastHit2D ray;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
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
    
    private void FixedUpdate()
    {
        ray = Physics2D.Raycast(transform.position, _player.transform.position - transform.position);
        //Physics2D.CapsuleCast(transform.position, new Vector2(10, 5),  )

        if (ray.collider != null)
        {
            _hasLineOfSight = ray.collider.CompareTag("Player");
           
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
