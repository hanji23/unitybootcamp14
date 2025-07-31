using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [Header("Player")]
    public string name = "캐릭터 이름";
    [Tooltip("캐릭터 직업")]
    public job myjob;
    //public string playerclass = "캐릭터 직업";
    [TextArea(5, 5)]
    public string description = "캐릭터 설명";

    [Space(5)] [Header("stat1")]
    [Range(0, 10)]
    [Tooltip("max lv. 10")]
    public int Lv;
    [Range(0, 100)]
    public float hp = 100;
    [Range(0, 100)]
    public float mp = 100;
    [Range(0, 100)]
    public float exp;

    [Space(5)] [Header("stat2")]
    [Range(0, 100)]
    [Tooltip("일반 공격력")]
    public float atk;
    [Range(0, 100)]
    [Tooltip("기술 공격력")]
    public float atk_skill;
    [Range(0, 100)]
    [Tooltip("일반 방어력")]
    public float def;
    [Range(0, 100)]
    [Tooltip("기술 방어력")]
    public float def_skill;
    [Range(0, 100)]
    [Tooltip("공격 속도")]
    public float atk_move;
    [Range(0, 20)]
    [Tooltip("이동 속도")]
    public float speed_move;

    public enum job
    {
        없음,
        전사,
        도적,
        궁수,
        마법사
    }

    [Serializable]
    public class Playerskill
    {
        [Tooltip("스킬 이름")]
        public string name;
        [Tooltip("재사용 대기시간")] [Range(0, 100)]
        public float skill_time;
        [Tooltip("스킬 설명")]  [TextArea(2, 2)]
        public string description;
    }
    [Serializable]
    public class PlayerItem
    {
        [Tooltip("아이템 이름")]
        public string name;
        [Tooltip("개수")] [Range(0, 100)]
        public int count;
        [Tooltip("아이템 설명")] [TextArea(2, 2)]
        public string description;
    }

    [Space(5)]
    [Header("skill")]
    public List<Playerskill> skill_list;

    [Space(5)] [Header("Item")]
    public List<PlayerItem> item_list;
}
