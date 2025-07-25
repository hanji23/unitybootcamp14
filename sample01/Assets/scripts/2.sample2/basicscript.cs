using A;
using UnityEngine;
// 1. 유니티 엔진 관련 기능을 사용
//  해당코드 내에서 사용되는 특정 기능들은 UnityEngine 네임 스페이스의 기능으로 해석됨

//네임 스페이스는 특정 데이터를 묶어주는 용도로 사용할수 있음(이름충돌 문제를 해결)
//분류를 하는 것이 목적
namespace A
{
    public class item
    {
        public int id;
    }
}

namespace B
{
    public class item
    {
        public int id2;
    }
}

// (1) 네임 스페이스. 클래스명과 같이 네임스페이스를 직접 작성해서 사용하는 경우
// (2) using을 이용해 해당 코드 내에서 사용하는 값은 그 네임스페이스의 값임을 알리고 사용하는 경우

public class basicscript : MonoBehaviour
// 2. 클래스의 이름은 basicscript
//  이 스크립트는 MonoBehaviour의 기능을 포함하고 있음(C#의 상속)
//  스크립트의 이름과 같은 class가 반드시 존재해야함

//  MonoBehaviour 클래스는 에디터에서 게임오브젝트에 스크립트를 컴포넌트로써 연결할수 있는 프레임워크를 제공
//  start, update와 같은 이벤트에 대한 연결도 제공

{
    // 3. 유니티 생명 주기 (이벤트)
    // 유니티에서는 스크립트를 실행할 경우 사전에 지정한 순서대로 여러개의 이벤트 함수가 실행됨
    // 사용자는 해당 이벤트 함수에서 기능을 작성하는것으로 원하는 상황에 맞는 작업을 처리할 수 있음
    void Start()
    {
        item item = new item();
        //위에 있는 using A에 의해 이 item은 자동으로 A의 item을 의미하게 됨

        B.item item2 = new B.item();
        //네임스페이스를 작성해줌으로써 해당 위치의 item임을 표현

        Debug.Log("");
    }

    void Update()
    {
        
    }
}
