using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityMod = 0;

    public bool isOnGround = true; //�O�_�K�M�a�O

    public int twiceJump = 0; //�G�q���p��

    public bool gameOver = false;
    
    void Start()
    {
        //��o���骺�����v
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity = Physics.gravity * gravityMod; //�վA���O
    }

    void Update()
    {
        //�אּ�i�G�q���覡(���h�G�q��)
        if (Input.GetKeyDown(KeyCode.Space) && twiceJump <2)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false; //����1�Gfalse
            twiceJump++; //twiceJump = twiceJump + 1;
            //print("��������: " + twiceJump);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; //����2�Gtrue
            twiceJump = 0;
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            print("Game Over!!!");
        }
        
        
    }

}
