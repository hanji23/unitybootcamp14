using UnityEngine;

public class objectspawner : MonoBehaviour
{
    public GameObject objectprefab;

    float spawntime = 3f;// �� �ð��� ������ ����
    float time = 2.5f;
    // �ð��� ���� ����ؼ� , ������ �����ϰ� �׺����� ���� Ÿ�Ӻ��� Ŀ���� ������Ʈ ����, ������ 0���� �ʱ�ȭ

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
