using Unity.VisualScripting;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("[1] Awake 실행"); //단 1회만 실행
    }

    private void OnEnable()
    {
        Debug.Log("[6-1] OnEnable 실행"); //(게임오브젝트가 활성화될 때)1회씩 실행
    }

    private void Start()
    {
        Debug.Log("[2] Start 실행"); //단 1회만 실행
    }

    private void FixedUpdate()
    {
        Debug.Log("[3] FixdUpdate 실행"); //1초에 50 프레임(한 바퀴 도는 것) 고정. 연산량이 적든 많든.
    }

    private void Update() //자동으로 생김
    {
        Debug.Log("[4] Update 실행"); //매 프레임마다 호출. 1초에 30번이든 1초에 300번이든 구현이 안되있으면 돌아간다.
                                    //연산 실행 속도, 양에 따라 1초에 50번 도는걸 1초에 100번, 1초에 100번 도는걸 1초에 50번 돌 수 있다.
    }

    private void LateUpdate()
    {
        Debug.Log("[5] LateUpdate 실행"); //Update()실행 뒤에 바로 따라서 실행된다.
    }

    private void OnDisable()
    {
        Debug.Log("[6-2] OnDisable 실행"); //(비 활성화될 때) 1회씩 실행.
    }

    private void OnDestroy()
    {
        Debug.Log("[7] OnDestroy 실행"); //(비 활성화될 때)1회만 실행.
    }
}

