using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallReflection : MonoBehaviour     // 벽 반사 구현 함수
{
    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.tag.Equals("ball")))
        {                                                       // 공 충돌 시
            Shot b = collision.gameObject.GetComponent<Shot>(); // 'Shot' 스크립트 연동

            Vector3 income = b.shot;                            // 공의 방향 벡터
            Vector3 normal = collision.contacts[0].normal;      // 벽의 법선 벡터
            b.shot = Vector3.Reflect(income, normal).normalized;// 공의 방향 벡터를 벽 반사 벡터로 정규화
        }
        if ((collision.gameObject.tag.Equals("Yball")))
        {                                                       // 공 충돌 시
            BallConflict b = collision.gameObject.GetComponent<BallConflict>(); // 'Shot' 스크립트 연동

            Vector3 income = b.shot;                            // 공의 방향 벡터
            Vector3 normal = collision.contacts[0].normal;      // 벽의 법선 벡터
            b.shot = Vector3.Reflect(income, normal).normalized;// 공의 방향 벡터를 벽 반사 벡터로 정규화
        }
        if ((collision.gameObject.tag.Equals("Rball1")))
        {                                                       // 공 충돌 시
            BallConflict b = collision.gameObject.GetComponent<BallConflict>(); // 'Shot' 스크립트 연동

            Vector3 income = b.shot;                            // 공의 방향 벡터
            Vector3 normal = collision.contacts[0].normal;      // 벽의 법선 벡터
            b.shot = Vector3.Reflect(income, normal).normalized;// 공의 방향 벡터를 벽 반사 벡터로 정규화
        }
        if ((collision.gameObject.tag.Equals("Rball2")))
        {                                                       // 공 충돌 시
            BallConflict b = collision.gameObject.GetComponent<BallConflict>(); // 'Shot' 스크립트 연동

            Vector3 income = b.shot;                            // 공의 방향 벡터
            Vector3 normal = collision.contacts[0].normal;      // 벽의 법선 벡터
            b.shot = Vector3.Reflect(income, normal).normalized;// 공의 방향 벡터를 벽 반사 벡터로 정규화
        }
    }    
    // 각 공과 충돌 시 공의 방향 벡터, 벽의 법선 벡터, 정규화 수행
}
 