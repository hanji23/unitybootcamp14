using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class unitMoveAI_3_1 : MonoBehaviour
{
    public int hp = 5; // ü��
    public float speed = 1f; // �̵��ӵ�
    public float detection = 5.0f; // �˻�����

    private Transform player_position; //�÷��̾� ��ġ

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_position = GameObject.FindGameObjectWithTag("Player")?.transform;
        //(? ������ ��� : ��ü�� null�� �� �߻��� ���� ����)
        //��ó�� �ۼ��� �ϸ� �ش簪�� NullableŸ������ �����մϴ�

        if (player_position != null)
        {
            StartCoroutine(Move());
        }
        else
        {
            Debug.LogWarning("�÷��̾ ã�� �� �����ϴ�");
        }
    }

    private void Update()
    {
        var targetRotation = Quaternion.LookRotation(player_position.position - transform.position);

        //Quaternion.RotateTowards(��ġ, Ÿ�� ��ġ, �ӵ�);
        //������ ȸ������ Ÿ���� ȸ������ ���� �ӵ� �ε巴�� ȸ���� �����ϴ� �Լ�
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 90);
    }


    IEnumerator Move()
    {
        while (player_position != null)
        {
            float distance = Vector3.Distance(transform.position, player_position.position);

            //�÷��̾ ������ �Ÿ� ���� �ִٸ�?
            if (distance <= detection)
            {
                Vector3 dir = (player_position.position - transform.position).normalized;

                transform.position = Vector3.MoveTowards(transform.position, player_position.position, speed * Time.deltaTime);
            }
            else
            {
                //�Ÿ� ���� ���� ��
            }
            yield return null;
        }
    }

    
}
