﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 이동에 사용할 리지드바디 컴포넌트
    private Rigidbody bulletRigidbody;
    // 탄알 이동 속력
    public float speed = 8f;
    

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력;
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);


    }


    // a, b 충돌이 난걸 알려주는게 리지드바디 
    // 충돌 정보를 리지드바디가 콜라이더에 전해줌

    // 트리거 충돌 시 자동으로 실행되는 메서드
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가졌나요?
        if (other.tag == "Player")
        {
            // 상대방(충돌한) 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            // (다중 플레이어가 있다면 내캐릭터 값이 아닌 다른값을 가져올수 있어서)
            if (playerController != null)
            {
                // playerController 컴포넌트의 Die()메서드 실행
                playerController.Die();
            }
        }
    }

    void Update()
    {
        
    }
}
