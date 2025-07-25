using UnityEngine;

public class objectspawner : MonoBehaviour
{
    public GameObject objectprefab;

    float spawntime = 3f;// 이 시간이 지나면 생성
    float time = 2.5f;
    // 시간을 따로 계산해서 , 변수로 저장하고 그변수가 스폰 타임보다 커지면 오브젝트 생성, 변수를 0으로 초기화

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > spawntime)
        {
            GameObject go = Instantiate(objectprefab);
            go.transform.position = new Vector3(Random.Range(-5,6), transform.position.y, 0);

            time = 0f;
        }
    }
}
