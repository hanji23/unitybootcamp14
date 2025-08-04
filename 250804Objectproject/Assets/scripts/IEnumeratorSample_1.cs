using System.Collections;
using UnityEngine;

public class IEnumeratorSample_1 : MonoBehaviour
{
    class CustomCollection : IEnumerable
    {
        int[] numbers = { 6, 7, 8, 9, 10 };

        //GetEnumerator를 통해 순회가능한 데이터를 IEnumerator 형태의 객체로 변환
        public IEnumerator GetEnumerator()
        {
            for(int i =0; i < numbers.Length; i++)
            {
                yield return numbers[i];
            }
        }
    }

    int[] numbers = { 1, 2, 3, 4, 5 };

    void Start()
    {
        //numbers 라는 배열을 순회할수 있는 IEnumerator 형태의 데이터로 변환 합니다
        IEnumerator enumerator = numbers.GetEnumerator();

        while (enumerator.MoveNext())
        {
            Debug.Log(enumerator.Current);
        }

        CustomCollection collection = new CustomCollection(); //커스텀 커렉션 생성

        //foreach는 순환가능한 데이터를 순차적으로 작업할때 사용하는 for문임으로 보기가 간결해집니다
        foreach (int number in collection)
        {
            Debug.Log(number);
        }

        foreach (var message in GetMessage())
        {
            Debug.Log(message);
        }
    }

    //yield는 C#에서 한번에 하나 씩 값을 넘기고 메소드가 일시 정지되며 후속 값들을 지속적으로 반환하게 됩니다
    //(반복적인 작업, 순차적인 데이터 처리에 사용됩니다)

    //yield는 yield return, yield break는 사용됩니다
    //yield return은 메소드가 값을 반환하면서 그 지점에서 메소드 실행을 일시 중지 시킵니다
    //호출자가 다음 값을 요구 할때 까지 대기합니다.
    //yield break는 메소드에서의 반복을 종료하는 코드 입니다.(실행 종료)

    //yield return을 사용하는 메소드는 IEnumerable 또는 IEnumerator 인터페이스를 구현하게 됩니다
    //컬렉션을 자동으로 순회하는 foreach와 자주 사용됩니다

    // 장점 : 값을 필요로 할 때 까지 계산을 미루는 방식(메모리 효율이 좋음, 큰데이터를 처리 할때 이점이 큽니다)
    // -> 모든 데이터를 저장하는게 아닌 필요한 부분만 처리 할수 있게 되기 때문

    //IEnumerable : 반복 가능한 컬렉션을 나타내는 인터페이스입니다.
    //  이 기능을 구현한 크래스는 반복할 수 있는 객체가 되며 foreach 등에서 순차적인 탐색을 진행 할수 있게 됩니다.
    //  해당 인터페이스를 구현하기 위해서는 GetEnumerator() 메소드를 제공하고, 사용자가 구현해야합니다.

    //IEnumerator : 반복을 관리하는 인터페이스 입니다.
    //  컬렉션에서 하나씩 항목을 반환하고, 그 상태를 관리하는 역할을 수행합니다
    //  MoveNext()를 통해서 다음 값을 접근 Current를 통해 현재값 확인 Reset()을 통해서 리셋 기능 처리

    static IEnumerable GetMessage()
    {
        Debug.Log("메소드 시작");
        yield return "야";
        Debug.Log("탈출 했다가 돌아옴1");
        yield return "호";
        Debug.Log("탈출 했다가 돌아옴2");
        yield break; //반복 순환 종료

        // -- unreachable code -- (접근불가 ↓)
        Debug.Log("탈출 했다가 돌아옴3");
        yield return "!!!";
    }
}
