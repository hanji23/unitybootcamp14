using UnityEngine;
//버튼의 onclick에 등록할 기능

public class skeletoncontroller : MonoBehaviour
{
    public GameObject skeleton;
    //public void 메소드명()
    //{
    //  이 메소드를 실행할 경우 실행할 명령문을 작성하는 위치
    //}

    public void onLButtonEnter()
    {
        skeleton.transform.Translate(1, 0, 0);
    }

    public void onRButtonEnter()
    {
        skeleton.transform.Translate(-1, 0, 0);
    }
}
