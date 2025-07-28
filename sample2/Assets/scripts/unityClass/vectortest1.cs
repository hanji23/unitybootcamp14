using UnityEngine;

public class vectortest1 : MonoBehaviour
{
    // ���ӿ�����Ʈ�� transform�� ���� vector �� ���ϱ�
    public Transform A_cube;
    public Transform B_cube;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //���� ť���� ��ġ�� ���ͷ� ����
        Vector3 posA = A_cube.position;
        Vector3 posB = B_cube.position;

        //�� ������ �� -> ���� ����
        Vector3 BtoA = posB - posA;
        Vector3 AtoB = posA - posB;

        //�Ÿ� ����
        //Distance�� ������ ����
        // a = (ax, ay, az), b = (bx, by, bz) ��� �Ҷ�
        // �� ���� ������ �Ÿ��� �� �࿡ ���� ���� ������ �տ� ���� ��Ʈ ��
        // -> ��{(bx - ax)^2 + (by - ay)^2 + (bz - az)^2}

        // ����Ƽ�� Mathf Ŭ������ ������� �ٲٸ�?
        Vector3 dif = posB - posA;
        float distance = Mathf.Sqrt(dif.x * dif.x + dif.y * dif.y + dif.z * dif.z);
        Debug.Log("Mathf : " + distance);

        // ���� Distance �̿�
        distance = Vector3.Distance(posA, posB);
        Debug.Log("Distance" + distance);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
