using UnityEngine;
//�ﰢ�Լ� 
//����Ƽ���� �������ִ� �ﰢ�Լ��� �ַ� ȸ��, ī�޶� ����, �, �����ӿ� ���� ǥ������ ���˴ϴ�.
//Ư¡) ������ �������� ����մϴ�. 1���� = �� 57��

public class Tfunction : MonoBehaviour
{
    //���
    //Sin(Radian) : �־��� ��ǥ�� y��ǥ (���ι���)
    //Cos(Radian) : �־��� ��ǥ�� x��ǥ (���ι���)
    //Tan(Radian) : �־��� ��ǥ�� ���� ( Y / X )

    //����ȸ��
    public void CircleRotate()
    {
        float angle = Time.time * 90f;
        float radian = angle * Mathf.Deg2Rad; // ���� �ش簪�� �����ָ� �������� ��ȯ�˴ϴ�.
        
        // var - �ڵ� Ÿ�� �ڿ� ���� Ÿ�Կ� ���� �ڵ����� ����
        var x = Mathf.Cos(radian) * 5.0f; 
        var y = Mathf.Sin(radian) * 5.0f;

        transform.position = new Vector3(x, y, 0);
    }

    //time.time : �������� ������ ���������� �ð�
    //Time.deltatime : �������� �����ϰ� ������ �ð�

    public void Wave()
    {
        var offset = Mathf.Sin(Time.time * 2.0f) * 0.5f;
        transform.position = pos + Vector3.up *offset;
    }

    public void Butterfly()
    {
        float t = Time.time * 2;
        float x = Mathf.Sin(t) * 2;
        float y = Mathf.Sin(t * 2f) * 2 * 2;

        transform.position = new Vector3(x, y, 0);
    }

    Vector3 pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position; // �����Ҷ� ������Ʈ ��ġ ����   
    }

    // Update is called once per frame
    void Update()
    {
        //���콺 ����Ŭ�� �������� CircleRotate ȣ��
        if (Input.GetMouseButton(0))
        {
            CircleRotate();
        }
        if (Input.GetMouseButton(1))
        {
            Wave();
        }
        if (Input.GetMouseButton(2))
        {
            Butterfly();
        }
    }
}
