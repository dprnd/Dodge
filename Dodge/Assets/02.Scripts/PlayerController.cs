﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동에 사용할 리지드바디 컴포넌트
    public Rigidbody playerRigidbody;
    // 이동 속력
    public float speed = 6f;
    // 내 자신을 담을 변수
    public GameObject my;

    private void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아
        //playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 수평축과 수직축의 입력값을 감지해서 저장
        float xInput = Input.GetAxis("Horizontal");
        // 키보드 : 'A', <- : 음의방향 : -1.0f
        // 키보드 : 'D', -> : 양의방향 : +1.0f
        float zInput = Input.GetAxis("Vertical");
        // 키보드 : 'W', ▲ : 양의방향 : +1.0f
        // 키보드 : 'S', ▼ : 음의방향 : -1.0f

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 0f, zSpeed) 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        //Vector3는 데이터형태에 newVelocity라는 변수를 만든것
        //꼭 new (Vector3)를 사용해야함

        //리지디바디의 (물리적인 힘이 아니라) 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;
        //누적은 +=

        // 한줄로 축약 가능
        //playerRigidbody.velocity = new Vector3(xInput * speed, 0f, zInput * speed);
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

    public void Die()
    {
        my.SetActive(false);
        //gameObject.SetActive(false);   유니티가 알아서 진행해주긴함(편법)
        //gameObject -> 변수   GameObject -> 데이터의 타입,형태

        // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }
}
