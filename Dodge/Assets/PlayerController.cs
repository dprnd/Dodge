using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �̵��� ����� ������ٵ� ������Ʈ
    public Rigidbody playerRigidbody;
    // �̵� �ӷ�
    public float speed = 3f;
    // �� �ڽ��� ���� ����
    public GameObject my;

    private void Start()
    {
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã��
        //playerRigidbody�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ������� �������� �Է°��� �����ؼ� ����
        float xInput = Input.GetAxis("Horizontal");
        // Ű���� : 'A', <- : ���ǹ��� : -1.0f
        // Ű���� : 'D', -> : ���ǹ��� : +1.0f
        float zInput = Input.GetAxis("Vertical");
        // Ű���� : 'W', �� : ���ǹ��� : +1.0f
        // Ű���� : 'S', �� : ���ǹ��� : -1.0f
    }
    void DirectInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
    }

    void Die()
    {
        my.SetActive(false);
        //gameObject.SetActive(false);   ����Ƽ�� �˾Ƽ� �������ֱ���(���)
        //gameObject -> ����   GameObject -> �������� Ÿ��,����
    }
}
