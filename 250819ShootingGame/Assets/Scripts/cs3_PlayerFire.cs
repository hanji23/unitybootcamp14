using UnityEngine;
using static UnityEditor.PlayerSettings;

public class cs3_PlayerFire : MonoBehaviour
{
    [Header("발사 설정")]
    [Tooltip("총알 생산 공장")]
    public GameObject bulletFactory;
    [Tooltip("총구")]
    public GameObject firePositon;

    public test2_BulletPool pool;//풀

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetKey ~          : 키코드
        //GetButton ~       : Axes 키에 대한 입력 (input Manager)
        //GetMouseButton ~  : 마우스 클릭에 대한 설정 0, 1, 2

        if (Input.GetButtonDown("Fire1")) //input Manager 의 "Fire1" 키에 입력이 진행됬을 경우 발사 진행
        {
            //총알은 총알 생성 공장에서 등록한 총알을 생성
            //총알 위치는 총구 지점으로 설정, 별도 회전은 없음
            //var bullet = Instantiate(bulletFactory, firePositon.transform.position, Quaternion.identity);
            var bullet = pool.GetBullet();
            bullet.transform.position = firePositon.transform.position;
            bullet.transform.rotation = firePositon.transform.rotation;
        }
    }
}
