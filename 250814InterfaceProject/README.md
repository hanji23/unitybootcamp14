# unitybootcamp14
unitybootcamp14 project

## 인터페이스(interface) ### C# - 560p~

인터페이스는 클래스 또는 구조체에 포함될수 있는 관련 있는 메소드들을 묶어서 관리하는것을 말합니다

### 작성순서
접근 제한자 interface 이름 { ... }

접근 제한자 class 자식클래스명 : 부모클래스, 인터페이스1, 인터페이스2, ...

클래스와 인터페이스를 같이 상속 할시 클래스를 먼저 상속해야함

```cs
// 기존의 클래스 상속 :
// 기능에 대한 재사용이 목적, 다중 상속이 불가능, 접근제한자에 대한 사용 가능
// 재사용성이 있는 코드의 기능을 물려줘 빠른 설계를 도와주는 도구

// 인터페이스 상속 :
// 기능에 대한 설계를 부탁함(중간 다리 역할), 인터페이스에 대한 상속가능,
// 다중 상속에 대한 허용(선언만 포함하기에 충돌문제가 거의 없음)
//  ㄴ구현의 주체는 결국 인터페이스를 구현할 '클래스' 자신
// 공통적인 동작에 대한 설계를 진행하는 도구

// -> 인터페이스는 결합도가 낮아서, 유연성이 높은 코드를 짜기 수월하다.

```

## 이벤트 시스템
컴포넌트가 씬에 존재해야함
```cs
// UI의 경우 그래픽 레이케스트 컴포넌트가 추가되어있어야하며, RAYcast의 target도 체크 되어있어야합니다
// 오브젝트의 경우에는 Collider / Collider2D 컴포넌트가 추가 되어 있어야 합니다.
// 메인 카메라에 Physics Raycaster가 추가되어 있어야 합니다.
```
제공되는 기능 기준 일반적인 순서
>1. Pointer Enter
>2. Pointer Down
>3. Begin Drag
>4. Dragging
>5. End Drag
>6. Pointer Up
>7. Pointer Exit
>8. Select
>9. Submit
>10. move
>11. Cancel

## C# event , Action 526p~
### event
특정메서드가 실행되는 결과, 특정 상황이 발생했을때 알림을 보내는 매커니즘

### Action
액션은 += 통해 함수(메소드)를 액션에 등록할수 있습니다 (구독)

액션은 -= 통해 함수(메소드)를 액션에서 제거 할수 있습니다 (해제)

액션의 기능을 호출하면 등록되어있는 함수가 순차적으로 호출됩니다

```cs
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

    //                  Action,         event Action 차이
    //외부 호출             O                   X
    //외부 대입             O                   X
    //구독기능              O                   O
    //구독취소              O                   O
    //주 용도      내부로직, 콜백            이벤트 알림
```

## Action<T> , Func
### Action<T>
Action<T> 최대 16개의 매개변수를 받을 수 있습니다.

반환값은 없습니다. (void)

전달이 목적이며, 결과는 받지않는 형태

### func는 마지막에 적히는 부분이 func가 사용할 함수의 반환 타입입니다.
```cs
    public Func<bool> func01;
    public Func<string, int> func02; //매개변수 : string, 반환 int
```
