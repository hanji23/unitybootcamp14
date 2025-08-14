using UnityEngine;
using UnityEngine.UI;

public class cs4_InterPlayer : MonoBehaviour
{
    //�ν����� ������ ���� ����(���� ������ ���� ����),
    //�ܺο��� ���� �Ұ�(�Ժη� ������ ����� �뵵)
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
            Debug.LogError("���� ����� �������� �ʾҽ��ϴ�!");
            b1.gameObject.SetActive(false); 
        }

        strategy2 = attackObject2 as IAttackStrategy;

        if (strategy2 == null)
        {
            Debug.LogError("���� ����� �������� �ʾҽ��ϴ�!");
            b2.gameObject.SetActive(false);
        }

        strategy3 = attackObject3 as IAttackStrategy;

        if (strategy3 == null)
        {
            Debug.LogError("���� ����� �������� �ʾҽ��ϴ�!");
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
        // �� Value�� ���� null ����� ���� ����
    }

}
