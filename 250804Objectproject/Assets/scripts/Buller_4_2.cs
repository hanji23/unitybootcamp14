using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//총알에 대한 정보, 총알 반납, 총알 이동
public class Buller_4_2 : MonoBehaviour
{
    public float speed = 2.0f; // 총알 이동 속도
    float speeduptime = 2;
    public float life_time = 5.0f; //총알 반납시간
    public GameObject effect_prefab; // 이펙트 프리펩
    public GameObject effect_prefab2; // 이펙트 프리펩
    public GameObject effect_prefab3; // 이펙트 프리펩

    public Text text;

    private BulletPool_4 pool;//풀
    private Coroutine life_coroutine;

    //풀설정(풀에서 해당 값 호출)
    public void SetPool(BulletPool_4 pool)
    {
        this.pool = pool;
        text = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        Instantiate(effect_prefab3, transform.position, Quaternion.LookRotation(new Vector3(0,-1,0)), gameObject.transform);
    }

    //활성화 단계
    private void OnEnable()
    {
        speeduptime = 1;
        life_coroutine = StartCoroutine(BulletReturn());
    }

    //비활성화 단계
    private void OnDisenable()
    {
        if (life_coroutine != null)
        {
            StopCoroutine(BulletReturn());
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        speeduptime += (Time.deltaTime * 20);
        transform.position += transform.up * speeduptime * Time.deltaTime;
    }

    IEnumerator BulletReturn()
    {
        yield return new WaitForSeconds(life_time);
        ReturnPool();
    }

    private void OnTriggerEnter(Collider other)
    {
        //부딪힌 대상이 Enemy 태그를 가지고 있는 오브젝트일 경우
        if (other.tag == "Enemy")
        {
            other.transform.GetComponent<unitMoveAI_3_1>().hp -= 1;

            if (other.transform.GetComponent<unitMoveAI_3_1>().hp <= 0)
            {
                text.text = $"score : {pool.score += 10}";
                Destroy(other.gameObject);
            }
                
            if (effect_prefab != null)
            {
                Instantiate(effect_prefab, transform.position, Quaternion.identity);
                Instantiate(effect_prefab2, transform.position, Quaternion.identity);
            }
        }

        //이펙트 연출 (파티클)
        
        ReturnPool();
    }

    //메소드의 명령이 한줄일 경우 =>로 사용할 수 있습니다
    void ReturnPool() => pool.Return(gameObject);
}
