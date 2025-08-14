using UnityEngine;
using UnityEngine.UI;

public class cs4_InterPlayer : MonoBehaviour
{
    //인스펙터 내에서 접근 가능(내부 데이터 연결 목적),
    //외부에서 접근 불가(함부로 값쓰지 말라는 용도)
    [SerializeField]
    private ScriptableObject attackObject, attackObject2, attackObject3;

    private IAttackStrategy strategy, strategy2, strategy3;

    public Button b1, b2, b3;

    private int attacknum = 0;

    private void Awake()
    {

        strategy = attackObject as IAttackStrategy;

        if (strategy == null)
        {
            Debug.LogError("공격 기능이 구현되지 않았습니다!");
            b1.gameObject.SetActive(false); 
        }

        strategy2 = attackObject2 as IAttackStrategy;

        if (strategy2 == null)
        {
            Debug.LogError("공격 기능이 구현되지 않았습니다!");
            b2.gameObject.SetActive(false);
        }

        strategy3 = attackObject3 as IAttackStrategy;

        if (strategy3 == null)
        {
            Debug.LogError("공격 기능이 구현되지 않았습니다!");
            b3.gameObject.SetActive(false);
        }
    }

    public void ActionCheck(int i)
    {
        attacknum = i;
    }
    public void ActionPerformed(GameObject target)
    {
        switch (attacknum)
        {
            case 1:
                strategy?.Attack(target);
                break;
            case 2:
                strategy2?.Attack(target);
                break;
            case 3:
                strategy3?.Attack(target);
                break;
                //case 1:
                //    strategy?.Attack(/*target*/);
                //    break;
                //case 2:
                //    strategy2?.Attack(/*target*/);
                //    break;
                //case 3:
                //    strategy3?.Attack(/*target*/);
                //    break;
        }
        
        //Nullable<T> or T?
        // ㄴ Value에 대한 null 허용을 위한 도구
    }

}
