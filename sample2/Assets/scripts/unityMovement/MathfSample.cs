using UnityEngine;
//중요 클래스 Mathf
//유니티에서 수학 관련으로 제공되는 유니티 클래스
//게임 개발에서 사용될수 있는 수학 연산에 대한 정적메소드 와 상수를 제공합니다

//ex)정적 메소드 : static 키워드로 구성된 해당 메소드는 클래스명, 메소드명()으로 사용이 가능합니다. Mathf.Abs(-5);

public class MathfSample : MonoBehaviour
{
    //기본적으로 사용되는 메소드
    float abs = -5;
    float ceil = 4.1f;
    float floor = 4.6f;
    float round = 4.5f;
    float clamp;
    float clamp01;
    float pow = 2;
    float sqrt = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"Mathf.Abs(abs) <- {abs}");      //절댓값(absolute number)
        Debug.Log($"Mathf.Ceil(ceil) <- {ceil}");    //올림(소숫점과 상관없이 올림처리)
        Debug.Log($"Mathf.Floor(floor) <- {floor}");  //내림(소숫점과 상관없이 내림처리)
        Debug.Log($"Mathf.Round(round) <- {round}");  //반올림(유니티에선 5이하면 내리고 6이상이면 올림처리)
        //뒤에 ToInt를 붙여 정수로 바꾸기 가능 ex)RoundToInt

        Debug.Log($"Mathf.Clamp(7, 0, 4) <- 7, 0, 4");//현재 전달 받은 값 = 7, 최소 = 0, 최대 = 4, 결과               -> 4, 값, 최소, 최대 순으로 값을 입력합니다
        Debug.Log($"Mathf.Clamp01(5) <- 5");    //현재 전달 받은 값 = 5, 최소와 최대가 각각 0과 1로 자동 설정됨 -> 벗어나면 최솟값 0 또는 최댓값 1로 처리
        //퍼센트 개념의 값을 처리할때 자주 사용되는 코드
        //최소 최대 범위에 따라 0과 1이 결정됩니다
        //Clamp vs Clamp01
        //Clamp     => 체력, 점수, 속도 등의 능력치 개념에서의 범위제한
        //Clamp01   => 비율(퍼센트), 보간 값(t), 알파값(투명도)

        Debug.Log($"{Mathf.Pow(pow, 2)} <- {pow}제곱 ");       //값, 제곱수(지수)를 전달 받아서 해당수의 거듭 제곱을 계산( pow^2, pow²)
        Debug.Log($"{Mathf.Pow(pow, 0.5f)} <- {pow} 제곱근");  //Mathf.Sqrt()로 계산하는것보다 연산이 매우 느림
        Debug.Log($"{Mathf.Pow(pow, -2)} " +          //2의 -2제곱 -> 1/4
            $"지수가 음수일 경우 값은 역수 형태로 계산");   
        Debug.Log($"{Mathf.Sqrt(sqrt)} <- {sqrt}");    //값을 전달 받아 해당 값의 제곱근을 계산
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
