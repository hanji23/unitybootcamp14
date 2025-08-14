using System;
using UnityEngine;

//C# event 526p

//event : 특정 상황이 발생했을때 알림을 보내는 매커니즘
// 1. 플레이어가 죽었을때 알림 전달 -> 메소드 호출
//Action

//public class Tester : MonoBehaviour
//{

//    private void Start()
//    {
//        cs8_eventExample eventExample = new cs8_eventExample();
//        eventExample.onDeath?.Invoke();
//        //eventExample.onStart?.Invoke(); //event 키워드가 있을 경우 외부에서 호출 불가능

//        eventExample.onDeath = null;
//        //eventExample.onStart = null; // event 키워드는 대입이 불가능합니다

//        eventExample.onDeath += Samples;
//        eventExample.onStart += Samples; // 구독 / 해제 가능
//    }

//    private void Samples()
//    {

//    }
//}

public class cs8_eventExample : MonoBehaviour
{
    //                  Action,         event Action 차이
    //외부 호출             O                   X
    //외부 대입             O                   X
    //구독기능              O                   O
    //구독취소              O                   O
    //주 용도      내부로직, 콜백            이벤트 알림

    public Action onDeath;
    public event Action onStart;

    private void Start()
    {
        //액션은 += 통해 함수(메소드)를 액션에 등록할수 있습니다 (구독)
        //액션은 -= 통해 함수(메소드)를 액션에서 제거 할수 있습니다 (해제)
        //액션의 기능을 호출하면 등록되어있는 함수가 순차적으로 호출됩니다
        onStart += Ready;
        onStart += Fight;

        onDeath += Damaged;
        onDeath += Dead;

        onStart?.Invoke(); // onStart에 등록된 기능을 수행하는 코드 (Invoke("함수", 지연시간) 하고는 다름)
        onDeath?.Invoke();
        
        //함수 처럼 호출하는 것도 가능합니다
        onStart();
        onDeath();
        //둘의 차이는 없음(성능을 포함해서) 문법 스타일 차이
        //대신 Invoke 방식이면 null체크 가능 -> 외부에서의 호출, 안전성 요구시 추천
        //함수 형태는 따로 설계 -> 내부 코드 이거나 단순 호출일 경우 해당 방식 추천
    }

    private void Fight()
    {
        Debug.Log("<color=yellow><b>시작!</b></color>");
    }

    private void Ready()
    {
        Debug.Log("<color=cyan><b>준비</b></color>");
    }

    private void Dead()
    {
        Debug.Log("<color=red><b>죽음</b></color>");
    }

    private void Damaged()
    {
        Debug.Log("<color=blue><b>아야</b></color>");
    }
}
