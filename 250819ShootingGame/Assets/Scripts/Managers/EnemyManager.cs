using System.Collections.Generic;
using UnityEngine;

//일정 시간마다  적을 생성해 내 위치에 놓을 것

public class EnemyManager : MonoBehaviour
{
    float min = 1, max = 5;//소환시간 간격(최소 , 최대) 생성 주기 조작

    float currentTime; 
    public float createTime;
    public GameObject enemyFactory;
    public GameObject spawnArea;//생성지역

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
            enemy.transform.parent = transform; //생성된 총알은 현재의 스크립트를 가진 오브젝트의 자식으로 관리됩니다.

            enemy.SetActive(false); // 생성한 총알 비활성화

            enemy.GetComponent<cs4_Enemy>().SetPool(this);

            pool.Add(enemy); // 리스트명.Add(값); 리스트에 해당 값을 추가하는 문법
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
        //비활성화 되어있는 총알을 찾아서 활성화
        foreach (var bullet in pool)
        {
            //계층창에서 활성화가 안되어있다면 (사용하고 있지 않는다면)
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        //총알이 부족한 경우에는 새롭게 만들어서 리스트에 등록합니다
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
