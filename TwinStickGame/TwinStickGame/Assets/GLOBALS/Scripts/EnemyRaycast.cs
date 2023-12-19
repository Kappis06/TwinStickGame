using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    GameObject _player;
    bool _hasLineOfSight = false;
    public static Vector2 LastSeenPos;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasLineOfSight)
        {
            EnemyController.Idle = false;
        }
        else if ((Vector2)transform.position != LastSeenPos)
        {
            EnemyController.Idle = true;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, _player.transform.position - transform.position);
        if (ray.collider != null)
        {
            EnemyController.MoveToLastSeenPos = false;
            _hasLineOfSight = ray.collider.CompareTag("Player") && Mathf.Sqrt(Mathf.Pow((_player.transform.position.x - transform.position.x), 2) + 
                                                                                                                        Mathf.Pow((_player.transform.position.y - transform.position.y), 2)) < 10;
            LastSeenPos = _player.transform.position;

            if (_hasLineOfSight)
            {
                Debug.DrawRay(transform.position, _player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, _player.transform.position - transform.position, Color.red);
            }
        }
        else if ((Vector2)transform.position != LastSeenPos)
        {
            EnemyController.MoveToLastSeenPos = true;
        }
        else
        {
            EnemyController.MoveToLastSeenPos = false;
        }
    }
}
