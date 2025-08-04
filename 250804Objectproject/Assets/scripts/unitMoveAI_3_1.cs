using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class unitMoveAI_3_1 : MonoBehaviour
{
    public int hp = 5; // 체력
    public float speed = 1f; // 이동속도
    public float detection = 5.0f; // 검색범위

    private Transform player_position; //플레이어 위치

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_position = GameObject.FindGameObjectWithTag("Player")?.transform;
        //(? 연산자 사용 : 객체가 null일 때 발생할 오류 방지)
        //위처럼 작성을 하면 해당값을 Nullable타입으로 변경합니다

        if (player_position != null)
        {
            StartCoroutine(Move());
        }
        else
        {
            Debug.LogWarning("플레이어를 찾을 수 없습니다");
        }
    }

    private void Update()
    {
        var targetRotation = Quaternion.LookRotation(player_position.position - transform.position);

        //Quaternion.RotateTowards(위치, 타겟 위치, 속도);
        //현재의 회전에서 타겟의 회전으로 일정 속도 부드럽게 회전을 진행하는 함수
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 90);
    }


    IEnumerator Move()
    {
        while (player_position != null)
        {
            float distance = Vector3.Distance(transform.position, player_position.position);

            //플레이어가 지정된 거리 내에 있다면?
            if (distance <= detection)
            {
                Vector3 dir = (player_position.position - transform.position).normalized;

                transform.position = Vector3.MoveTowards(transform.position, player_position.position, speed * Time.deltaTime);
            }
            else
            {
                //거리 내에 없을 때
            }
            yield return null;
        }
    }

    
}
