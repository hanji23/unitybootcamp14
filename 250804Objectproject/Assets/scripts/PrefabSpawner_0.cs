using UnityEngine;
// 1. �������� ���� ����Ѵ�.
// 2. ������ �������� ���� ������ ���ο��� ������
// 3. ���� �Ŀ� �ı��� ���� ������ �ð��� ������

// �ش� ��ũ��Ʈ�� ���� ������Ʈ�� ���� �Ǹ� , ������ �����ϰ� ���� �ð� �� �ı��ϵ��� ó���մϴ�

// ���� �������� ����� �Ǿ� ������ �ش� �۾� ����, �ƴ� ��� ��� �޼��� �ȳ�

public class PrefabSpawner_0 : MonoBehaviour
{
    public GameObject prefab;
    private GameObject spawned;
    public float delay = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (prefab != null)
        {
            spawned = Instantiate(prefab);
            //���� �ڵ� Instantiate()
            // 1. Instantiate(prefab);
            // �ش� �������� ������ �°� ��ġ�� ȸ�� �� ���� �����ǰ� �����˴ϴ�.
            // 2. Instantiate(prefab, transform.position, Quaternion.identity);
            // �ش� �������� �����ϰ�, ��ġ�� ȸ�� ���� ������� ������Ʈ�� ��ġ�� ȸ������ �����մϴ�.
            // 3. Instantiate(prefab, parent);
            // ������Ʈ�� �����ϰ� �� ������Ʈ�� ������ ��ġ�� �ڽ����ν� ����մϴ�.
            // 4. Instantiate(prefab, transform.position, Quaternion.identity, parent);

            spawned.name = "������ ������Ʈ"; // ������ ������Ʈ�� �̸��� �����ϴ� �ڵ�

            //spawned.AddComponent<Rigidbody>();
            //���� ������ ������Ʈ�� ������Ʈ�� �߰��մϴ�.

            Debug.Log($"'{spawned.name}' ���� !");
            
            Destroy(spawned, delay); // delay �ð� ���� ������Ʈ �ı�
        }
        else
        {
            Debug.LogWarning("��ϵ� �������� �����ϴ�");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
