using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gaze : MonoBehaviour   // 게이지 구현 함수
{
    public int max = 300;       // 게이지 최대값 변수
    public int value;           // 게이지 값 범위 조절 변수(0~600 -> 0~300~0)
    public Slider gaze;         // 실린더 변수
    Shot s;                     // Shot 스크립트

    // Start is called before the first frame update
    void Start()
    {
        s = GameObject.Find("WhiteBall").GetComponent<Shot>(); // 'Shot' 스크립트 연동
        gaze.value = 0;
    }     // 게이지 값을 0으로 초기화
    void Update()
    {
        value = s.StartSpeed;
        if (value <= 300)
            gaze.value = value;
        else
            gaze.value = 600 - value;
    }    // 0~300을 기준으로 게이지 업데이트

}
