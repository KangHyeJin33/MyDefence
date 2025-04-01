using JetBrains.Annotations;
using UnityEngine;

namespace Sample
{
    public class HitTest : MonoBehaviour
    {
        struct CBox //구조체 만들기
        {
            //사각형 좌표 만들기
            public float x; //x좌표
            public float y; //y좌표
            public float w; //widh좌표
            public float h; //height좌표
        }

        struct CCircle
        {
            public float x; //x좌표
            public float y; //y좌표
            public float r; //반지름
        
        }


        //필드
        //타겟 오브젝트
        public Transform target;
        //이동속도
        public float moveSpeed = 100f;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //매개변수로 받은 두개의 box가 충돌했는지 체크
        //충돌하면 true반환, 충돌하지 않으면 flase 반환.
        private bool CheckHitBox(CBox a, CBox b)
        {
            
            float dx = (a.x > b.x) ? (a.x - b.x) : (b.x - a.x);
            float dy = (a.y > b.y) ? (a.y - b.y) : (b.y - a.y);

            if (dx <= (a.w/2 + b.w/2) && dy <=(a.h/2 + b.h/2)) //두 식을 모두 만족하면
            {
                return true;
            }
            return false;
        }

        //매개변수로 받은 두개의 box가 충돌했는지 체크
        //충돌하면 true반환, 충돌하지 않으면 flase 반환.
        private bool CheckHitCircle(CCircle a, CCircle b) //겹치는 두 개의 원 거리 구하기
        {
            float dx = a.x - b.x;
            float dy = a.y = b.y;

            //두 원의 거리
            //float distance = Mathf.Sqrt(dx * dx + dy * dy); //ex.(dx * dx) = dx의 제곱. Mathf.Sqrt : 루트 계산
            float distanceS = dx * dx + dy * dy; 

            //두 원의 거리보다 두 원의 반지름의 합이 더 크면 충돌
            if (distanceS <= (a.r + b.r) * (a.r + b.r)) //거리의 제곱
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //두 지점의 거리가 일정거리(0.5f) 안에 있으면 충돌이라고 판정
        private bool CheckArrivePosition()
        {
            float distance = Vector3.Distance(target.position, this.transform.position);

            if (distance < 0.5f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //타겟으로 이동할때 타겟까지 남은거리가 한 프레임에 이동하는 거리보다 작을 때 충돌이라고 판정
        private bool CheckPassPosition()
        {
            //타겟까지의 남은 거리
            float distance = Vector3.Distance(target.position, this.transform.position);
            //이번 프레임에 이동하는 거리
            //dir.nomalized * Time.deltatime* moveSpeed; //dir.nomalized : 방향만 결정. dir방향으로 Time.deltatime* moveSpeed 만큼 움직이겠다.
            float distanceThisFrame = Time.deltaTime * moveSpeed;

            if (distance <= distanceThisFrame) //남은거리가 짧으면
            {
                return true; //지나간다
            }
            return false;

        }
    }
}