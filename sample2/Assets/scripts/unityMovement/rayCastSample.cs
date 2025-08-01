using UnityEngine;
//RayCast : ������ġ���� Ư�� �������� ������ �i���� �ε����� ������Ʈ�� �ִ����� �Ǵ��մϴ�.
//1)Ư�� ������Ʈ�� �浹�������� �����ϴ� �۾�����
//2)Ư�� ������Ʈ�� ���� �浹������ Ȯ���ϴ� �뵵

public class rayCastSample : MonoBehaviour
{
    RaycastHit hit; // �浹������ ����
    int ignorlayer;
    int layerMask;

    //ref -> ������ ���� ����, ������ �޼ҵ� �ȿ��� ���� �ɼ� ������ �˸��� �뵵
    //out -> ������ ���� ����, ���� ���� ���� ������ ���� �ʱ�ȭ�� ���� �� �ʿ䰡 ����
    //Physics.RayCast(Vector3 origin, Vector3 direction, out RayCastHit hitInfo, float maxDiswtance, int LayerMask);
    //origin ���⿡�� direction �������� maxDiswtance ������ ������ �߻��մϴ�
    //hitInfo�� �浹ü�� ���� ������ �ǹ�, �浹ü ������ �ʿ� ������ ���� ����(�����ε�)

    const float lenghth = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //���̾� ����ũ ����
        //1. �浹 ��Ű�� �������� ���̾ ���� ���� ����
        ignorlayer = LayerMask.NameToLayer("red");// �浹 ��Ű�� ���� ���� ���̾�
        //2. ~(1 << LayerMask.NameToLayer("red")) �ش� ���̾� �̿��� ��
        layerMask = ~(1 << ignorlayer);

        //ex) ���� red���̾�� blue ���̾ �Ѵ� �����ϰ� ���� ���
        //int ignorlayers = (1 << LayerMask.NameToLayer("red")) | (1 << LayerMask.NameToLayer("blue"));
        //int layerMasks = ~ignorlayer;

        //�ѹ��� �������� ����ĳ��Ʈ �浹 ó��
        //�浹ü ����(����)
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, lenghth, layerMask);
        //RaycastAll : �ѹ������� �� ���̰� �浹�� �浹ü�� �迭�� return

        //�ݺ������� �ݶ��̴� üũ
        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log("������ �߻�! �浹 ��ü : " + hits[i].collider.name);
            //hits�迭�� i��° ���� �浹ü�� ���� ���� ������Ʈ�� ��Ȱ��ȭ �մϴ�.
            hits[i].collider.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //���콺 ���� ��ư Ŭ���� ���� �߻�
        //if (Input.GetMouseButtonDown(0))
        //{
        //if (Physics.Raycast(transform.position, transform.forward, out hit, lenghth, layerMask))
        //{
        //    Debug.Log("������ �߻�! �浹 ��ü : " + hit.collider.name);
        //    hit.collider.gameObject.SetActive(false);
        //}

        //���̾��ũ�� ��Ʈ ����ũ�̸�, �� ��Ʈ�� �ϳ��� ���̾ �ǹ��մϴ�. ~�� ���� �ۼ��� ~(1<<n)�� �ش� ���̾ ������ ��� ���̾ �ǹ��մϴ�

        //������Ʈ�� ��ġ���� �������� length��ŭ�� ���̿� �ش��ϴ� ����� ������ ��� �ڵ�
        //�ַ� ����ĳ��Ʈ �۾����� ���̰� �Ⱥ��̱� ������ �����ִ� �뵵�� ����մϴ�.
        Debug.DrawRay(transform.position, transform.forward * lenghth, Color.red);
        //}
    }
}
