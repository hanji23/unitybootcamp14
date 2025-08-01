# unitybootcamp14
unitybootcamp14 project

## Mathf
### 중요 클래스 Mathf
유니티에서 수학 관련으로 제공되는 유니티 클래스
게임 개발에서 사용될수 있는 수학 연산에 대한 정적메소드 와 상수를 제공합니다

ex)정적 메소드 : static 키워드로 구성된 해당 메소드는 클래스명, 메소드명()으로 사용이 가능합니다. Mathf.Abs(-5);

//기본적으로 사용되는 메소드
    float abs = -5;
    float ceil = 4.1f;
    float floor = 4.6f;
    float round = 4.5f;
    float clamp;
    float clamp01;
    float pow = 2;
    float sqrt = 4;
    
        Mathf.Abs(abs)      //절댓값(absolute number)
        Mathf.Ceil(ceil)    //올림(소숫점과 상관없이 올림처리)
        Mathf.Floor(floor)  //내림(소숫점과 상관없이 내림처리)
        Mathf.Round(round)  //반올림(유니티에선 5이하면 내리고 6이상이면 올림처리)
        //뒤에 ToInt를 붙여 정수로 바꾸기 가능 ex)RoundToInt

        Mathf.Clamp(7, 0, 4)//현재 전달 받은 값 = 7, 최소 = 0, 최대 = 4, 결과               -> 4, 값, 최소, 최대 순으로 값을 입력합니다
        Mathf.Clamp01(5)    //현재 전달 받은 값 = 5, 최소와 최대가 각각 0과 1로 자동 설정됨 -> 벗어나면 최솟값 0 또는 최댓값 1로 처리
        //퍼센트 개념의 값을 처리할때 자주 사용되는 코드
        //최소 최대 범위에 따라 0과 1이 결정됩니다
        //Clamp vs Clamp01
        //Clamp     => 체력, 점수, 속도 등의 능력치 개념에서의 범위제한
        //Clamp01   => 비율(퍼센트), 보간 값(t), 알파값(투명도)

        Mathf.Pow(pow, 2)       //값, 제곱수(지수)를 전달 받아서 해당수의 거듭 제곱을 계산( pow^2, pow²)
        Mathf.Pow(pow, 0.5f)    //Mathf.Sqrt()로 계산하는것보다 연산이 매우 느림
        Mathf.Pow(pow, -2)      //2의 -2제곱 -> 1/4 지수가 음수일 경우 값은 역수 형태로 계산  
        Mathf.Sqrt(sqrt)        //값을 전달 받아 해당 값의 제곱근을 계산

