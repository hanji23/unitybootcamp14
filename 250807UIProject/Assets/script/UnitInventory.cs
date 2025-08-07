using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UnitInventory : MonoBehaviour
{
    public int gold;
    public int ruby;
    public int sapa;
    public int mpstone;

    public string[] inventory_item = new string[]
    {
        "골드",
        "루비",
        "사파이어",
        "마력석"
    };

    public int[] inventory_count = new int[]
    {
        0,0,0,0
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
