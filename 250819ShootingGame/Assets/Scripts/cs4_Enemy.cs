using UnityEngine;
//�÷��̾�� ���� ����
//�÷��̾� :  ��Ʈ���� ����ڰ� ���� �մϴ�
//�� : ��Ƽ������ �ƴ϶��, ���� ������ ��ɿ� ���� �ڵ����� �����̰� �˴ϴ�

public class cs4_Enemy : MonoBehaviour
{
    private EnemyManager pool;//Ǯ
    public void SetPool(EnemyManager pool)
    {
        this.pool = pool;
    }
    private void OnDisenable()
    {
        pool.Return(gameObject);
    }

    public enum EnemyType
    {
        Down, Chase //�Ʒ�, �÷��̾� ����
    }
    public float speed = 5;

    //���� ���� ����
    public EnemyType type = EnemyType.Down;

    Vector3 dir;//���⼳��

    public GameObject explosionFactory; // ���߰���


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�Լ� �и�
        //���� : �������� ������, ���뼺�� �������� ����(���� ���� ����, ��������� ���� ���� ��)
        PatternSetting();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += dir * speed * Time.deltaTime;
    
    }

    #region �浹�̺�Ʈ
    //�浹�̺�Ʈ ����
    //������Ʈ�� ������Ʈ���� �������� �浹 �߻� �� ȣ�� �˴ϴ�

    // ~ Enter : �浹 �� 1�� ȣ�� 
    // ~ Stay  : �浹 �����ϴ� ���� ȣ��
    // ~ Exit  : �浹 �߻� �� �浹 �۾����� ��� ��� 1�� ȣ��

    //2D �� ��� 2D�� ��� ex) OnCollisionEnter -> OnCollisionEnter2D

    //���� �ϳ��� Rigidbody(��ü)�� ������ �־�� ó���˴ϴ�
    // �Ϲ����� ������ �浹 Collision (���������� ���� ���� ��ü�� ȸ���ϰų� �̵���)
    // Is Trigger üũ�� ����� ������Ʈ���� Ʈ���� �浹 Trigger(�浹 ���θ� üũ)
    #endregion

    #region rigidbody
    //rigidbody ����
    // Mass(����) : �� ���� Ŭ���� ���ſ����ϴ�
    // Use Gravity : üũ������ �߷��� ������ ���� �ʽ��ϴ�.
    // Is Kinematic : üũ�� �߷��� ������ ��� �������� ���� ���� �ʴ� ���·� �����մϴ�.
    // constraints : ��ü�� ���� ������ �ɾ��ݴϴ�
    //  �� Freeze : �ش� ��ġ�� ���� ����
    //              ���� ȸ�� ���� ���� Freeze�� ���� �ɾ��ְ� 2D�� ��� Z�� Rotation Freeze�� �ɾ��ش�
    // Damping : ���װ�
    //  �� Linear : �̵� �ӵ��� ���� ���װ� ���� �������� ������ �����ϰ� �˴ϴ�. ������ ���� ��ü�� �������� �ڿ������� �����Ҷ� �����մϴ�
    //  �� Angular : ȸ�� �ӵ��� ���� ���� ���� �������� ������ ȸ���� ���߰� �˴ϴ� (0���� ������ �������� ȸ�� �)
    // Interpolate(����)
    //  �� None : �Ʒ��� ����� �����մϴ�
    //  �� Interpolate(����) : �־��� ���� ������ ���� ����
    //      �� ���� ������Ʈ������ ������ٵ��� ��ġ�� �ӵ��� �̿��� ���� �����ӿ����� ��ġ�� ����ϰ� �����ϴ� ���
    //  �� Extrapolate(�ܻ�) : �־��� ������ ��� �������� ���� ����
    //      ���� ���� ������Ʈ������ ��ġ�� �ӵ��� ����ϰ� ���� ���� ��ġ�� �����ؼ� ���� ������ ��ġ�� ����ϴ� ���
    //      (�ռ� ������, ��Ȯ���� ���� �䱸���� �ʰ�, ������ �ִ� �ٸ� ���� ��Ұ� ���� ������ ������ ����)

    //���� ����ϴ� rigidbody ���
    // AddForce(Vector3 force, ForceMode mode);
    // ������Ʈ�� x,y,z�� �������� �������� ���� �޵��� �մϴ�
    // MovePostion(Vector3 postion);
    // �ش���ġ�� �̵�
    // MoveRotation(Quaternion rot)
    // �ش� ȸ�������� ȸ��
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        //Ŭ������.Instance.�޼ҵ��()���� ��ɸ� ����ϴ� ���� ����������.
        if (collision.collider.CompareTag("Bullet"))
            ScoreManager.Instance.SetScore(5);

        GameObject explosion = Instantiate(explosionFactory, transform.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        //Destroy(collision.gameObject);
        //Destroy(gameObject);

        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    void PatternSetting()
    {
        int rand = Random.Range(0, 10);
        if (rand < 3)
        {
            type = EnemyType.Chase;
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            dir = target.transform.position - transform.position; //Ÿ�� ��ġ - ���� ��ġ = ����
            dir.Normalize();// ������ ũ�⸦ 1�� ����
        }
        else
        {
            type = EnemyType.Down;
            //�Ʒ��� �������� ���
            dir = Vector3.down;
        }
    }
}
