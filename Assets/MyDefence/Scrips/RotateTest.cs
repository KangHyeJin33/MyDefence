using UnityEngine;


namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        //필드
        private float x;
        //회전 속도
        public float turnSpeed = 5f;
        //이동 속도
        public float moveSpeed = 5f;

        //타겟 오브젝트
        public Transform target; //외부에 접근

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f); // this.transform : RotateTest가 붙어있는 transform의 객체(x축)
            //this.transform.rotation = Quaternion.Euler(0f, 90f, 0f); //y축
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f); //z축
        }

        // Update is called once per frame
        void Update()
        {
            //y축 기준으로 +(플러스)회전하기
            //x += 1; //1씩 누적
            //this.transform.rotation = Quaternion.Euler(0f, x, 0f); //제자리에서 회전
            //x축 기준으로 +(플러스)회전하기
            //x += 1; //1씩 누적(위에 있으니 생략 가능)
            //this.transform.rotation = Quaternion.Euler(x, 0f, 0f); //제자리에서 회전

            //z축 기준으로 +(플러스)회전하기
            //x += 1; //1씩 누적(위에 있으니 생략 가능)
            //this.transform.rotation = Quaternion.Euler(0f, 0f, x); //제자리에서 회전

            //y축 기준으로 속도 5로 회전하기
            //x += Time.deltaTime * 5;
            //this.transform.rotation = Quaternion.Euler(0f, x, 0f);

            //y축 기준으로 속도 5로 회전하기. (원하는 방향(축) * 회전속도 * 이동속도) - 자전
            //this.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed); //앞방향(y축 - Vector3.up)기준으로 회전.
            //타겟 오브젝트 중심으로 회전하기 - 공전
            //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);

            //타겟 방향으로 회전하기
            //Vector3 dir = 타겟위치 - 현재위치
            //Vector3 dir = target.position - this.transform.position; //방향을 먼저 구하고 회전
            //방향 벡터(Vector3)로 부터 그쪽 방향(Quaternion)을 바라보는 값
            //Quaternion targetRotarion = Quaternion.LookRotation(dir); //Quaternion값(dir)을 구하고
            //transform.rotation = targetRotarion; //Quaternion값을 rotation에
            //Quaternion lookRotation = Quaternion.Lerp(this.transform.rotation, targetRotarion, Time.deltaTime * turnSpeed); //lookRotation : 목표 값
            //Y축 연산을 위해 Euler(오일러)값 얻어오기
            //Vector3 euleRotation = lookRotation.eulerAngles;
            // Euler(오일러)값으로 Quaternion(쿼터니언)값 구하기
            //this.transform.rotation = Quaternion.Euler(0f, euleRotation.y, 0f);
            //this.transform.rotation = targetRotarion;

            //회전 + 이동
            //타겟 방향 구하기
            Vector3 dir = target.position - this.transform.position;
            //방향 벡터로 부터 그쪽 방향을 바라고는 회전 값 구하기
            Quaternion rotation = Quaternion.LookRotation(dir);
            //this.transform.rotation = Quaternion.LookRotation(dir);
            this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
            //this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.Self); //플레이어 기준으로 로컬.
            this.transform.rotation = rotation;





        }
    }
}
/*
Quaternion(쿼터니언)
Euler(오일러)

[1] Euler(오일러)값에서 Quaternion(쿼터니언) 값 구하기
오일러는 3자리 값인데, 3자리에서 4자리 값 구하기
Quaternion(쿼터니언) 값 = Quaternion.Euler(Euler x, Euler y, Euler z)

[2] Quaternion(쿼터니언) 값에서 Euler(오일러)값 구하기
쿼터니어는 4자리 값인데, 4자리에서 3자리 값 구하기
var angles = Quaternion(rotation.eulerAngles).eulerAngle //transform.rotation : 쿼터니언
 */