using System.Collections.Generic;
using UnityEngine;

public class test2_BulletPool : MonoBehaviour
{
    public int size = 100;
    public GameObject bullet_prefab;

    private List<GameObject> pool;

    //오브젝트풀 유니티는 오브젝트 파괴 작업이 많이 발생할시 성능에 않좋은 영향을 주기때문에 프로젝트 내에서 오브젝트가 많이 파괴될것 같을 때 
    //오브젝트를 파괴하는 대신 해당 오브젝트를 비활성화하고 다시 비활성화한 오브젝트를 다시 활성화해 재활용하는 방식을 사용을 권장하고 이를 오브젝트풀이라 한다

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            var bullet = Instantiate(bullet_prefab);
            bullet.transform.parent = transform; //생성된 총알은 현재의 스크립트를 가진 오브젝트의 자식으로 관리됩니다.

            bullet.SetActive(false); // 생성한 총알 비활성화

            bullet.GetComponent<cs2_Bullet>().SetPool(this);

            pool.Add(bullet); // 리스트명.Add(값); 리스트에 해당 값을 추가하는 문법
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetBullet()
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
