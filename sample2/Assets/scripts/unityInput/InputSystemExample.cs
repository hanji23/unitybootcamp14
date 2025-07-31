using UnityEngine;
using UnityEngine.InputSystem;

//player input이 존재해야 사용
//RequireComponent(typeof(T))는 이 스크립트를 컴포넌트로 사용할 경우 해당 오브젝트는 반드시 t를 가지고 있어야 합니다
//없는 경우라면 자동으로 등록해주고, 이코드가 존재하는 한 에디터에서 게임 오브젝트는 해당 컴포넌트를 제거할 수 없습니다
[RequireComponent(typeof(PlayerInput))]
public class InputSystemExample : MonoBehaviour
{
    //현재 Action Map : Sample
    //  Action : Move
    //  Type : Value
    //  Compos : Value2
    //  Binding : 2D Vector(wsad)

    private Vector2 moveInputValue;
    private float speed = 5f;

    //send messages로 사용하는 경우
    //특정키가 들어오면 특정함수를 호출 합니다
    //함수 명은 On + Action name,
    //현재 만든 Action의 이름 Move라면 함수명은 OnMove가 됩니다

    void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInputValue.x, 0, moveInputValue.y); //좌우 x축 상하 z축
        transform.Translate(move * speed * Time.deltaTime);

        //월드 좌표계(world Space)
        //씬 전체를 기준으로 사용하는 절대 좌표
        //중심 좌표 -> (0,0,0)
        //x : 좌우,
        //y : 위 아래,
        //z : 앞 뒤
        //방향고정
        //특징) 모든 게임 오브젝트가 공유하는 기준점과 축을 가짐
        //씬 내에서 어디서든 같은 위치와 방향을 가지게 됩니다

        //로컬 좌표계(Local Space)
        //특정 오브젝트 기준의 좌표
        //오브젝트의 위치, 회전, 크기를 기준으로 좌표라 설정
        //오브젝트의 방향에 따라 움직이게 됨

        //나중에 백터 설명하는 곳으로 이동
    }
}