### Mathf 클래스에서 제공해주는 상수값
        Mathf.PI                //원주율 3.14159...
        Mathf.Infinity         //무한대
        //수학적 연산에 의해서 표현할수 있는 최대의 수를 넘는 경우라면 자동으로 처리되는값
        //직접적으로 Infinity를 작성해 명시적으로 무한대를 표현하기도 합니다.
        //1) Pow(0, -2) = 0^-2 = 1 / (0^2) = 1 / 0 -> (Infinity)
        //2) float 범위로 표현할 수 없는 큰 수를 제곱하는 경우, 연산 결과일 경우
        //  (+- 3.4 * 10^38)를 넘어서 오버플로우 현상이 발생할 경우 -> Infinity
        //float의 최댓값 -> float.MaxValue

        Mathf.NegativeInfinity  //음의 무한대
        //1) 음수에 대한 지수 연산이 오버플로우 되는 경우
        //2) 직접적으로 NegativeInfinity가 명시되는 경우
        //음의 무한대는 어떤 숫자도 될수 없는 음의 방향을 가리키는 개념

        Mathf.Sqrt(-1) // NaN(Not a Number) : 수학적으로 정의되지 않은 계산 결과일 경우 나오는 값
        //NaN에 대해
        //1. 두 값이 NaN일 경우 그 값에 대한 비교는 불가능 합니다(같은지 체크하면 flase)
        //   float,IsNaN(값)을 통해 해당값이 NaN인지만 확인이 가능합니다
        //2. Infinity -  Infinity = NaN
        //   0 / 0 과 같이 수학적으로 말이 아예 안되는 값
        //   음수에 대한 루트 계산 (허수나 복소수 같은 개념은 사용자가 따로 설게한 기능으로 수행한다)
        //   -> 유니티에서 허수에 대한 직접적인 지원을 하지 않습니다
        //   허수 -> 음의 제곱근 ex) sqrt(-1), 복소수 + a + bi 형태로 표현
        //   c# system.Numerics.Complex 기능을 통해 허수에 대한 계산이 가능합니다
        //      using system.Numerics;
        //      Complex c = Complex.Sqrt(-1);
        //      단점) 유니티 빌드 기준에 따라 사용이 제한되는 경우가 있습니다(ex WebGL)

        //NaN에 대한 방어 코드 작성시 활용
        //position이 만약 NaN일 경우 오브젝트가 씬에서 사라짐
        //Rigidboay에서 사용하는 값 중 velocity(속력)이 NaN일 경우 물리엔진 작용에 대한 고장 발생
        //Quaternion(회전)에서 사용하는 값이 NaN일 경우 회전이 끊기거나 깨지는 현상 발생 / 회전이 정상적으로 안됨
        
        Vector3 pos = transform.position;
        if (float.IsNaN(pos.x))
        {
            Debug.LogWarning("현재 위치에서 NaN발생! 원점이동!");
            pos = Vector3.zero;
        }

        // 그 이외의 값
        //1. Mathf.Deg2Rad() : Degree(각도)
        //                     transform.Rotate(0,90,0) -> y축으로 90도 만큼 회전
        //                     transform.eulerAngles -> 트랜스폼에서의 (x,y,z) 각도 표현(도)
        //                     Quaternion.AnglerAxis(45f, Vector3.up) // 45도만큼 회전
        //                     Vector3.Angle(A,B); -> A벡터와 B벡터 사이 각도(도)
        //                     Quaternion.Angle(A, B) -> 두 회전 간의 차이 각도(도)
        //                     유니티 인스펙터에서 보여지는 회전 입력 -> 도
        //                     유니티 애니메이션에서 사용하는 회전 속성 -> 도

        //2. Mathf.Rad2Deg() : Radian(수학적으로 사용되는 각도의 단위)
        //                     반지름과 같은 길이를 가진 호가 가진 중심각 = 1 라디안(57도, 약 60도)
        //                     유니티에서 제공해주는 삼각 함수 계산에서 각도대신 라디안을 요구함

        //유니티에서는 저 두기능을 통해 라디안 -> 도 / 도 -> 라디안으로의 변환을 처리합니다
        //결론) 라디란은 원의 길이, 각속도, 미분등의 작업을 진행할 때 (수학 / 물리 작업)
        //      계산이 더 간단하게 진행되고 따라서 유니티등에서 사용되는 삼각함수와 같은 계산식에서 사용됩니다

        //요약) Degree : 직접적인 회전에 대한 표현(입력, 보여지는 각)
        //      Radian : 삼각 함수를 활용한 각 계산

        //자주 사용되는 도와 라디안의 값
        //0             0       0
        //90          PI/2      90
        //180          PI       180
        //360         2PI       360

        //3. Mathf.Epsilon : float형에서 0이 아닌 가장 작은 양수 값(거의 0에 가까운 값)
        //      -> 미세한 값을 다룰 대 사용하는 값
        //         float에서 0f보다 Epsilon으로 0을 체크하면 안전하게 계산됩니다.
        //         0으로 나누는 상황을 방지합니다.

## 삼각함수

## 각도 이동

## 레이케스트

## 카메라 레이케스트 처리

## 유니티의 회전(Rotate)
1. 오일러 각(Euler Angle)에 의한 회전 - x, y, z ghlwjs rkqt
 유니티 인스펙터에서의 transform 컴포넌트의 Rotate에 표기된 값(각도 기준)
 ex)Rotate X 120 Y 45 Z 0 ->x축으로 120도 y축으로 45도 회전 되었음을 의미

2. 쿼터니언(Quaternion) - 회전을 계산하기에 안정적인 수학적인 방식을 가진 값
 유니티 엔진 내부에서 실제로 저장되고 계산되는 값

쿼터니언으로 처리하는 이유
 유니티에서 쿼터 -> 오일러 각 변환시 360도 이상의 회전은 보정될수 있음
 380도 회전 -> 20도 회전

