using UnityEngine;
using UnityEngine.UIElements.Experimental;

//�� �ڵ�� �Ѿ˿� ���� �߻�(����) ��ɸ� ����մϴ�
public class Fire_4_1 : MonoBehaviour
{
    //�Ѿ� �߻縦 ���� Ǯ
    public BulletPool_4 pool;

    //�Ѿ˹߻�����
    public Transform pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var bullet = pool.GetBullet();
            bullet.transform.position = pos.position;
            bullet.transform.rotation = pos.rotation;
        }
    }
}
