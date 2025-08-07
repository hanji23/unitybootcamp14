using System.Collections.Generic;//�÷��� ���(���� �Է���)
using UnityEngine;
//������Ʈ Ǯ��(Object pooling)
//���� �����ǰ� �Ҹ�Ǵ� ������Ʈ�� �̸� ������ �����صΰ� �ʿ��Ҷ� Ȱ��ȭ�ϰ� ������������� ��Ȱ��ȭ�ϴ½����� ������ �����ϴ� ����� ���� ����

//������
//ź��, ����Ʈ, ������ �ؽ�Ʈ, ���� ó�� ���� �����ǰ� ������� ������ �Ź� new, destroy�� ���� ���� ������ �߻��ϸ� GC�� ���� ȣ���ϰԵǰ� �̴� 
//���� ���Ϸ� �̾��� ���ֱ⿡ ���� ����� �������� ����մϴ�.

//����) �߻� �Ѿ� �� 30�� / ������ ���� 20���� �̸� �ѹ��� �� ����  ���� �Ⱦ��� ���� ��Ȱ��ȭ 

public class BulletPool_4 : MonoBehaviour
{
    public int score = 0;
    public GameObject bullet_prefab;
    public int size = 100;

    //Ǯ�� ���� ���Ǵ� �ڷᱸ��
    // 1. ����Ʈ(List) : �����͸� ���������� �����ϰ� �߰� ������ �����ӱ� ������ ȿ����
    // 2. ť(Queue) : �����Ͱ� ���� ������� �����Ͱ� ���������� ������ �ڷᱸ��

    private List<GameObject> pool; // using System.Collections.Generic; <- �Է��ؾ���

    private void Start()
    {
        //�Ѿ� ����
        pool = new List<GameObject>();

        for(int i = 0; i < size; i++)
        {
            var bullet = Instantiate(bullet_prefab);
            bullet.transform.parent = transform; //������ �Ѿ��� ������ ��ũ��Ʈ�� ���� ������Ʈ�� �ڽ����� �����˴ϴ�.

            bullet.SetActive(false); // ������ �Ѿ� ��Ȱ��ȭ

            bullet.GetComponent<Buller_4_2>().SetPool(this);

            pool.Add(bullet); // ����Ʈ��.Add(��); ����Ʈ�� �ش� ���� �߰��ϴ� ����
        }
    }

    public GameObject GetBullet()
    {
        //��Ȱ��ȭ �Ǿ��ִ� �Ѿ��� ã�Ƽ� Ȱ��ȭ
        foreach(var bullet in pool)
        {
            //����â���� Ȱ��ȭ�� �ȵǾ��ִٸ� (����ϰ� ���� �ʴ´ٸ�)
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        //�Ѿ��� ������ ��쿡�� ���Ӱ� ���� ����Ʈ�� ����մϴ�
        var new_bullet = Instantiate(bullet_prefab);
        new_bullet.transform.parent = transform;
        new_bullet.GetComponent<Buller_4_2>().SetPool(this);
        pool.Add(new_bullet);
        return new_bullet;
    }

    public void Return(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
