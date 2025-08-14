using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "attack Strategy/Melee")]
public class cs2_MeleeAttack : ScriptableObject, IAttackStrategy
{

    public void Attack(GameObject target)
    {
        float range = 1f;
        Transform p = GameObject.Find("Player").transform;

        float distance = Vector3.Distance(p.position, target.transform.position);

        if (distance < range)
        {
            Debug.Log($"[Melee Attack] -> {target}");
            target.GetComponent<SpriteRenderer>().color = Color.red;
            target.GetComponent<targetcolor>().colorstart();
        }
        else
        {
            Debug.Log("[Melee Attack Miss!]");
        }

        
    }

    //public void Attack()
    //{
    //    float range = 1f;
    //    Transform p = GameObject.Find("Player").transform;
    //    RaycastHit2D hit = Physics2D.Raycast(p.position, new Vector2(p.localScale.x, 0), range);
    //    Debug.DrawRay(p.position, new Vector2(p.localScale.x * range, 0), Color.red, 1);

    //    if (hit.collider != null)
    //    {
    //        Debug.Log($"[Melee Attack] -> {hit.collider.name}");
    //        hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    //        hit.collider.gameObject.GetComponent<targetcolor>().colorstart();
    //    }
    //    else
    //    {
    //        Debug.Log("[Melee Attack Miss!]");
    //    }


    //}

}
