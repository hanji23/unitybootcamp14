using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class UnitSpawner_3 : MonoBehaviour
{
    public GameObject unitPrefab; //유닛 프리펩
    public Transform spawnPoint; // 생성 위치
    public float interval = 5f; // 유닛 생성 간격

    public Text text;

    private BulletPool_4 pool;//풀

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
                Debug.Log("피버!");
            }
                
            if (pool.score >= 300 && interval >= 3)
            {
                interval = 1;
                text.color = Color.red;
                Debug.Log("슈퍼 피버!");
            }
                

            //유닛을 생성 합니다. 생성 위치는 spawnpoint로 부터 받습니다
            Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);

            Debug.Log($"{spawnPoint.name}에서 {unitPrefab.name} 생성!");

            //GameObject unit = Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);

            //Debug.Log($"{gameObject.name}에서 {unit.name} 생성!");

            //생성 간격만큼 대기합니다
            yield return new WaitForSeconds(interval);
        }
    }
}
