using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    
    public Rigidbody2D Rb;
    public Collider2D Collider;
    public Camera Cam;
    //public Text playerHealthUI;
    //public GameObject bloodPrefab;

    Vector2 _movement;
    Vector2 _mousePos;

    [Header("Player Stats")]

    float _playerSpeed;
    public float PlayerStartSpeed = 5;

    float _sprintTime;
    public float SprintStartTime = 5;

    private float playerHealth;

    public float playerHealthMax;

    public bool restartAnytime = false;

    [HideInInspector] public bool gameActive;

    [SerializeField] private Cooldown dmgCooldown;

    



    void Start()
    {
        Prepare();
    }

    void Update()
    {
        if (playerHealth <= 0 && gameActive)
        {
            gameActive = false;

            Rb.bodyType = RigidbodyType2D.Static;

            Collider.enabled = false;

            //GameObject blood = Instantiate(bloodPrefab, gameObject.transform.position, gameObject.transform.rotation);

            //FindObjectOfType<AudioManager>().Play("peter griffin");

            //blood.transform.localScale = new Vector3(1, 1, 1);
        }


        GetInput();

        UpdateUI();

        Sprinting();
    }

    void FixedUpdate()
    {
        if (gameActive)
        {
            Act();

            if (restartAnytime && Input.GetButton("Restart"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        else
        {
            if (Input.GetButton("Restart"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }



    void Prepare()
    {
        gameActive = true;

        _playerSpeed = PlayerStartSpeed;
        _sprintTime = SprintStartTime;
        playerHealth = playerHealthMax;
    }

    void GetInput()
    {
        _movement.x = Input.GetAxisRaw("Horizontal_L");
        _movement.y = Input.GetAxisRaw("Vertical_L");

        _mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void Sprinting()
    {
        if (Input.GetKey(KeyCode.JoystickButton3) && _sprintTime >= 0)
        {
            _playerSpeed = 10;
            _sprintTime -= Time.deltaTime; 
        }
        else
        {
            _playerSpeed = PlayerStartSpeed;

            if (_sprintTime < SprintStartTime)
            {
                _sprintTime += Time.deltaTime;
            }
        }
    }

    void UpdateUI()
    {
        //playerHealthUI.text = playerHealth.ToString();
    }

    void Act()
    {
        Rb.MovePosition(Rb.position + _movement * _playerSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = new Vector2(Input.GetAxisRaw("Horizontal_R"), Input.GetAxisRaw("Vertical_R"))/*_mousePos - Rb.position*/;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        Rb.rotation = angle;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (dmgCooldown.IsCoolingDown) return;
        
        if ((collision.gameObject.layer == LayerMask.NameToLayer("Enemy")) && gameActive)
        {
            playerHealth--;

            dmgCooldown.StartCooldown();
        }
    }
}
