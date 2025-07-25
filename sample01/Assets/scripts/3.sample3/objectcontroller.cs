using UnityEngine;

public class objectcontroller : MonoBehaviour
{
    public GameObject player, score;
    float speed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("mini simple skeleton demo");
        score = GameObject.Find("score");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);

        if (transform.position.y < -2)
        {
            score.GetComponent<scoresc>().timeint += 1;
            Destroy(gameObject);
        }

        if (score.GetComponent<scoresc>().timeint > 20 && speed == 0.5f)
        {
            speed += 0.5f;
        }

        //�浹����ó��
        //���� ���� �浹 ���� ���� ���
        Vector3 v1 = transform.position;
        Vector3 v2 = player.transform.position;

        Vector3 dir = v1 - v2;
        float d = dir.magnitude;//������ ũ�� �Ǵ� ���̸� �ǹ� (���� ������ �Ÿ��� ����Ҷ� ���)

        float obj_r1 = 0.5f;
        float obj_r2 = 1;

        //�ΰ� ������ �Ÿ��� d�� ���� ������ �������� �� ���� ũ�ٸ� �浹���� ���� ��Ȳ
        if (d < obj_r1 + obj_r2)
        {
            Destroy (gameObject);
        }
    }
}
