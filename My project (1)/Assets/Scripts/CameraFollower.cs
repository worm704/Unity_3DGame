using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [Header("�C������"), Tooltip("�Щ�A�n���H���C������")]
    public GameObject player;

    [Header("��v�������q")]
    public Vector3 offset = new Vector3(0, 5, -7); //�ŧi�@�� offset �s�y��
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //�⦹�{������m�ѷ� player�C�����󪺦�m
        transform.position = player.transform.position + offset; //��v�����y�Х[�W�u�����q�v
    }
}
