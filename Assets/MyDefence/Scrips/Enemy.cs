using Unity.VisualScripting;
using UnityEngine;

namespace MyDefence
{

    public class Enemy : MonoBehaviour
    {
        //필드
        #region Field
        public float speed = 5f;

        private Vector3 targetPosition;
        //wayPoint 오브젝트의 트랜스폼 객체
        private Transform target;
        //wayPoint 배열의 인덱스
        private int wayPointIndex = 0;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            wayPointIndex = 0;
            target = WayPoints.wayPoints[wayPointIndex];
        }

        // Update is called once per frame
        void Update()
        {
            //이동 구현
            Vector3 dir = target.position - this.transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World); //Space.World : 글로벌 방향

            //target 도착 판정
            float distance = Vector3.Distance(target.position, this.transform.position);

            for (int i = 0; i < distance; i++)
            {

                if (distance <= 0.1f)
                {
                    Debug.Log("도착 !");
                    //다음 타겟 셋팅
                    GetNextTarget();

                    //wayPointIndex++; //1번
                    //targetPosition = WayPoints.wayPoints[wayPointIndex].position; //2번
                    //targetPosition = WayPoints.wayPoints[2].position;
                    //targetPosition = WayPoints.wayPoints[3].position;


                }
            }
            //for (int i = 0; i < WayPoints.wayPoints.Length; i++)
            //{

            //}


        }

        //다음 타켓포지션 얻어오기
        void GetNextTarget()
        {
            //종점 도착 판정
            if (wayPointIndex == WayPoints.wayPoints.Length - 1) //7부터
            {
                Debug.Log("종점 도착");
                Destroy(this.gameObject);
                return;
            }
            wayPointIndex++; //1번

            target = WayPoints.wayPoints[wayPointIndex]; //2번



        }
    }
}
