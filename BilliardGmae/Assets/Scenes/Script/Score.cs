using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour  // 점수 출력 구현 함수
{
    Shot s;                         // Shot 스크립트 변수
    public Text text;               // 텍스트 변수

    void Start()
    {
        s = GameObject.Find("WhiteBall").GetComponent<Shot>();
        text = GetComponent<Text>();
    }    // 텍스트 변수 설정

    void Update()
    {
        text.text = "Score : " + s.score.ToString();
    }    // 스코어 텍스트 입력
}
