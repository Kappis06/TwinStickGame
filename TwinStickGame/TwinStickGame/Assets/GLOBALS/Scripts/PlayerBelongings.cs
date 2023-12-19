using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBelongings : MonoBehaviour
{
    public GameObject Keycard;
    private Collider2D _collider;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Collectible") && Keycard == null)
        {
            Keycard = collision.gameObject;
            Keycard.GetComponent<Collider2D>().enabled = false;
            Keycard.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