짐벌 락 현상(Gimbal lock) : 오일러 각을 이용해 회전을 표현하는 경우에 발생하는 회전 자유도의 손실
 -> 어떤축이 다른축과 정렬 되는 순간, 한 축의 회전이 무효되면서 회전 방향이 3개가 아닌 2개만 남는 현상

쿼터니언의 구조
4차원 복소수 (x, y, z, w(스칼라)) 하나의 벡터(x, y, z), 하나의 스칼라 w
쿼터니언도 벡터처럼 방향인 동시에 회전의 개념을 가지고 있습니다. (벡터는 위치이면서 방향의 개념)
세축을 동시에 회전시켜 짐벌락 현상이 발생하지 않도록 구성되어있음(x,y,z는 항상 동시에 변화한다)
쿼터니언은 회전의 원점과 방향을 비교해 회전을 측정할 수 있습니다.
orientation : 방향

단점 : 180도 이상의 표현 불가
      직관적으로 바로 이해하기 어려운 구조

//오브젝트에 대한 회전 기능
         transform.Rotate()는 회전을 진행시키는 가장 기본적인 코드
         transform.Rotate(Vector3 eulerAngles);                       지정한 축을 기준으로 회전
         transform.Rotate(float x, float y, float z);                 로컬(게임 오브젝트) 기준의 회전
         transform.Rotate(Vector3 axis, float angle);                 특정 축을 중심으로 회전
         transform.Rotate(Vector3 axis, float angle, Space space);    월드 또는 로컬중에 선택

        월드 기준으로 z축 만큼 60도 회전
        transform.Rotate(Vector3.forward, 60f * Time.deltaTime, Space.World);

        게임 오브젝트를 기준으로 회전을 진행 합니다
        transform.Rotate(new Vector3(20, 20, 20) * Time.deltaTime);
        절대 좌표를 기준으로 회전을 진행합니다.
        transform.Rotate(new Vector3(20, 20, 20) * Time.deltaTime, Space.World);

//목표 방향으로 회전 시키는 코드
        Quaternion.LookRotation(Vector3 forward); 특정 방향을 바라보는 회전을 계산
        var targetRotation = Quaternion.LookRotation(target.position - transform.position);

        Quaternion.RotateTowards(위치, 타겟 위치, 속도);
        현재의 회전에서 타겟의 회전으로 일정 속도 부드럽게 회전을 진행하는 함수
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed);
        
        AroundRotate
        transform.RotateAround(pivot.position, Vector3.up, speed * Time.deltaTime);

쿼터니언 정리
Quaternion.identity = 회전없음
Quaternion.Euler(x, y, z) = 오일러각 -> 쿼터니언 변환
Quaternion.AngleAxis(angle, axis) 특정 축 기준의 회전
Quaternion.LookRotation(forward, upward[방향 (기본값default : Vector3.up)]) 해당 벡터 방향을 바라보는 회전 상태에 대한 return
 ↑ foward : 회전 시킬 방향(vector3)
    upward : 방향을 바라보고 있을 때의 위 부분을 설정(기본 값은 up으로 설정 되어 있어 특별한 경우가 아니면 건드릴 일이 없음)

회전 값 적용
transform.rotation = Quaternion.Euler(x, y, z); 현재 오브젝트의 회전 값을 적용합니다

회전에 대한 보간 
Quaternion.Slerp(from, to, t) : 구면 성형 보간
Quaternion.Lerp(from, to, t) : 선형 보간
Quaternion.RotateTowards(from, to, maxDegree) : 일정 각도 만큼 점진적으로 회전을 처리 합니다

transform.LookAt() vs Quaternion.LookRotation()

1. LookAt(target) : 추가 회전 보간이나 제어가 어렵고, 설정해준 값을 기준으로 transform.rotation을 자동으로 설정해주는 기능
내부에서 Quaternion.LookRotation()을 사용하는 방식)
 -> 그냥 날 바라봤으면 좋겠다

2. LookRotation(direction) 의 경우는 회전 값만 계산하고 적접적인 적용은 하지 않습니다. 
 -> 게산은 끝났으니 추가적인 작업으로 계산을 처리하면 되지 않을까?
