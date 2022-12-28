using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityMod = 0;

    public bool isOnGround = true; //是否貼和地板

    public int twiceJump = 0; //二段跳計數

    public bool gameOver = false;
    
    void Start()
    {
        //獲得剛體的控制權
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity = Physics.gravity * gravityMod; //調適重力
    }

    void Update()
    {
        //改為可二段跳方式(頂多二段跳)
        if (Input.GetKeyDown(KeyCode.Space) && twiceJump <2)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false; //切換1：false
            twiceJump++; //twiceJump = twiceJump + 1;
            //print("跳的次數: " + twiceJump);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; //切換2：true
            twiceJump = 0;
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            print("Game Over!!!");
        }
        
        
    }

}
