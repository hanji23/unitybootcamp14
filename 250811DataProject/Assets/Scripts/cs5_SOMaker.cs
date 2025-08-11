using UnityEngine;

//에디터에서 해당 오브젝트 생성 가능
[CreateAssetMenu(fileName = "아이템", menuName = "Item/아이템")]
public class cs5_SOMaker : ScriptableObject
{
    public enum ItemType { 장비, 소비, 기타 }
    
    public string item_name;
    public ItemType type;
    public string description;

    public int level;
}

//각 데이터 별 정리

//json
//외부 텍스트 파일로 저장 관리 가능
//에디터와 런타임 모두 사용이 가능한 데이터
//데이터 구조가 자유로운 편
// ex) 세이브 데이터, 서버 통신용 데이터(DB 연동), 수시로 바뀔 수 있는 동적인 데이터

//so
//유니티 에셋(파일) 형태로 프로젝트 내부에 저장
//에디터와 광장히 친화적인 데이터
//수정사항이 바로 반영되고, 런타임에 빠르게 로드하고 참조도 가능(메모리 효율이 높음)
// ex) 정적인 데이터 구현, 고정형 데이터(아이템, 퀘스트, 몬스터, 스킬 ...)

//PlayerPrefs
//유니티가 제공해주는 키-값 저장소
//레지스트리, XML, Plist 등 내부에 저장되는 방식
// ex) 불륨, 퀘스트 완료 여부, 캐릭터 상태, 환경 설정