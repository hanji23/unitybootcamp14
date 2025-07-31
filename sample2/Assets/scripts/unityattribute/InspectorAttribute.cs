using System.Collections.Generic;//c#에서 제공해주는 자료구조(List<T>, dictionary<K, V>같은 값) 사용 가능
using System;
using UnityEngine;

public class InspectorAttribute : MonoBehaviour
{
    // struct - 사용자 정의 타입 / value 타입 / GC 필요 없음
    // 작은 데이터의 묶음을 자주 할당/복사하는 개념에서 활용 ex) Vector3
    [System.Serializable]
    public struct BOOK 
    {
        public string name;
        public string description;
    }

    // class - 객체를 위한 설계도(속성과 기능) / 유니티에서는 클래스 사용을 권장(안정성) / 복사 과정에서의 실수 발생 가능성이 없음
    [Serializable]// == [System.Serializable]
    public class Item 
    {
        public string name; 
        public string description;
    }

    [Header("score")]//public int ponit;
    public int ponit;
    public int max_point;
    [Header("info")]
    public string nickname;

    public job myjob;

    //인스펙터에 공개하기 싫은 값에 대한 설정
    [HideInInspector]
    public int value = 5;

    //유니티에서 비공개(private) 필드를 인스펙터에 노출시키고 유니티의 직렬화 시스템에 포함시킵니다
    [SerializeField]
    private int value2 = 7;

    //사용목적
    //public -> 노출되고 접근가능
    //private -> 노출 x, 접근 x
    //SerializeField + private -> 노출 x, 인스펙터에서는 편집가능

    // *직렬화(Serialization) : 데이터를 저장가능한 형식으로 변환하는 작업
    //                          이 변환을 통해 씬, 프리펩, 에셋 등에 저장하고 복원하는 작업을 수행할 수 있습니다.

    //직렬화 조건
    // 1. public or [SerializeField]
    // 2. static이 아닌 경우(직렬화를 할 이유가 없음)
    // 3. 직렬화 가능한 데이터 타입인 경우

    //   - 직렬화 가능한 데이터
    //     1. 기본 데이터(int, float, bool, string...)
    //     2. 유니티에서 제공해주는 구조체(Vector3, Quaternion, Color)
    //     3. 유니티 객체 참조(Gameobject, Transform, Material)
    //     4. [Serializable] 속성이 붙은 클래스
    //     5. 배열/ 리스트

    //   - 직렬화 불가능한 데이터
    //     1. Dictionary<K, V>
    //     2. Interface(인터페이스)
    //     3. static 키워드가 붙은 필드
    //     4. abstract 키워드가 붙은 클래스


    //Space : 적은 높이만큼 간격이 생깁니다

    //TextArea : 긴 문자열을 여러줄로 적을 수 있는 설정
    //[TextArea]만 등록하면 여러줄 입력이 가능한 상태가 된다
    //[TextArea(기본 표시줄, 최대줄)]을 통해 인스펙터 상에서의 높이를 제어합니다
    //문자열 길이에 대한 제한적인 부분은 없습니다.
    [Space(10)] [TextArea(5,10)]
    public string quest_info;

    public BOOK book;
    public Item item;

    //유니티 인스펙터에서는 배열도 리스트로 나오게 됩니다
    //리스트<T>는 T 형태에 데이터를 묶음을 순차적으로 저장할 수 있는 데이터입니다
    //데이터의 검색, 추가, 삭제등의 기능이 제공됩니다.
    public List<Item> item_list;

    //배열
    public BOOK[] bokks = new BOOK[5];

    //직업 : 전사, 도적, 궁수, 마법사
    public enum job
    {
        전사, 
        도적, 
        궁수, 
        마법사
    }

    //Range(최소, 최대) 를 통해 해당값을 에디터에서 최소값과 최대가 설정되어있는 스크롤 형태의 값으로 변경됩니다(범위가 제한 됨)
    [Range(0,100)]public int bgm;
    [Range(0,100)]public float sfx;
}
