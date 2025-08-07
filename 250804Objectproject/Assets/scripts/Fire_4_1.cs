using UnityEngine;
using UnityEngine.UIElements.Experimental;

//�� �ڵ�� �Ѿ˿� ���� �߻�(����) ��ɸ� ����մϴ�
public class Fire_4_1 : MonoBehaviour
{
    //�Ѿ� �߻縦 ���� Ǯ
    public BulletPool_4 pool;
    public GameObject effect_prefab; // ����Ʈ ������

    float Delay;

    public float starttime;
    float time;

    //�Ѿ˹߻�����
    public Transform pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = starttime;
        Delay = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKey(KeyCode.Z))
        {
            time += Time.deltaTime;

            if (time > Delay)
            {
                //Instantiate(effect_prefab, transform.position, Quaternion.identity);

                var bullet = pool.GetBullet();
                bullet.transform.position = pos.position;
                bullet.transform.rotation = pos.rotation;

                time = 0;
            }
        }
    }
}
