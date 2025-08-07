using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class UnitSpawner_3 : MonoBehaviour
{
    public GameObject unitPrefab; //���� ������
    public Transform spawnPoint; // ���� ��ġ
    public float interval = 5f; // ���� ���� ����

    public Text text;

    private BulletPool_4 pool;//Ǯ

    private void Start()
    {
        pool = GameObject.Find("Pool").GetComponent<BulletPool_4>();
        text = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true) 
        {
            if (pool.score >= 100 && interval >= 5)
            {
                interval = 3;
                text.color = Color.blue;
                Debug.Log("�ǹ�!");
            }
                
            if (pool.score >= 300 && interval >= 3)
            {
                interval = 1;
                text.color = Color.red;
                Debug.Log("���� �ǹ�!");
            }
                

            //������ ���� �մϴ�. ���� ��ġ�� spawnpoint�� ���� �޽��ϴ�
            Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);

            Debug.Log($"{spawnPoint.name}���� {unitPrefab.name} ����!");

            //GameObject unit = Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);

            //Debug.Log($"{gameObject.name}���� {unit.name} ����!");

            //���� ���ݸ�ŭ ����մϴ�
            yield return new WaitForSeconds(interval);
        }
    }
}
