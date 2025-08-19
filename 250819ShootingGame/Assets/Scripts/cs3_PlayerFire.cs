using UnityEngine;
using static UnityEditor.PlayerSettings;

public class cs3_PlayerFire : MonoBehaviour
{
    [Header("�߻� ����")]
    [Tooltip("�Ѿ� ���� ����")]
    public GameObject bulletFactory;
    [Tooltip("�ѱ�")]
    public GameObject firePositon;

    public test2_BulletPool pool;//Ǯ

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetKey ~          : Ű�ڵ�
        //GetButton ~       : Axes Ű�� ���� �Է� (input Manager)
        //GetMouseButton ~  : ���콺 Ŭ���� ���� ���� 0, 1, 2

        if (Input.GetButtonDown("Fire1")) //input Manager �� "Fire1" Ű�� �Է��� �������� ��� �߻� ����
        {
            //�Ѿ��� �Ѿ� ���� ���忡�� ����� �Ѿ��� ����
            //�Ѿ� ��ġ�� �ѱ� �������� ����, ���� ȸ���� ����
            //var bullet = Instantiate(bulletFactory, firePositon.transform.position, Quaternion.identity);
            var bullet = pool.GetBullet();
            bullet.transform.position = firePositon.transform.position;
            bullet.transform.rotation = firePositon.transform.rotation;
        }
    }
}
