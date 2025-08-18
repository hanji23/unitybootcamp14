using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class test3 : MonoBehaviour
{
    Button button1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button1 = transform.GetChild(0).GetComponent<Button>();
        button1.onClick.AddListener(title);
    }

    private void title()
    {

        SceneManager.LoadScene("TitleScene");
    }
}
