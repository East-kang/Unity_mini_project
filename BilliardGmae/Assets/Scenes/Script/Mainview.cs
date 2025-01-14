using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainview : MonoBehaviour   // 메인 뷰 구현 함수
{
    public GameObject Camera;   // 카메라 오브젝트
    public GameObject cue;      // 큐 오브젝트
    public GameObject ball;     // 공 오브젝트
    Shot s;                     // Shot 스크립트 변수
    int count = 0;              // 정지된 공의 순간적 위치를 저장할 카운트 값
                                // (0 : 정지된 순간, 1 : 정지)
    // Start is called before the first frame update
    void Start()
    {
        s = GameObject.Find("WhiteBall").GetComponent<Shot>();  // WhiteBall 오브젝트 내 Shot 함수
    }    // Shot 스크립트와 연동
    void Update()
    {
        if (s.count == 0)       // 
        {
            if (count == 0)     // 정지된 순간
            {
                Camera.transform.position = new Vector3(ball.transform.position.x, 3.0f, ball.transform.position.z - 3);
                // 
                Camera.transform.rotation = Quaternion.Euler(20, 0, 0);
                count = 1;
            }
            if (count <= 1)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    Camera.transform.RotateAround(ball.transform.position, Vector3.down, Time.deltaTime * 30f);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    Camera.transform.RotateAround(ball.transform.position, Vector3.up, Time.deltaTime * 30f);
                }
            }
        }
        else if(s.count == 1)
        {
            Camera.transform.position = new Vector3(7.04f, 13.6f, -16.22f);
            Camera.transform.rotation = Quaternion.Euler(50, -30, 0);
            count = 0;
        }
    }    // 공이 정지 여부를 확인하여 카메라의 위치와 각도 변환
                        // 키보드 입력 시 카메라의 뷰도 큐와 함께 회전하도록 설정
}
