using System.Collections.Generic;
using UnityEngine;

//���� �ð�����  ���� ������ �� ��ġ�� ���� ��

public class EnemyManager : MonoBehaviour
{
    float min = 1, max = 5;//��ȯ�ð� ����(�ּ� , �ִ�) ���� �ֱ� ����

    float currentTime; 
    public float createTime;
    public GameObject enemyFactory;
    public GameObject spawnArea;//��������

    public int size = 15;
    private List<GameObject> pool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        createTime = Random.Range(min, max);

        pool = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            var enemy = Instantiate(enemyFactory);
            enemy.transform.parent = transform; //������ �Ѿ��� ������ ��ũ��Ʈ�� ���� ������Ʈ�� �ڽ����� �����˴ϴ�.

            enemy.SetActive(false); // ������ �Ѿ� ��Ȱ��ȭ

            enemy.GetComponent<cs4_Enemy>().SetPool(this);

            pool.Add(enemy); // ����Ʈ��.Add(��); ����Ʈ�� �ش� ���� �߰��ϴ� ����
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.Instance.destroy < 20)
        {
            currentTime += Time.deltaTime;

            if (currentTime > createTime)
            {
                currentTime = 0;
                //var enemy = Instantiate(enemyFactory, spawnArea.transform.position, Quaternion.identity);
                var enemy = GetEnemy();
                enemy.transform.position = transform.position;
                createTime = Random.Range(min, max);
            }
        }
    }

    public GameObject GetEnemy()
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
        var new_enemy = Instantiate(enemyFactory);
        new_enemy.transform.parent = transform;
        new_enemy.GetComponent<cs4_Enemy>().SetPool(this);
        pool.Add(new_enemy);
        return new_enemy;
    }

    public void Return(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}
