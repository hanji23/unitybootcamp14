using UnityEngine;

public class SphericaInter : MonoBehaviour
{
    //Leap �� Glerp�� ���Ǵ� ���
    //1. �ܼ��� ��ġ �̵� -> Leap
    //2. ȸ�� �� ���� ��ȯ -> Sleap (Vector3.Sleap, Quaternion.Slerp)
    //3. �ڿ������� ī�޶��� ������ -> Sleap

    //��� 
    //Leap : �����̵�
    //ü�� ������ ���� �����ϰ� ��ȭ�ϴ� ���
    //Sleap : ȸ���̳� ������ ������ �ʿ��� ���
    //3D ȸ��(���ʹϾ�) / ���� ���� � ��� Ȯ�� / ���� ȸ���� �ε巴�� ��� ������ �ٶ���� �� ���

    public Transform target;
    public float speed = 1.0f;

    private Vector3 start_position;
    private float t = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (t < 1.0f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Slerp(start_position, target.position, t);
        }
    }
}