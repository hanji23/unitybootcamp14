using System;
using UnityEngine;

public class cs3_JsonTester : MonoBehaviour
{
    //유니티에서 객체(Object)의 필드(field)를 json으로 변환하기 위해서는
    //내부적으로 메모리에서 데이터를 읽고 쓰는 작업이 가능해야함
    //따라서 [Serializable] 속성을 추가해 해당 정보에 대한 직렬화를 처리해줄 필요가 있습니다

    //직렬화는 데이터를 저장하거나 전송하기위해 연속적인 데이터의 형태로 변형해주는 작업을 의미합니다.

    [Serializable]
    public class Data
    {
        public int hp;
        public int atk;
        public int def;
        public string[] items;
        public Postion postion;
        public string Quest;
        public bool isDead;
    }

    [Serializable]
    public class Postion
    {
        public float x;
        public float y;
    }

    public Data my_data;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var jsonText = Resources.Load<TextAsset>("data01");
        if (jsonText == null)
        {
            Debug.LogError("리소스 폴더에서 해당 파일을 찾지못함");
            return;
        }
        my_data = JsonUtility.FromJson<Data>(jsonText.text);

        Debug.Log(my_data.hp);
        Debug.Log(my_data.Quest);
        Debug.Log(my_data.def);
        Debug.Log(my_data.postion.x);
        Debug.Log(my_data.postion.y);

        foreach(var item in my_data.items)
        {
            Debug.Log(item);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
