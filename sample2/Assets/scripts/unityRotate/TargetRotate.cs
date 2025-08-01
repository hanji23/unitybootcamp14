using UnityEngine;

//��ǥ �������� ȸ�� ��Ű�� �ڵ�
public class TargetRotate : MonoBehaviour
{
    public Transform target;

    public float speed = 90f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Quaternion.LookRotation(Vector3 forward); Ư�� ������ �ٶ󺸴� ȸ���� ���
        var targetRotation = Quaternion.LookRotation(target.position - transform.position);

        //Quaternion.RotateTowards(��ġ, Ÿ�� ��ġ, �ӵ�);
        //������ ȸ������ Ÿ���� ȸ������ ���� �ӵ� �ε巴�� ȸ���� �����ϴ� �Լ�
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed);
    }
}
