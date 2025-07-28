using UnityEngine;

public class sample2 : MonoBehaviour
{
    public sample1 sample1;

    private void Awake()
    {
        sample1 = GameObject.FindWithTag("s1").GetComponent<sample1>();
        //1. GameObject.FindWithTag("태그이름")
        // 씬에서 해당 태그를 가지고 있는 오브젝트를 검색하는 기능
        //2. GameObject.getComponent<T>
        // 게임 오브젝트는 getComponent<T>를 통해 T에 컴포넌트의 유형을 작성해주면 해당 게임 오브젝트가 컴포넌트로 가지고있는 값을 가져옴

        // 이 기능을 통해 받아오는 값 -> T

        Debug.Log(sample1.cc.massage);

        //edit -> project settings -> script execution order
        //유니티에서는 script execution order 기능을 통해 스크립트 처리 순서에 대한 설정을 진행 할수 있음
        //숫자가 클수록 나중에 실행됨
    }

}
