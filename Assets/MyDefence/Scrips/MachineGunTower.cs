using UnityEngine;
using System.Collections;

namespace MyDefence
{
    public class MachineGunTower : MonoBehaviour
    {
        #region Field
        //공격 범위
        public float attackRange = 7f;

        private Transform target; // 가장 가까운 적(최소거리에 있는 적(Enemy))

        //Enmey tag
        public string enemy = "Enemy";

        //search 타이머
        public float searchTimer = 5f; //시간 누적
        private float countdown = 0f; //카운트 다운(몇 초 간격으로 할지)

        //private int waveCount = 0;
        #endregion



        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //UpdateTartget 함수를 즉시 0.5초 마다 반복해서 호출한다
            InvokeRepeating("UpdateTaget", 0f, 5f); //0초후에 반복은 0.5초마다 한번 씩
        }

        //가장 가까운 적 찾기
        private void UpdateTaget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy); //enemies : 적 정보가 들어옴
            //머신건 거리 + Enemy 거리. 최소거리에 있는 Enemy가 타겟이 됨.

            //최소 거리(값)일때의 적 구하기
            float minDistance = float.MaxValue;
            GameObject nearEnemy = null;


            foreach (var enemy in enemies)
            {
                float distance = Vector3.Distance(this.transform.position, enemy.transform.position); // distance : 거리
                if (distance < minDistance) //distance가 minDistance보다 작으면
                {
                    minDistance = distance; //minDistance : 최소거리
                    nearEnemy = enemy;
                }

            }
            if (nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy.transform; //타겟 구하기
            }
            else
            {
                target = null;
            }
        }

        // Update is called once per frame //매 프레임마다 호출한다.
        void Update()
        {
            //가장 가까운 적 찾기
            UpdateTaget();

            //타이머 구현
            countdown += Time.deltaTime; //한바퀴 도는데 걸리는 시간을 countdown에 누적
            if (countdown >= searchTimer) //countdown이 waveTimer가 지나면 아래 실행
            {

                //타이머 기능(함수) 호출
               UpdateTaget();


                //타이머 초기화
                countdown = 0f;

            }
        }

        private void OnDrawGizmos() //OnDrawGizmos() : 이벤트 함수. ~Selected를 붙이면 구의 선이 사라진다.
        {
            Gizmos.color = Color.red; //클래스.클래스이름(static 정적 함수)
            Gizmos.DrawWireSphere(this.transform.position, attackRange); //타워를 중점을 잡고 간격만 있으면 '구'가 된다.
        }

        /*IEnumerator SpawnWave()//시작 지점에 enemy 한마리 스폰 함수로 만들기.
        {
            waveCount++;

            //시작 지점에 enemy 한마리 스폰.
            for (int i = 0; i <= waveCount; i++)
            {
                SpawnWave();
                yield return new WaitForSeconds(0.5f);
            }*/


        }
    }

