using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 5f;
    [SerializeField] float boostSpeed = 10f;
    bool canMove = true;
    float se2d_speed;

    Rigidbody2D rb2d;
    SurfaceEffector2D se2d;

    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        se2d = FindObjectOfType<SurfaceEffector2D>();
        se2d_speed = se2d.speed;
        boostSpeed += se2d_speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            se2d.speed = boostSpeed;

        }
        else
        {
            se2d.speed = se2d_speed;
        }
    }

    private void RotatePlayer()
    {

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    public void DisableControlles()
    {
        canMove = false;
    }
}
