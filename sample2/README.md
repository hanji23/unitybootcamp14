# 유니티 스크립트 예제
unitybootcamp14 project

## 유니티의 생명주기

> 유니티에서는 프로그램의 실행부터 종료까지의 작업 영역을 함수로 제공합니다.
> 
>(유니티에서는 스크립트의 실행, 활성화, 프레임 당 호출등 상황에 맞게 작업할 수 있는 작업 공간이 존재)
>
>>tip) 프로그래밍에서 함수는 특정 하나의 기능을 수행하기 위해서 명령문들을 모아놓은 명령 집합체
>>
>스크립트 내에서 이벤트 함수를 작성하고, 내부에 진행할 명령문을 작성하면 상황에 맞게 해당 기능이 수행됨

|Awake|OnEnable(OnDisable)|Start|Update|FixedUpdate|LateUpdate|
|------|------|------|------|------|------|

### **[Awake]**
>씬이 시작될 때 한번만 호출되는 영역
>
>해당 스크립트가 비활성화되어 있어도 이 위치의 작업은 실행됨. 다만 해당 영역에서 코루틴으로 실행이 불가
>>코루틴(coroutine) : 코드를 일시 중지하고 특정 조건이 충족될때까지 실행을 delay 시킬수 있는 기능(ex. 3초 뒤에 오브젝트를 파괴)
>>
>각 스크립트 기준 한 번만 호출이 되고 다른 개체의 초기화가 완료가 된 후 호출 되는 영역이기 때문에 다른 컴포넌트에 대한 참조를 만들어야 하는 경우 이 위치에서 만들면 안전하게 처리 됨

### **[OnEnable]** // 반대 OnDisable()
>해당 위치는 오브젝트 또는 스크립트가 활성화 될때 호출됨
>
>이벤트에 대한 연결에 사용됨
>
>해당 위치에서는 코루틴 사용이 불가

### **[Start]**
>모든 스크립트의 Awake가 다 실행된 이후 실행되는 영역
>
>해당 영역에서는 코루틴에 대한 실행이 가능


```cs
    //awake, start의 공통점
    //둘 다 기본적으로 값에 대한 초기화(할당)를 수행하는 위치
    //어떤 것을 사용해도 상관 없으나 상황에 따라 설계함

    //awake : 변수 초기화, 값 참조
    //start : 게임 로직에 대한 실행, 초기화된 데이터를 기반으로 작업 수행, 코루틴 작업
```

### **[Update]**
>화면에 렌더링 되는 주기가 1초에 약 60번정도 호출됨(하드웨어 성능에 따라 차이가 날수 있음)
>
>time.deltatime을 통해 이전 프레임 ~ 현재 프레임까지의 시간 차이로 보정값을 주거나
>
>정규화 / 단위 벡터를 이용해 작업을 처리합니다.
>
>기본적으로 계산에 보정값들이 많이 사용됨
>
>프로그램 내에서 핵심적으로 계속 사용되는 메인 로직을 짜는 위치로 사용
>>ex) 키 입력등을 기반으로 움직임(지속적인 업데이트가 요구되는 경우)

```cs
    //Update 대체할수 있는 수단
    //1. 상황에 맞는 유니티 생명 주기 코드
    //2. 코루틴
    //3. 이벤트 시스템(버튼 클릭 / 충돌감지 등)
    //4. c#의 가상 함수 개념(update를 대신해 특정 클래스에서 업데이트 로직을 처리함)
    //   특정 하나의 관리 클래스(manager)에 update의 로직을 위임해 관리해서 사용
```
>업데이트는 써야하는 기능이고, 가장많이 사용되는 영역
>
>따라서 업데이트에서 무조건 실행되는 상황이 아니라면 다른 영역에서 작업을 하게 설계하는것이 업데이트 부담을 줄여줄수있고 이게 성능의 향상으로 이어짐
>
> -> 업데이트의 사용을 피하면 피할수록 성능은 올라가긴 함. 숙지 후 사용 할 것


### **[FixedUpdate]**
>일정한 발생 주기가 보장되어야 하는 로직에서 사용됩니다.
>
>물리 연산 (rigidbody)이 적용된 오브젝트에 대한 조정
>
>프레임을 기반으로 처리되는 것이 아닌 Fixed TimeStep이라는 설정된 값에 의해 일정 간격으로 호출됩니다.
>
>*TimeScale이 0으로 설정된 경우 멈춤
>

### **[LateUpdate]**
>모든 update 함수(Update, FixedUpdate)가 호출된 다음에 마지막으로 호출되는 영역
>
>후처리 과정에 사용
>
>LateUpdate가 여러개일 경우 상황에 맞는 호출 순서가 중요

## 오브젝트 캐싱에 대하여(object cashing)
### **[캐시(cash)]**
>자주 사용되는 데이터나 값을 미리 복사해두는 임시 장소

**캐시 사용 의도**
>1. 시간 지역성 : 가장 최근에 사용된 값이 다시 사용될 가능성이 높다
>
>2. 공간 지역성 : 최근에 접근한 주소와 인접한 주소의 변수가 사용될 가능성이 높음

```cs
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();//캐싱(cashing)
    }

    void Update()
    {
        GetComponent<Rigidbody>().AddForce(pos * 5);//프레임마다 호출
    }
```

## 유니티 클래스_벡터

### **[값(value), 참조(reference)]**
>값 : 변수에 데이터가 직접 저장 됩니다. ex) int a = 5;
>
>참조 : 변수에 데이터가 저장된 메모리 주소값이 저장되는 경우
>
>>ex) Vectorsample = new Vectorsample(); 클래스는 대표적인 참조 타입

