using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.Events 네임스페이스 연결이 필수
//유니티 이벤트

//C#의 event와의 차이점
//1. 인스펙터에서 확인이 가능하다
//2. 추가 제거 기능을 +=, -= 으로 하지 않고 AddListener와 RemoveListener로 진행합니다

//                  UnityAction     vs     UnityEvent  
//타입                delegate                class
//기능                함수 참조               에디터에서 핸들러 직접등록 가능
//구독                  +,-                   AddListener(), RemoveListener()
//사용상황      스크립트 코드 내 처리         인스펙터용 이벤트 시스템
//속도                  빠름                  느림(연결 정보에 대한 파싱 후 런타임 실행 방식)
//메모리                적음                  많음
//GC 발생여부           낮음                  높음
//편의성          자체 설계 해야함            바로 사용 가능 쉽고 편함

//UnityAction은 unityEvent를 사용하는 코드를 설계할 때 효과적입니다.
//일반 delegate는 UnityAction<T>와 같이 타입에 대한 설정이 안되어있어 따로 만들어서 사용해야 합니다

//사용할수 있는 선택지
//1. C# delegate
//2. Unity UnityAction 
//3. C# Func<T>, Action<T>


//이 다양한 delegate들을 언제 어떤걸 사용해야하는가?
// 고성능을 원한다     -> C# delegate

//   콜백              -> Action, UnityAction

// UnityEvent와의 연결 -> UnityAction
//    인스펙터 연결

// 이벤트 시그니처     -> delegate, Func(Return), Action
// 필요(유연하게 설계)

//이벤트 시그니처 : 호출되는지에 정의한 함수 형태
//C#의 EventHandler의 선언
//ex) delegate void EventHandler(object sender, EventArgs e)

//시그니처
//1.반환타입(void)
//2.매개변수(object, EventArgs)

public class cs1_EventSample3 : MonoBehaviour
{
    public UnityEvent OnKButtonEnter; 
    public UnityAction OnAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //OnKButtonEnter += Sample(); // C#의 event 처럼 넣으면 오류
        OnKButtonEnter.AddListener(Sample);

        OnAction += Sample2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            OnKButtonEnter?.Invoke();
        }
    }

    private void Sample()
    {
        Debug.Log("<color=cyan>Sample 실행</color>");
    }

    private void Sample2()
    {
        Debug.Log("<color=green>Sample2 실행</color>");
    }
}
