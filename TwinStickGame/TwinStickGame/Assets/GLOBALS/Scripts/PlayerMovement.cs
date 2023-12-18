using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    
    public Rigidbody2D rb;
    new public Collider2D collider;
    public Camera cam;
    //public Text playerHealthUI;
    //public GameObject bloodPrefab;

    Vector2 movement;
    Vector2 mousePos;

    [Header("Player Stats")]

    public float playerSpeed;
    //private float playerHealth;

    //public float playerHealthMax;

    public bool restartAnytime = false;

    [HideInInspector] public bool gameActive;

    [SerializeField] private Cooldown dmgCooldown;

    



    void Start()
    {
        Prepare();
    }

    void Update()
    {
        /*if (playerHealth <= 0 && gameActive)
        {
            gameActive = false;

            rb.bodyType = RigidbodyType2D.Static;

            collider.enabled = false;

            //GameObject blood = Instantiate(bloodPrefab, gameObject.transform.position, gameObject.transform.rotation);

            //FindObjectOfType<AudioManager>().Play("peter griffin");

            //blood.transform.localScale = new Vector3(1, 1, 1);
        }*/
        
        GetInput();

        UpdateUI();
    }

    void FixedUpdate()
    {
        if (gameActive)
        {
            Act();

            if (restartAnytime && Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        else
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }



    void Prepare()
    {
        gameActive = true;

        //playerHealth = playerHealthMax;
    }

    void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void UpdateUI()
    {
        //playerHealthUI.text = playerHealth.ToString();
    }

    void Act()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        /*if (dmgCooldown.IsCoolingDown) return;
        
        if (collision.gameObject.layer == 9 && gameActive)
        {
            playerHealth--;

            dmgCooldown.StartCooldown();
        }*/
    }
}
