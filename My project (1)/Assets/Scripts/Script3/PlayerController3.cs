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

    public Animator playerAnim;//�ŧi����@�Ӫ��a���ʵe���
    public ParticleSystem playerExplodation;
    public ParticleSystem playerDirt;
    public AudioClip soundJump;
    public AudioClip soundCrash;
    public AudioSource playerSound;

    
    void Start()
    {
        //��o���骺�����v
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity = Physics.gravity * gravityMod; //�վA���O

        playerAnim = GetComponent<Animator>();
        playerSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        //�אּ�i�G�q���覡(���h�G�q��)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false; //����1�Gfalse
            twiceJump++; //twiceJump = twiceJump + 1;
            //print("��������: " + twiceJump);
            playerAnim.SetTrigger("Jump_trig");
            playerAnim.speed = 1;
            playerDirt.Stop();
            playerSound.PlayOneShot(soundJump, 2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; //����2�Gtrue
            twiceJump = 0;
            playerAnim.speed = 2;
            playerDirt.Play();
            
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            print("Game Over!!!");

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            playerExplodation.Play();
            playerDirt.Stop();
            playerSound.PlayOneShot(soundCrash, 1);
            
        }
        
        
    }

}
