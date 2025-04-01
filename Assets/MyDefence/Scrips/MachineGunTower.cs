using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

namespace MyDefence
{
    //MachineGunTower
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
        //private float countdown = 1f; //카운트 다운(몇 초 간격으로 할지)

        //터렛 헤드 회전
        public Transform parToRotate;
        public float turnSpeed = 5f;

        //shoot 타이머 - 1초에 한발씩 발사
        public float shootTime = 1f;
        private float shootCountdown = 0;

        //Bullt 발사
        //불렛 프리팹
        public GameObject bulletPrefab;
        //발사 위치
        public Transform firePoint;

        #endregion
        


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //UpdateTartget 함수를 즉시 0.5초 마다 반복해서 호출한다
            InvokeRepeating("UpdateTaget", 0f, 0.5f); //0초후에 반복은 0.5초마다 한번 씩

        
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
                //Debug.Log("Find Taget!");
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
            //UpdateTaget();

            /*//타이머 구현
            countdown += Time.deltaTime; //한바퀴 도는데 걸리는 시간을 countdown에 누적
            if (countdown >= searchTimer) //countdown이 waveTimer가 지나면 아래 실행
            {

                //타이머 기능(함수) 호출
                UpdateTaget();


                //타이머 초기화
                countdown = 0f;

            }*/

            //타겟이 없으면
            if (target == null)

                return;

            //타겟 조준
            LockOn();

            //타겟팅이 되면 터렛이 1초마다 1발씩 쏘기 

            shootCountdown += Time.deltaTime;
            if (shootCountdown >= shootTime)
            {
                //타이머 기능 - 1발씩 쏘기
                Shoot();

                //타이머 초기화
                shootCountdown = 0f;
            }
          
        }
       
        
        void LockOn()
        {
            //터렛 헤드 회전
            Vector3 dir = target.position - this.transform.position; //dir : 방향. 적이 없는 것(정상 - null값)이라 작동을 안함.
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            Quaternion lookRotantion = Quaternion.Lerp(parToRotate.rotation, targetRotation, Time.deltaTime * turnSpeed);
            Vector3 eulerRotation = lookRotantion.eulerAngles; //4자리에서 3자리 구하기
            parToRotate.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f); //eulerRotation.y : 3자리의 값을 저장
        }

        //탄환 발사
        private void Shoot()
        {
            Debug.Log("Shoot!");
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Bullet bullet = bulletGo.GetComponent<Bullet>();
            bullet.SetTarget(target);
        }



        //Lerp 연산.
        //Lerp() 함수 : Lerp(A(Start), B(End), t(0~1값이 들어 올 때)
        //t가 0일 때 : A값을 줌. t가 1일 때 : b값을 줌. t가 0.5일 때 : a부터 b까지의 절반 값 -> (a+b)/2.
        //Value 값을 리턴 값을 A로 받는다.
        //거리가 10(B)일때 t가 0.1이면 1(a : 0.1)만큼 가고, 9의 10/1 만큼 가서 0.9->1.9(a)만큼 간다. 1.9(a)~10(B) : 거리는 8.1이다.
        //1.9(a)~10(B) : 거리는 8.1이다. 1.9 - 10 = 8.1


        private void OnDrawGizmos() //OnDrawGizmos() : 이벤트 함수. ~Selected를 붙이면 구의 선이 사라진다.
        {
            Gizmos.color = Color.red; //클래스.클래스이름(static 정적 함수)
            Gizmos.DrawWireSphere(this.transform.position, attackRange); //타워를 중점을 잡고 간격만 있으면 '구'가 된다.
        }

        

    }
}


