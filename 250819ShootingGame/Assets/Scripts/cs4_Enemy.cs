using UnityEngine;
//플레이어와 적의 차이
//플레이어 :  컨트롤을 사용자가 진행 합니다
//적 : 멀티게임이 아니라면, 따로 정해진 명령에 따라 자동으로 움직이게 됩니다

public class cs4_Enemy : MonoBehaviour
{
    private EnemyManager pool;//풀
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
        Down, Chase //아래, 플레이어 추적
    }
    public float speed = 5;

    //적에 대한 패턴
    public EnemyType type = EnemyType.Down;

    Vector3 dir;//방향설정

    public GameObject explosionFactory; // 폭발공장


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //함수 분리
        //장점 : 가독성이 높아짐, 재사용성이 높아질수 있음(공격 패턴 리셋, 재생성시의 방향 설정 등)
        PatternSetting();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += dir * speed * Time.deltaTime;
    
    }

    #region 충돌이벤트
    //충돌이벤트 설계
    //오브젝트와 오브젝트간의 물리적인 충돌 발생 시 호출 됩니다

    // ~ Enter : 충돌 후 1번 호출 
    // ~ Stay  : 충돌 유지하는 동안 호출
    // ~ Exit  : 충돌 발생 후 충돌 작업에서 벗어날 경우 1번 호출

    //2D 일 경우 2D를 명시 ex) OnCollisionEnter -> OnCollisionEnter2D

    //둘중 하나라도 Rigidbody(강체)를 가지고 있어야 처리됩니다
    // 일반적인 물리적 충돌 Collision (실제적으로 힘에 의해 물체가 회전하거나 이동됨)
    // Is Trigger 체크가 진행된 오브젝트와의 트리거 충돌 Trigger(충돌 여부만 체크)
    #endregion

    #region rigidbody
    //rigidbody 복습
    // Mass(질량) : 이 값이 클수록 무거워집니다
    // Use Gravity : 체크해제시 중력의 영향을 받지 않습니다.
    // Is Kinematic : 체크시 중력을 포함한 모든 물리적인 힘을 받지 않는 상태로 설정합니다.
    // constraints : 물체에 대한 제약을 걸어줍니다
    //  ㄴ Freeze : 해당 위치에 대한 멈춤
    //              보통 회전 값에 대한 Freeze를 많이 걸어주고 2D일 경우 Z축 Rotation Freeze를 걸어준다
    // Damping : 저항값
    //  ㄴ Linear : 이동 속도에 대한 저항값 값이 높을수록 빠르게 감속하게 됩니다. 설정을 통해 물체의 움직임을 자연스럽게 연출할때 설정합니다
    //  ㄴ Angular : 회전 속도에 대한 설정 값이 높을수록 빠르게 회전을 멈추게 됩니다 (0으로 설정시 무한으로 회전 운동)
    // Interpolate(보간)
    //  ㄴ None : 아래의 기능을 적용합니다
    //  ㄴ Interpolate(보간) : 주어진 범위 내에서 값을 추정
    //      두 물리 업데이트에서의 리지드바디의 위치와 속도를 이용해 현재 프레임에서의 위치를 계산하고 적용하는 방식
    //  ㄴ Extrapolate(외삽) : 주어진 범위를 벗어난 영역에서 값을 추정
    //      이전 물리 업데이트에서의 위치와 속도를 사용하고 다음 값의 위치를 예측해서 현재 프레임 위치를 계산하는 방식
    //      (앞선 움직임, 정확도가 따로 요구되지 않고, 영향을 주는 다른 물리 요소가 없는 일정한 움직임 구현)

    //자주 사용하는 rigidbody 기능
    // AddForce(Vector3 force, ForceMode mode);
    // 오브젝트가 x,y,z축 방향으로 물리적인 힘을 받도록 합니다
    // MovePostion(Vector3 postion);
    // 해당위치로 이동
    // MoveRotation(Quaternion rot)
    // 해당 회전값으로 회전
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        //클래스명.Instance.메소드명()으로 기능만 사용하는 것이 가능해진다.
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
            dir = target.transform.position - transform.position; //타겟 위치 - 본인 위치 = 방향
            dir.Normalize();// 방향의 크기를 1로 설정
        }
        else
        {
            type = EnemyType.Down;
            //아래로 내려가는 기능
            dir = Vector3.down;
        }
    }
}
