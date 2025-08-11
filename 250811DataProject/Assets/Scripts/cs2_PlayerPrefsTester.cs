using UnityEngine;

//키(key)와 값(Value)
//키(key) : 값에 접근하기위한 데이터로, 키는 고유한 이름을 가지게 됩니다.
//값(Value) : 키를 통해서 얻을 수 있는 실질적인 값

//키와 값이 한 쌍으로 관리되는 데이터는 키가 삭제되면, 값도 같이 삭제됩니다.
//'키'를 통해 값을 조회하고, 추가하고, 삭제하는 과정을 매우 빠르게 진행할 수 있습니다

//유니티 내에서 해당 형태의 데이터
// 1. Dictinary<k, v> : C#에서 제공되는 표준 자료 구조
// 2. PlayerPrefs : 유니티에서 제공하는 키-값 저장 시스템(클래스)
// 3. Json : 외부에서 작성된 json 파일도 키-값 형태로 작성할 수 있습니다
// 4. ScriptableObject : 자체적으로는 제공이 안되나 Dictinary와 섞어서 사용합니다

//플레이어 프립스(PlayerPrefs)
// 간단한 데이터를 저장할때 사용되는 데이터 저장 시스템
// 복잡한 데이터나 큰용량을 요구하는 데이터 저장에는 부적합합니다
//주로 고려되는 상황 : 점수, 플레이어의 진행 상태, 게임 설정 값(해상도, 컨트롤, 볼륨 등등)
//장점 : 즉각적이고 간편한 저장 / 로드에 대한 구현에서는 편함
//       플랫폼 별로의 저장 경로, 포맷 걱정없이 사용됩니다
//       ex) window  -> 레지스트리 경로 (레지스트리 편집기를 통해 위치 확인 -> 컴퓨터\HKEY_CURRENT_USER\SOFTWARE\Unity\UnityEditor\)
//           macOS   -> ~/Library/Preferences/unity.[company].[project_name].plist(plist파일)
//           ios     -> ios 내부 저장소
//           android -> XML 파일 (앱 데이터 저장소)
//           webGL   -> 플랫폼별 브라우저 지원에 맞는 저장소 사용

//단점 : 플레이어가 편집이 가능한 영역이기 때문에 보안성이 낮음

public class cs2_PlayerPrefsTester : MonoBehaviour
{
    public int score;
    public int max_score = 10;

    private void Start()
    {
        //"score"키의 값을 얻어옵니다
        //만약 해당 키가 존재하지 않는다면 적어준 값이 return됩니다.
        //score = PlayerPrefs.GetInt("score", 1);

        //max_score의 값을 가지는 "Maxscore"키를 등록합니다
        PlayerPrefs.SetInt("Maxscore", max_score);

        //스크립트에 의한 저장을 강제로 호출합니다
        PlayerPrefs.Save();
        //이코드가 없어도 자동으로 저장은 됩니다

        Debug.Log(score);
        Debug.Log(PlayerPrefs.GetInt("Maxscore"));
    }

    public void ResetPrefs()
    {
        //레지스트리에 있는 플레이어 프립스 값을 전부 제거합니다.
        PlayerPrefs.DeleteAll();
    }
}
