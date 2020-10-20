﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public enum JumpState
    {
        Grounded,
        Jumping,
        DoubleJumping,
    }

    public float speed = 10.0f;
    public float jumpForce = 100.0f;

    public int playerPoints = 0;

    private Rigidbody rb;
    public GameObject uiManager;
    private JumpState _jumpState = JumpState.Grounded;

    private void Awake()
    {
        UIManager uiMngr = uiManager.GetComponent<UIManager>();
        ServiceLocator.Register<UIManager>(uiMngr);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        Move();
    }

    private void Move()
    {
        //Set some local variables to the actual value of the axis;
        //Create a Vector3 variable, and we will assign X and Z to feature our horizontal and vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);
        rb.AddForce(movement);
    }

    private void Jump()
    {
        float jumpVal = Input.GetKeyDown(KeyCode.Space) ? jumpForce : 0.0f;

        switch (_jumpState)
        {
            case JumpState.Grounded:
                if (jumpVal > 0.0f)
                {
                    _jumpState = JumpState.Jumping;
                    Debug.Log("JumpState: " + _jumpState.ToString());
                }
                break;
            case JumpState.Jumping:
                if (jumpVal > 0.0f)
                {
                    _jumpState = JumpState.DoubleJumping;
                    Debug.Log("JumpState: " + _jumpState.ToString());
                }
                break;
            case JumpState.DoubleJumping:
                jumpVal = 0.0f;
                break;
        }

        Vector3 jumping = new Vector3(0.0f, jumpVal, 0.0f);
        rb.AddForce(jumping);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((_jumpState == JumpState.Jumping || _jumpState == JumpState.DoubleJumping) && collision.gameObject.CompareTag("Ground"))
        {
            _jumpState = JumpState.Grounded;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Pickup pickup = other.gameObject.GetComponent<Pickup>();
            if (pickup != null)
            {
                playerPoints += pickup.Collect();
                ServiceLocator.Get<UIManager>().UpdateScoreDisplay(playerPoints);
            }
        }
    }
}
