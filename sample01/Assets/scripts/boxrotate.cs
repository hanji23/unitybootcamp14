using UnityEngine;

public class boxrotate : MonoBehaviour
{
    public Vector3 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(pos * Time.deltaTime);
        //Time.deltaTime�� ���� �����Ӻ��� ���� �����ӱ��� �ɸ� �ð�
        //update������ ���������� Ȱ��

        //transform.Rotate(pos);
        //�ش� ��ǥ��ŭ ���� ������Ʈ�� ȸ��
    }
}
