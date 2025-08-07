using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//�Ѿ˿� ���� ����, �Ѿ� �ݳ�, �Ѿ� �̵�
public class Buller_4_2 : MonoBehaviour
{
    public float speed = 2.0f; // �Ѿ� �̵� �ӵ�
    float speeduptime = 2;
    public float life_time = 5.0f; //�Ѿ� �ݳ��ð�
    public GameObject effect_prefab; // ����Ʈ ������
    public GameObject effect_prefab2; // ����Ʈ ������
    public GameObject effect_prefab3; // ����Ʈ ������

    public Text text;

    private BulletPool_4 pool;//Ǯ
    private Coroutine life_coroutine;

    //Ǯ����(Ǯ���� �ش� �� ȣ��)
    public void SetPool(BulletPool_4 pool)
    {
        this.pool = pool;
        text = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        Instantiate(effect_prefab3, transform.position, Quaternion.LookRotation(new Vector3(0,-1,0)), gameObject.transform);
    }

    //Ȱ��ȭ �ܰ�
    private void OnEnable()
    {
        speeduptime = 1;
        life_coroutine = StartCoroutine(BulletReturn());
    }

    //��Ȱ��ȭ �ܰ�
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
        //�ε��� ����� Enemy �±׸� ������ �ִ� ������Ʈ�� ���
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

        //����Ʈ ���� (��ƼŬ)
        
        ReturnPool();
    }

    //�޼ҵ��� ����� ������ ��� =>�� ����� �� �ֽ��ϴ�
    void ReturnPool() => pool.Return(gameObject);
}
