using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class sample : MonoBehaviour
{
    public Text t;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t.text = "Score : 0";
    }

    // Update is called once per frame
    void Update()
    {
        //t.text = string.Format($"Score : {player.GetComponent<playercontroller>().score}");
    }
}
