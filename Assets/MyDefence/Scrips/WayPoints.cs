using UnityEngine;

namespace MyDefence
{
    //Waypoint들의 정보를 가져오는 클래스

    public class WayPoints : MonoBehaviour
    {
        #region field
        public static Transform[] wayPoints;
        #endregion

        private void Awake()
        {
            //필드 초기화
            wayPoints = new Transform[this.transform.childCount]; //자식 오브젝트만큼의 배열 생성

            for (int i = 0; i < wayPoints.Length; i++)
            {
                wayPoints[i] = this.transform.GetChild(i);
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }
    }
}
