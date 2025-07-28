using UnityEngine;

public class sample1 : MonoBehaviour
{
    public customcomponent cc;

    private void Awake()
    {
        cc = GetComponent<customcomponent>();
    }

}
