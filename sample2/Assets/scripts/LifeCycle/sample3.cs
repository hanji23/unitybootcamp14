using UnityEngine;
using static UnityEditor.PlayerSettings;

public class sample3 : MonoBehaviour
{
    Rigidbody rb;
    Vector3 pos;

    //������Ʈ ĳ�̿� ���Ͽ�(object cashing)

    //ĳ��(cash)
    //���� ���Ǵ� �����ͳ� ���� �̸� �����صδ� �ӽ� ���

    //ĳ�� ��� �ǵ�
    // 1. �ð� ������ : ���� �ֱٿ� ���� ���� �ٽ� ���� ���ɼ��� ����
    // 2. ���� ������ : �ֱٿ� ������ �ּҿ� ������ �ּ��� ������ ���� ���ɼ��� ���� 

    void Start()
    {
        rb = GetComponent<Rigidbody>();//ĳ��(cashing)
    }

    void Update()
    {
        GetComponent<Rigidbody>().AddForce(pos * 5);//�����Ӹ��� ȣ��
    }
}
