using System.Collections.Generic;
using UnityEngine;

public class test2_BulletPool : MonoBehaviour
{
    public int size = 100;
    public GameObject bullet_prefab;

    private List<GameObject> pool;

    //������ƮǮ ����Ƽ�� ������Ʈ �ı� �۾��� ���� �߻��ҽ� ���ɿ� ������ ������ �ֱ⶧���� ������Ʈ ������ ������Ʈ�� ���� �ı��ɰ� ���� �� 
    //������Ʈ�� �ı��ϴ� ��� �ش� ������Ʈ�� ��Ȱ��ȭ�ϰ� �ٽ� ��Ȱ��ȭ�� ������Ʈ�� �ٽ� Ȱ��ȭ�� ��Ȱ���ϴ� ����� ����� �����ϰ� �̸� ������ƮǮ�̶� �Ѵ�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            var bullet = Instantiate(bullet_prefab);
            bullet.transform.parent = transform; //������ �Ѿ��� ������ ��ũ��Ʈ�� ���� ������Ʈ�� �ڽ����� �����˴ϴ�.

            bullet.SetActive(false); // ������ �Ѿ� ��Ȱ��ȭ

            bullet.GetComponent<cs2_Bullet>().SetPool(this);

            pool.Add(bullet); // ����Ʈ��.Add(��); ����Ʈ�� �ش� ���� �߰��ϴ� ����
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetBullet()
    {
        //��Ȱ��ȭ �Ǿ��ִ� �Ѿ��� ã�Ƽ� Ȱ��ȭ
        foreach (var bullet in pool)
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
        new_bullet.GetComponent<cs2_Bullet>().SetPool(this);
        pool.Add(new_bullet);
        return new_bullet;
    }

    public void Return(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
