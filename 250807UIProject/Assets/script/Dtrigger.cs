using System.Collections.Generic;
using UnityEngine;

//오브젝트에 연결해 Inspector에서 대사를 등록하는 기능
public class Dtrigger : MonoBehaviour
{
    public List<Dialog> scripts;

    public void OnDTriggerEnter()
    {
        if (scripts != null && scripts.Count > 0)
        {
            DialogManager.Instance.StartLine(scripts);
            //클래스명.Instance.메소드명()과 같이 클래스의 값을 바로 사용할 수 있습니다
            //따로 값을 GetCompnonent나 public등으로 등록해서 사용할 필요가 없어 편합니다
        }
    }
}
