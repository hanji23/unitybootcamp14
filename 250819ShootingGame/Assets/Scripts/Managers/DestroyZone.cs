using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        other.gameObject.SetActive(false);
    }

    //태그 : 단일
    //오브젝트에 대한 식별 용도
    //트리거, 물리충돌에 대한 비교
    //비교시 할당없이 태그 비교가 가능한 CompareTag가 사용됨
    //(CompareTag는 해당 태그가 실제로 존재하는지의 여부도 내부에서 체크해주며, 에러로 찍어준다)

    //유니티에서 gameObject에서 문자열을 가져오는 경우 문자열의 복제본이 생성됩니다.

    //레이어 : 묶음
    //레이어의 용도
    //1. 선택적 렌더링
    //카메라등에서 특정 레이어만 렌더링하는 설정을 처리할수 있습니다.
    //2. 레이어 충돌 메트릭스 설정
    // 레이어를 기반으로 충돌 감지 여부를 설정할 수 있습니다.
    //실제로 오브젝트간의 체크가 해제된 부분에 대해서는 연산처리를 하지않기 때문에 불필요한 연산이 줄어들게되고 이는 자원과 시간을 아끼는 행위
    //3. 레이캐스트 충돌
    //LayerMask를 통해 특정 레이어와의 충돌을 판정 할수 있다.
    //4. 정렬 레이어
    //게임 오브젝트 내에서의 렌더링 순서를 정의하는 기능
}