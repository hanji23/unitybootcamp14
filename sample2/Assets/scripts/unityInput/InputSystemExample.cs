using UnityEngine;
using UnityEngine.InputSystem;

//player input�� �����ؾ� ���
//RequireComponent(typeof(T))�� �� ��ũ��Ʈ�� ������Ʈ�� ����� ��� �ش� ������Ʈ�� �ݵ�� t�� ������ �־�� �մϴ�
//���� ����� �ڵ����� ������ְ�, ���ڵ尡 �����ϴ� �� �����Ϳ��� ���� ������Ʈ�� �ش� ������Ʈ�� ������ �� �����ϴ�
[RequireComponent(typeof(PlayerInput))]
public class InputSystemExample : MonoBehaviour
{
    //���� Action Map : Sample
    //  Action : Move
    //  Type : Value
    //  Compos : Value2
    //  Binding : 2D Vector(wsad)

    private Vector2 moveInputValue;
    private float speed = 5f;

    //send messages�� ����ϴ� ���
    //Ư��Ű�� ������ Ư���Լ��� ȣ�� �մϴ�
    //�Լ� ���� On + Action name,
    //���� ���� Action�� �̸� Move��� �Լ����� OnMove�� �˴ϴ�

    void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInputValue.x, 0, moveInputValue.y); //�¿� x�� ���� z��
        transform.Translate(move * speed * Time.deltaTime);

        //���� ��ǥ��(world Space)
        //�� ��ü�� �������� ����ϴ� ���� ��ǥ
        //�߽� ��ǥ -> (0,0,0)
        //x : �¿�,
        //y : �� �Ʒ�,
        //z : �� ��
        //�������
        //Ư¡) ��� ���� ������Ʈ�� �����ϴ� �������� ���� ����
        //�� ������ ��𼭵� ���� ��ġ�� ������ ������ �˴ϴ�

        //���� ��ǥ��(Local Space)
        //Ư�� ������Ʈ ������ ��ǥ
        //������Ʈ�� ��ġ, ȸ��, ũ�⸦ �������� ��ǥ�� ����
        //������Ʈ�� ���⿡ ���� �����̰� ��

        //���߿� ���� �����ϴ� ������ �̵�
    }
}
