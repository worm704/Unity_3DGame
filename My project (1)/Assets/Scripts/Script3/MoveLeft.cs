using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed=30;

    public PlayerController3 PC_Script; //�ŧi�@�өM PlayerController3�@�˫��A���ܼơGPC_Script
    
    void Start()
    {
        PC_Script = GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    void Update()
    {
        if (PC_Script.gameOver == false)
        {
            //����C�����󩹥�����
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        
    }
}
