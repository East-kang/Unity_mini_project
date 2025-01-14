using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCue : MonoBehaviour    // 큐 움직임 구현 함수
{
    public GameObject ball; // 공 오브젝트
    public GameObject cue;  // 큐 오브젝트
    public float x, y, z;   // 공의 좌표 변수
    public float a, b, c;   // 큐의 좌표 변수
    public float a1, c1;    // 변화된 큐의 좌표 변수
    public float k;         // 공과 큐 사이의 거리 비율
    Shot s;                 // Shot 스크립트
    Gaze g;                 // Gaze 스크립트
    public int count = 0;   // 공이 멈춘 순간을 나타낼 변수(0:공이 멈춘 순간, 1:순간 이후)
    

    // Start is called before the first frame update
    void Start()
    {
        s = GameObject.Find("WhiteBall").GetComponent<Shot>(); // 'Shot' 스크립트 연동
        g = GameObject.Find("Gaze").GetComponent<Gaze>(); // 'Gaze' 스크립트 연동
    }    // Shot과 Gaze 스크립트 연동
    void Update()
    {
        x = ball.transform.position.x;
        y = ball.transform.position.y;
        z = ball.transform.position.z;
       
        
        if (s.count == 0)   // 공이 멈춘 순간
        {
           if (count == 0)
            {
                cue.transform.position = new Vector3(x, y, z - 6);
                cue.transform.rotation = Quaternion.Euler(0, 90, 90);
                count = 1;
            }
            if (count <= 1)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    cue.transform.RotateAround(ball.transform.position, Vector3.down, Time.deltaTime * 30f);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    cue.transform.RotateAround(ball.transform.position, Vector3.up, Time.deltaTime * 30f);
                }
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                a = cue.transform.position.x;
                b = cue.transform.position.y;
                c = cue.transform.position.z;
            }
            if (Input.GetMouseButton(0))
            {
                k = g.gaze.value / (float)60.0;
                a1 = a + k * (a - x) / 6;
                c1 = c + k * (c - z) / 6;
                cue.transform.position = new Vector3(a1, b, c1);
            }
            if(Input.GetMouseButtonUp(0))
            {
                cue.transform.position = new Vector3(a, b, c);
            }
        }
        else if(s.count == 1)                // 공이 움직이는 동안
        {
            cue.transform.position = new Vector3(100, 100, 100);
            count = 0;
        }
    }    // 공과 큐의 위치를 계속 갱신
                        // 공이 정지 상태이면 키보드 입력으로 스트로크 방향 조절
                        // 게이지에 따른 큐의 움직임 구현
}