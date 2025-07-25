using UnityEngine;
//����Ƽ���� �����Ǵ� Ŭ���� ����� ��ũ��Ʈ�� �ۼ��մϴ�

//1. ����Ƽ�� transform Ŭ���� ���
//  Ʈ�������� ����Ƽ �����Ϳ��� ���� ������Ʈ�� ������ ��, ��� ���� ������Ʈ�� �⺻������ �ο��Ǵ� ������Ʈ�� �ǹ�
//  �ش� ������Ʈ�� ��ġ(position), ȸ��(rotation), ũ��(scale)�� ���� ������ ������ ����
//  ������Ʈ�� ����� ȣ���ϴ� getcomponent<T>�� ������� �ʰ� �ٷ� ��� ����

//  �ش� Ŭ������ �������ִ� �Ӽ�(property)

//  transform.position -> ���� ������Ʈ�� ��ġ ������ �ǹ�
//  Vector3 ������ ������ x,y,z���� ���� float

//  transform.rotation -> ���� ������Ʈ�� ȸ�� ������ �ǹ�
//  Quaternion ���¿� ������, x,y,z,w �� float

//  transform.forward -> ���� ������Ʈ ������ ������ ��Ÿ���� ��

//  transform.up -> ���� ������Ʈ �������� ����� ��Ÿ���� ��

//  transform.right -> ���� ������Ʈ �������� �������� ��Ÿ���� ��

//  transform.eulerAngles -> ���� ������Ʈ�� ȸ�� ������ �ǹ�
//  vector3 ������ ������, x,y,z �� float

//  tip) �޼ҵ� () �ȿ� �ۼ��� ������ �ش� ����� �����Ҷ� �������� ���� ���� ǥ��
//  -> �Ķ����(parameter)

//  �ش� Ŭ������ �������ִ� �ֿ� ����(�޼ҵ�)
//  transform.LookAt(transform target)
//  ������Ʈ�� �־��� Ÿ���� ���ϵ��� ���� ������Ʈ�� ȸ����Ű�� ���

//  transform.Rotate(Vector3 eulerAngles)
//  ���޹��� ������ �������� ���� ������Ʈ�� ȸ����Ű�� ���

//  transform.Translate(Vector3 translation)
//  �־��� �� (����)��ŭ ���� ������Ʈ�� �̵���Ű�� ���


public class sample3 : MonoBehaviour
{
    //Transform�� �̿��� ������Ʈ�� ������Ʈ ����
    public GameObject go;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(go.transform.GetComponent<sample4>().value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
