using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [Header("Player")]
    public string name = "ĳ���� �̸�";
    [Tooltip("ĳ���� ����")]
    public job myjob;
    //public string playerclass = "ĳ���� ����";
    [TextArea(5, 5)]
    public string description = "ĳ���� ����";

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
    [Tooltip("�Ϲ� ���ݷ�")]
    public float atk;
    [Range(0, 100)]
    [Tooltip("��� ���ݷ�")]
    public float atk_skill;
    [Range(0, 100)]
    [Tooltip("�Ϲ� ����")]
    public float def;
    [Range(0, 100)]
    [Tooltip("��� ����")]
    public float def_skill;
    [Range(0, 100)]
    [Tooltip("���� �ӵ�")]
    public float atk_move;
    [Range(0, 20)]
    [Tooltip("�̵� �ӵ�")]
    public float speed_move;

    public enum job
    {
        ����,
        ����,
        ����,
        �ü�,
        ������
    }

    [Serializable]
    public class Playerskill
    {
        [Tooltip("��ų �̸�")]
        public string name;
        [Tooltip("���� ���ð�")] [Range(0, 100)]
        public float skill_time;
        [Tooltip("��ų ����")]  [TextArea(2, 2)]
        public string description;
    }
    [Serializable]
    public class PlayerItem
    {
        [Tooltip("������ �̸�")]
        public string name;
        [Tooltip("����")] [Range(0, 100)]
        public int count;
        [Tooltip("������ ����")] [TextArea(2, 2)]
        public string description;
    }

    [Space(5)]
    [Header("skill")]
    public List<Playerskill> skill_list;

    [Space(5)] [Header("Item")]
    public List<PlayerItem> item_list;
}
