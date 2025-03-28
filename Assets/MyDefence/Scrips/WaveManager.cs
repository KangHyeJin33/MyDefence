using UnityEditor.Media;
using UnityEngine;
using System.Collections;
using TMPro;

namespace MyDefence
{
    //Enemy 스폰/웨이브를 관리하는 스크립트
    public class WaveManager : MonoBehaviour
    {
        //적 프리팹 만들기
        #region field
        public GameObject enemyPrefab;
        //적 스폰 위치
        public Transform startPoint;

        //타이머
        public float waveTimer = 5f; //시간 누적
        private float countdown = 0f;

        //웨이브 카운트
        private int waveCount = 0;

        //UI Countdown Text
        public TextMeshProUGUI countdownText;
        #endregion


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //필드 초기화
            countdown = 3f;
            waveTimer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            //타이머 구현
            countdown += Time.deltaTime; //한바퀴 도는데 걸리는 시간을 countdown에 누적
            if (countdown >= waveTimer) //countdown이 waveTimer가 지나면 아래 실행
            {
               
                    //타이머 기능
                    StartCoroutine(SpawnWave());


                    //타이머 초기화
                    countdown = 0f;
                
               }
            //UI
            countdownText.text = Mathf.Round(countdown).ToString();


            }
        void SpawnEnemy()//시작 지점에 enemy 한마리 스폰 함수로 만들기.
        {
            //시작 지점에 enemy 한마리 스폰.
            Instantiate(enemyPrefab, startPoint.position, Quaternion.identity);
        }

        //웨이브
        IEnumerator SpawnWave()//시작 지점에 enemy 한마리 스폰 함수로 만들기.
        {
            waveCount++;
           
            //시작 지점에 enemy 한마리 스폰.
            for (int i = 0; i <= waveCount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
           

        }
    }
}

