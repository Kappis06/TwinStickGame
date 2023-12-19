using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    GameObject _player;
    private bool _hasLineOfSight = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, _player.transform.position - transform.position);
        if (ray.collider != null)
        {
            _hasLineOfSight = ray.collider.CompareTag("Player");
        }
    }
}
