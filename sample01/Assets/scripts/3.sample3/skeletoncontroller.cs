using UnityEngine;
//��ư�� onclick�� ����� ���

public class skeletoncontroller : MonoBehaviour
{
    public GameObject skeleton;
    //public void �޼ҵ��()
    //{
    //  �� �޼ҵ带 ������ ��� ������ ��ɹ��� �ۼ��ϴ� ��ġ
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
