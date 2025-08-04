using System.Collections;
using UnityEngine;

public class UnitSpawner_3 : MonoBehaviour
{
    public GameObject unitPrefab; //���� ������
    public Transform spawnPoint; // ���� ��ġ
    public float interval = 5f; // ���� ���� ����

    private void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true) 
        {
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
