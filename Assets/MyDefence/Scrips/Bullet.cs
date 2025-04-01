using UnityEngine;

namespace MyDefence
{
    //탄환(발사체)를 관리하는 클래스
    public class Bullet : MonoBehaviour
    {
        #region Field
        //타겟 오브젝트 생성
        private Transform target;

        //이동속도
        public float moveSpeed = 70f;

        //발사 위치
        //public Transform firePoint;

        /*//shoot 타이머 - 1초에 한발씩 발사
        public float shootTime = 1f;
        private float shootCountdown = 0;*/

        #endregion

        public void SetTarget(Transform _target)
        {
            this.target = _target;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (target == null) //타겟이 없어지면
            {
                Destroy(this.gameObject);
                return; //막는다.
            }

            //이동하기
            //dir.magnitude : 두 벡터간의 거리
            Vector3 dir = target.position - this.transform.position;
            float detanceThisFrame = Time.deltaTime * moveSpeed; //이번 프레임에 이동하는 거리
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
            if (dir.magnitude <= detanceThisFrame)
            {
                HitTartget();
                return;
            }
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
        }
       

        void HitTartget()
        {
            Debug.Log("타겟 격파!");
            //타겟 게임 오브젝트 킬
            Destroy(target.gameObject);
            //탄환 게임오브젝트 킬
            Destroy(this.gameObject);
        }

          /* Quaternion targetRotation = Quaternion.LookRotation(dir);
           Debug.Log("총탄 발사!");
           Instantiate(target, this.transform.position, firePoint.rotation);*/

        }
    }
