using UnityEngine;
using UnityEngine.UIElements.Experimental;

//이 코드는 총알에 대한 발사(생성) 기능만 담당합니다
public class Fire_4_1 : MonoBehaviour
{
    //총알 발사를 위한 풀
    public BulletPool_4 pool;

    //총알발사지점
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