### **[메모리 저장 영역]**
>프로그램이 실행되기 위해서는 운영체제(os)가 프로그램의 정보를 메모리에 로드해야합니다
>
>프로그램이 실행되는 동안 중앙제어장치(cpu)가 코드를 처리하기 위해 메모리가 명령어와 데이터들을 저장 하고 있어야합니다
>
>컴퓨터 메모리는 바이트(byte)단위로 번호가 새겨진 선형 공간을 의미합니다
>
>낮은 주소로 부터 높은 주소까지 저장되는 영역이 다르게 설정되어 있습니다
>
>>낮은 주소 : 메모리의 시작부분
>>
>>높은 주소 : 메모리의 끝부분

### **[대표적인 메모리 공간]**
>1. 코드(code) : 실행할 프로그램 코드가 저장되는 영역(텍스트 영역)
>
>>cpu에서 저장된 명령을 하나씩 가져가서 처리합니다
>>
>>프로그램 시작부터 종료까지 계속 남아있는 값
>>
>2. 데이터(data) : 프로그램에서 전역 변수, 정적 변수가 저장되는 영역
>
>>전역변수(global) : 프로그램 어디서나 접근 가능한 변수(C#에서는 전역 대신 클래스 수준의 정적 변수를 사용)
>>
>>정적변수(static) : static가 붙은 변수는 별도의 객체생성 없이 클래스명, 변수명으로 직접 접근하는 것이 가능합니다.
>>
>>프로그램 시작 시에 할당이 되고 그 이후부터 종료 시점까지 유지
>>
>3. 힙(heap)  : 프로그래머가 직접 저장공간에 대한 할당과 해제를 진행하는 영역
>
>>값에 대한 등록도, 값에 대한 제거도 프로그래머가 설계합니다.(c,c++)
>>
>>특징) 참조 타입은 힙에 저장됩니다.
>>
>>c#의 힙 영역의 데이터는 GC에 의해 자동으로 관리됩니다.
>>
>>저장 순서, 정렬에 대한 작업을 따로 신경 쓸 필요가 없습니다.
>>
>>단 메모리가 크고, GC에 의해 자동으로 처리되는 만큼 많이 사용하면 그만큼 성능이 저하됩니다.
>>
>>접근 속도가 느린편입니다.
>>
>4. 스택(stack) : 프로그램이 자동으로 사용하는 임시 메모리 영역
>
>>함수 호출시 생성되는 변수(지역변수, 매개변수)가 저장되는 영역
>>
>>함수의 호출이 완료되면 사라지는 데이터, 이때의 호출 정보 == stack frame(스택 프레임)
>>
>>매우 빠른 속도로 접근이 가능합니다.(할당과 해제의 비용이 사실상 없음)
>>
>>데이터가 먼저 들어온 데이터가 누적되고 가장 마지막에 남은 데이터가 먼저 제거되는 방식(LIFO)

```cs
    //c# 에서 new 키워드는 힙에 대한 할당이 아니라 값에 대한 초기화를 의미합니다
    //struct에서의 new -> 초기화
    //class에서의 new -> 힙에 인스턴스 생성
```
### **[벡터의 특징]**
>1. 값 타입(value)으로 참조가 아닌 값 그 자체를 의미 (구조체 struct) -> 계산이 빠르게 처리됨
>
>2. 값을 복사할 경우 값 그 자체를 복사하시만 하면 됨
>
>3. 벡터에 대한 계산 보조기능이 많이 제공됨(magnitude, normalized, Dot, Cross...)
>
>4. 벡터는 스택(stack) 영역의 메모리에서 저장됨

### **[벡터의 요소]**
>x : x축의 값
>
>y : y축의 값
>
>z : z축의 값
>
>w : 셰이더나 수학계산등에서 사용되는 Vector4에서의 w축
```cs
    public Vector3 A = new Vector3(); // xyz가 자동적으로 0(zero 벡터)
    public Vector3 B = new Vector3(3, 4); //x와 y에 대한 정보 전달, z는 자동적으로 0
    public Vector3 C = new Vector3(5, 6, 7);

    public Vector2 D = new Vector2(8, 9);
```
### **[벡터의 Distance]**
```cs
        //현재 큐브의 위치를 벡터로 설정
        Vector3 posA = A_cube.position;
        Vector3 posB = B_cube.position;

        //두 벡터의 차 -> 방향 벡터
        Vector3 BtoA = posB - posA;
        Vector3 AtoB = posA - posB;

        //거리 측정
        //Distance의 수학적 로직
        // a = (ax, ay, az), b = (bx, by, bz) 라고 할때
        // 두 벡터 사이의 거리는 각 축에 대한 차의 제곱의 합에 대한 루트 값
        // -> √{(bx - ax)^2 + (by - ay)^2 + (bz - az)^2}

        // 유니티의 Mathf 클래스를 기반으로 바꾸면?
        Vector3 dif = posB - posA;
        float distance = Mathf.Sqrt(dif.x * dif.x + dif.y * dif.y + dif.z * dif.z);
        Debug.Log("Mathf : " + distance);

        // 벡터 Distance 이용
        distance = Vector3.Distance(posA, posB);
        Debug.Log("Distance" + distance);
```
### **[벡터의 Lerp, Slerp]**
>Lerp
>
>>Vector3.Lerp(start, end, t);
>>
>>start -> end 까지 t에 따라 선형 보간 합니다. -> 해당 방향으로 일정 간격 천천히 이동하는 코드
>>
>>t의 범위는 (0 ~ 1)이고 float
```cs
    public Transform target;
    public float speed = 1.0f;

    private Vector3 start_position;
    private float t = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (t < 1.0f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(start_position, target.position, t);
        }
    }
```

