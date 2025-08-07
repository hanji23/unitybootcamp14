using UnityEngine;
using UnityEngine.UIElements.Experimental;

//이 코드는 총알에 대한 발사(생성) 기능만 담당합니다
public class Fire_4_1 : MonoBehaviour
{
    //총알 발사를 위한 풀
    public BulletPool_4 pool;
    public GameObject effect_prefab; // 이펙트 프리펩

    float Delay;

    public float starttime;
    float time;

    //총알발사지점
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
