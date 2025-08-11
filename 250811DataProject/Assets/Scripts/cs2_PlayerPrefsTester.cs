using UnityEngine;

//Ű(key)�� ��(Value)
//Ű(key) : ���� �����ϱ����� �����ͷ�, Ű�� ������ �̸��� ������ �˴ϴ�.
//��(Value) : Ű�� ���ؼ� ���� �� �ִ� �������� ��

//Ű�� ���� �� ������ �����Ǵ� �����ʹ� Ű�� �����Ǹ�, ���� ���� �����˴ϴ�.
//'Ű'�� ���� ���� ��ȸ�ϰ�, �߰��ϰ�, �����ϴ� ������ �ſ� ������ ������ �� �ֽ��ϴ�

//����Ƽ ������ �ش� ������ ������
// 1. Dictinary<k, v> : C#���� �����Ǵ� ǥ�� �ڷ� ����
// 2. PlayerPrefs : ����Ƽ���� �����ϴ� Ű-�� ���� �ý���(Ŭ����)
// 3. Json : �ܺο��� �ۼ��� json ���ϵ� Ű-�� ���·� �ۼ��� �� �ֽ��ϴ�
// 4. ScriptableObject : ��ü�����δ� ������ �ȵǳ� Dictinary�� ��� ����մϴ�

//�÷��̾� ������(PlayerPrefs)
// ������ �����͸� �����Ҷ� ���Ǵ� ������ ���� �ý���
// ������ �����ͳ� ū�뷮�� �䱸�ϴ� ������ ���忡�� �������մϴ�
//�ַ� ����Ǵ� ��Ȳ : ����, �÷��̾��� ���� ����, ���� ���� ��(�ػ�, ��Ʈ��, ���� ���)
//���� : �ﰢ���̰� ������ ���� / �ε忡 ���� ���������� ����
//       �÷��� ������ ���� ���, ���� �������� ���˴ϴ�
//       ex) window  -> ������Ʈ�� ��� (������Ʈ�� �����⸦ ���� ��ġ Ȯ�� -> ��ǻ��\HKEY_CURRENT_USER\SOFTWARE\Unity\UnityEditor\)
//           macOS   -> ~/Library/Preferences/unity.[company].[project_name].plist(plist����)
//           ios     -> ios ���� �����
//           android -> XML ���� (�� ������ �����)
//           webGL   -> �÷����� ������ ������ �´� ����� ���

//���� : �÷��̾ ������ ������ �����̱� ������ ���ȼ��� ����

public class cs2_PlayerPrefsTester : MonoBehaviour
{
    public int score;
    public int max_score = 10;

    private void Start()
    {
        //"score"Ű�� ���� ���ɴϴ�
        //���� �ش� Ű�� �������� �ʴ´ٸ� ������ ���� return�˴ϴ�.
        //score = PlayerPrefs.GetInt("score", 1);

        //max_score�� ���� ������ "Maxscore"Ű�� ����մϴ�
        PlayerPrefs.SetInt("Maxscore", max_score);

        //��ũ��Ʈ�� ���� ������ ������ ȣ���մϴ�
        PlayerPrefs.Save();
        //���ڵ尡 ��� �ڵ����� ������ �˴ϴ�

        Debug.Log(score);
        Debug.Log(PlayerPrefs.GetInt("Maxscore"));
    }

    public void ResetPrefs()
    {
        //������Ʈ���� �ִ� �÷��̾� ������ ���� ���� �����մϴ�.
        PlayerPrefs.DeleteAll();
    }
}
