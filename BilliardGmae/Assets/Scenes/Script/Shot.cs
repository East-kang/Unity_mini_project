using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shot : MonoBehaviour       // 흰 공 치기 구현 함수
{
    private Rigidbody rb;               // 리지드바디
    public GameObject cue;              // 큐 오브젝트
    public GameObject toward;           // 큐 끝 오브젝트
    public GameObject ball;             // 공 오브젝트
    public int StartSpeed = 0;          // 공을 치는 힘
    public Vector3 shot;                // 공 방향 벡터
    public Vector3 lastVelocity;        // 갱신되는 공의 위치
    public float speed;                 // 공의 속도
    public int count=0;                 // 공의 정지 여부(0:정지, 1:움직임)
    Gaze g;                             // Gaze 스크립트 변수
    int y=0, r1=0, r2=0;                // 노란, 빨간 두 공의 충돌 여부
                                        // (y:흰-노 충돌시 1, 아니면 0)
                                        //(r1,2:흰-빨1,2 충돌 시 1, 아니면 0) 
    public int score_count = 0;         // 득점 계산할 타이밍(0:계산x, 1:계산o)
    public int score=0;                 // 현재 점수
      
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 리지드 바디 선언
        g = GameObject.Find("Gaze").GetComponent<Gaze>(); // 'Shot' 스크립트 연동
    }    // 리지드 바디 선언 및 Gaze 스크립트 연동
    void Update()
    {
        lastVelocity = rb.velocity;     // 공의 속도
        if (lastVelocity == Vector3.zero)
        {
            count = 0;
            if (score_count == 1)
            {
                if (y == 1)
                {
                    Debug.Log("실점" + y + r1 + r2);
                    score--;
                }
                else
                {
                    if (r1+r2 == 2)
                    {
                        Debug.Log("득점" + y + r1 + r2);
                        score++;
                    }
                    else if (r1 + r2 == 0)
                    {
                        Debug.Log("실점" + y + r1 + r2);
                        score--;
                    }
                    else if(r1 + r2 == 1)
                    {
                       Debug.Log("아까비" + y + r1 + r2);
                    }
                }
                Debug.Log("점수 : " + score);
                y = r1 = r2 = 0;
                score_count = 0;
            }
        }
        else
        {
            count = 1;
            score_count = 1;
        }

        if (Input.GetMouseButton(0))
            if (StartSpeed <= 600)
                StartSpeed++;
            else
                StartSpeed = 0;
        if (Input.GetMouseButtonUp(0))
            StartSpeed = 0;
    }    // 공의 속도 갱신 
                        // 주기적인 점수 계산
                        // 게이지 value 측정
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("wall"))             // "ball"이라는 태그의 물체 충돌 시
        {
            speed = lastVelocity.magnitude; // 충돌 시 공의 속도
            var dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = dir * Mathf.Max(speed, 0f);
        }
        if (collision.gameObject.tag.Equals("Yball"))
        {
            //speed = lastVelocity.magnitude; // 충돌 시 공의 속도
            //var dir = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);
            //rb.velocity = dir * Mathf.Max(speed, 0f);
            y = 1;
            Debug.Log("Y");
        }
        if (collision.gameObject.tag.Equals("Rball1"))
        {
            //speed = lastVelocity.magnitude; // 충돌 시 공의 속도
            //var dir = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);
            //rb.velocity = dir * Mathf.Max(speed, 0f);
            r1 = 1;
            Debug.Log("r1");
        }
        if (collision.gameObject.tag.Equals("Rball2"))
        {
            //speed = lastVelocity.magnitude; // 충돌 시 공의 속도
            //var dir = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);
            //rb.velocity = dir * Mathf.Max(speed, 0f);
            r2 = 1;
            Debug.Log("r2");
        }
    }
                        // 흰공-벽 or 흰공-다른공 충돌 시
                        // 속도와 방향 벡터 계산
                        // 공의 충돌 여부 확인
    private void OnMouseUp()
    {
        shot = toward.transform.position - cue.transform.position;    // 치는 방향 벡터
        rb.AddForce(shot * g.gaze.value, ForceMode.Force);    // 공 치기
        count = 1;
    }
                        // 공에 가해질 힘 구현
}