using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConflict : MonoBehaviour   // 흰공 제외한 공 충돌 구현 함수
{
    Rigidbody rb;                           // 리지드 바디
    public Vector3 shot;                    // 공 방향 벡터
    public float speed;                     // 충돌 시 공의 속도
    public Vector3 lastVelocity;            // 갱신되는 공의 위치

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 리지드 바디 선언
    }       // 리지드 바디 선언
    void Update()
    {
        lastVelocity = rb.velocity;     // 시간에 따른 공의 속도 갱신
    }      // 시간에 따른 공의 속도 변화 갱신
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("wall"))    // 벽과 충돌 시
        {
            speed = lastVelocity.magnitude;             // 충돌 시 공의 속도
            var dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);   // 충돌 후 방향 벡터
            rb.velocity = dir * Mathf.Max(speed, 0f);   // 충돌 후 속도
        }
    }      
                         // 벽과 충돌 시 공의 순간 속도와 반사 벡터를 구하기
}
