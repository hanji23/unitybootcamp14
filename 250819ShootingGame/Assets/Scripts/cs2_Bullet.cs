using System.Collections;
using UnityEngine;

public class cs2_Bullet : MonoBehaviour
{
    public float speed = 5;

    private test2_BulletPool pool;//풀

    public void SetPool(test2_BulletPool pool)
    {
        this.pool = pool;
    }

    private void OnDisable()
    {
        
    }
    //비활성화 단계
    private void OnDisenable()
    {
        pool.Return(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.up;

        transform.position += dir * speed * Time.deltaTime;
    }
}
