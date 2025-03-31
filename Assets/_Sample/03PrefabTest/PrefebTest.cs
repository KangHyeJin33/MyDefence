//타일 게임 오브젝트로 추가 안하고 프리팹으로 만들기
using System.Collections;
using UnityEngine;

namespace Sample
{

    public class PrefebTest : MonoBehaviour
    {
        //타일 프리팹
        public GameObject tilePrefeb;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            /*for (var i = 0; i < 100; i++)
            {
                Instantiate(tilePrefeb, new Vector3(i * 10f, 0, 10f), Quaternion.identity);
            }*/
            //[1] 하나 생성
            //Vector3 position = new Vector3(5f, 0, 8f); //생성할 위치 지정
            //Instantiate(tilePrefeb, position, Quaternion.identity); //Quaternion.identity 값 : 0, 0, 0(기본 값)
            //[2] 10(n)x10(m)개 생성 - 5 x 5, 7 x 7.
            //GenerateMap2(10, 10);

            //[3] 타일을 생성 - x : 0~500사이의 랜덤값, y : 0, z : z좌표를 -500 ~ 0 사이의 랜덤값.
            /*for (int i = 0; i < 10; i++)
            {
                Tiles();
            }*/

            //[4] 타일을 10개 생성, 타일 하나 생성 할 때마다 딜레이 0.2초 준다
            //코루틴 Coroutine 함수 : 0.2초 지연
            StartCoroutine(GenerateRandomMap());
        }

        /*void GenerateMap(int row, int column)
        {
            for (int i = 0; i < row; i++) //행
            {
                for (int j = 0; j < column; j++) //열
                {
                    Vector3 position = new Vector3(j * 5f, 0f, i * -5f);
                    Instantiate(tilePrefeb, position, Quaternion.identity);
                }

            }
        }*/
        /*void GenerateMap2(int row, int column)
        {
            for (int i = 0; i < row; i++) //행
            {
                for (int j = 0; j < column; j++) //열
                { 
                    GameObject go = Instantiate(tilePrefeb, this.transform);
                    go.transform.position = new Vector3(j * 5f, 0f, i * -5f);
                    //GameObject에 접근해서 사용가능.
                }

            }
        }*/

        void Tiles()
        {
            float xPos = Random.Range(0f, 50f);
            float zPos = Random.Range(-50f, 0f);
            Vector3 position = new Vector3(xPos, 0f, zPos);
            Instantiate(tilePrefeb, position, Quaternion.identity);

            /*for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    GameObject game = Instantiate(tilePrefeb, this.transform);
                    game.transform.position = new Vector3(j * 500f, 0f, i * -500f);*/
        }

        IEnumerator GenerateRandomMap()
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 position = new Vector3(Random.Range(0f, 50f), 0f, Random.Range(-50f, 0f));
                Instantiate(tilePrefeb, position, Quaternion.identity);

                //0.2초 딜레이
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}




/*
타일을 10x10(크기)으로 배치

 */