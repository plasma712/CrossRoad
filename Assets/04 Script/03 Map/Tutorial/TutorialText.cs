using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialText : Singleton<TutorialText>
{
    public int SummonSuccess;
    public int TextNumber;
    public int GoldSoulNumber;
    //public GameObject MenuText;

    public GameObject Culling;

    MapSettingTutorialText CurrentText;
    int TextCount = 0; // 이것을 토대로 insert로 대입할 예정

    public float TextTime;
    public GameObject NextButton;
    //public GameObject SkipButton;

    #region 튜토리얼에서 사용하는 이미지 관리
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public GameObject LilyLeft;
    public GameObject LilyRight;
    public GameObject Ellisia;
    public GameObject Production01;
    public GameObject Production02;
    public GameObject MonsterList;
    public GameObject Cave;
    public Text TutorialMenualText;
    public Text TemporatySave;
    public Text DummyText;
    public Text CharactersName;
    public GameObject GoldEffect;
    public GameObject SoulEffect;
    public GameObject TutoriaMainTextLayOut;
    public GameObject TutorialFinally;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion


    private void Update()
    {
        if (SummonSuccess == 1)
        {
            NextTextNumber();//이거 삭제할지 안할지 확인요망
            MonsterList.gameObject.SetActive(false);
            TutoriaMainTextLayOut.gameObject.SetActive(true);
            //TutorialMenualText.gameObject.SetActive(true);
            SummonSuccess++;
            //NextText();
            //StartCoroutine("TutorialTextCoroutine");
        }
    }

    private void Awake()
    {
        StartCoroutine("TutorialTextCoroutine");
        NextButton.gameObject.SetActive(false);
        //SkipButton.gameObject.SetActive(true);
    }


    IEnumerator TutorialTextCoroutine()
    {
        /// <summary>
        /// CurrentText에서 text를 미리 캐싱해놓음
        /// </summary>
        TutoriaMainTextLayOut.gameObject.SetActive(true);
        TutorialMenualText.text = DummyText.text;
        TemporatySave.text = DummyText.text;
        if (TextNumber == 17)
        {
            Debug.Log("씨발 제발 좀");
        }

        if (TextNumber == 18) // 씬넘기기
        {
            SceneChange.Instance.MapSettingGameStartTutorial();
        }
        CurrentText = XMLMapSettingTutorial.Instance.GetMapSettingTutorial(TextNumber);
        EventProduct(CurrentText.EventNumber); // 이벤트씬 
        CharactersName.text = CurrentText.Characters; // 현 대화창 이름
        TemporatySave.text = CurrentText.MenualExplanationText;
        yield return new WaitForSeconds(0.1f); // 일부러 지연시킴 TemporatySave가 빠르게 읽지를 못하는경우가 있어서
        while (true)
        {
            TutorialMenualText.text = TutorialMenualText.text.ToString().Insert(TutorialMenualText.text.ToString().Length, TemporatySave.text[TextCount].ToString());
            yield return new WaitForSeconds(0.01f); // 일부러 지연시킴
            SoundManagement.Instance.KeyboardSound();
            yield return new WaitForSeconds(TextTime); // 텍스트 나오는 속도
            TextCount++;
            if (TemporatySave.text.ToString().Length <= TutorialMenualText.text.ToString().Length)
            {
                //Debug.Log("여기 지나나?");
                TextCount = 0; // 텍스트 카운트 리셋시켜줌
                if (CurrentText.EventNumber != 30)
                {
                    NextButton.gameObject.SetActive(true);  // 대화스크립트가 끝나면 여기서 멈춰줌
                    UI_animaiton.Instance.StartCoroutine("UI_ani");
                }
                Debug.Log("이벤트제어 변수 값 :  " + CurrentText.EventNumber);
                if (CurrentText.EventNumber == 9)
                {
                    CharactersName.GetComponent<Text>().text = "릴리";
                }

                else if (CurrentText.EventNumber == 30)
                {
                    NextButton.gameObject.SetActive(false);
                    //LilyLeft.GetComponentInChildren<CharEvent>().BoxSetActiveTrue();
                    //Ellisia.GetComponentInChildren<CharEvent>().BoxSetActiveTrue();

                   LilyLeft.GetComponent<CharEvent>().BoxSetActiveTrue();
                   Ellisia.GetComponent<CharEvent>().BoxSetActiveTrue();
                }
                StopCoroutine("TutorialTextCoroutine"); // 대화스크립트가 끝나면 여기서 멈춰줌
                break;
            }
            // currentText의 길이값 보다 커지면 break 걸어야할듯?
        }
    }

    public void TutorialEvent3132(int _TextNumber)
    {
        CurrentText = XMLMapSettingTutorial.Instance.GetMapSettingTutorial(_TextNumber);
        CharactersName.text = CurrentText.Characters;
        TutorialMenualText.text = CurrentText.MenualExplanationText;
    }

    //
    //public void TextSkip()
    //{
    //    StopCoroutine("TutorialTextCoroutine");
    //    TutorialMenualText.text = TemporatySave.text;
    //    NextButton.gameObject.SetActive(true);
    //    SkipButton.gameObject.SetActive(false);
    //}
    //


    public void NextText()
    {
        NextButton.gameObject.SetActive(false);
        if (TextNumber == 22)
        {
            EventProduct(24);
            NextTextNumber();
        }
        else
        {
            if (TextNumber == 15)
            {
                LilyLeft.gameObject.SetActive(false);
                MonsterList.gameObject.SetActive(true);
                //TutorialMenualText.gameObject.SetActive(false);
                TutoriaMainTextLayOut.gameObject.SetActive(false);

            }
            else
            {
                NextTextNumber();
                StartCoroutine("TutorialTextCoroutine");
            }
        }
        Debug.Log("NextText() 함수 : " + TextNumber);
    }

    public void EventProduct(int _TextNumber)
    {
        if (_TextNumber == 0)
        {
            LobbyTopUIData.Instance.GetHeart(3);
            Production01.SetActive(true);
            Production02.SetActive(false);
            LilyLeft.SetActive(true);
            Ellisia.SetActive(false);
        }
        else if (_TextNumber == 3)
        {
            Production01.SetActive(false);
            Production02.SetActive(true);
        }
        else if (_TextNumber == 5)
        {
            Production02.SetActive(false);
        }
        else if (_TextNumber == 6)
        {
            CameraShake.Instance.ShakeCamera(1, 0.3f);
        }
        else if (_TextNumber == 8)
        {
            CameraShake.Instance.ShakeCamera(2, 0.02f);
        }
        else if (_TextNumber == 12)
        {
            //여기서 사운드 들릴예정
            CameraShake.Instance.ShakeCamera(1, 0.05f);
            SoundManagement.Instance.EventNumber13Sound();
        }
        else if (_TextNumber == 13)
        {
            //맵창 띄움
            Cave.gameObject.SetActive(false);
            Culling.gameObject.SetActive(true);
        }

        else if (_TextNumber == 14)
        {
            //이펙트 표시 상단 UI
            GoldEffect.gameObject.SetActive(true);
            SoulEffect.gameObject.SetActive(true);
            LobbyTopUIData.Instance.GetGold(10000);
            LobbyTopUIData.Instance.GetSoul(10000);
        }
        else if (_TextNumber == 15)
        {
            GoldEffect.gameObject.SetActive(false);
            SoulEffect.gameObject.SetActive(false);
        }
        else if (_TextNumber == 16)
        {
            //릴리 없애줌
        }
        else if (_TextNumber == 17)
        {
            // 특정지역에 손가락애니메이션을 넣어 클릭하도록 유도
            // 맵에 다른영역 선택안되게 하는 투명창 만들예정(LayCast설정을 통해 다른곳에 클릭조차 안됨)
            TutorialMenualText.gameObject.SetActive(true);
            Map.Instance.TileList[58].GetComponent<MouseSeletionPoint>().EffectControTrue();
        }
        else if (_TextNumber == 18)
        {
            //맵창그대로 둔상태로 릴리만 띄움
            LilyLeft.gameObject.SetActive(true);
            //StartCoroutine("TutorialTextCoroutine");
            Debug.Log("InherentNumber : " + TextNumber);
        }
        else if (_TextNumber == 19)
        {
            Map.Instance.TileList[58].GetComponent<MouseSeletionPoint>().EffectControfalse();
            //현재 씬은 넘어간상황

        }
        else if (_TextNumber == 22)
        {
            LilyLeft.gameObject.SetActive(false);
            LilyRight.gameObject.SetActive(true);
            EnemySummon.Instance.StartCoroutine("TutorialEnemeySummon");//한마리 생산
            EnemyMove.Instance.TutorialMoveSpeedZero();
            EnemyMove.Instance.TutorialSpot.gameObject.SetActive(true);
        }
        else if (_TextNumber == 23)
        {
            LilyLeft.gameObject.SetActive(true);
            LilyRight.gameObject.SetActive(false);
            EnemyMove.Instance.TutorialSpot.gameObject.SetActive(false);

        }
        else if (_TextNumber == 24) // 이거 제어 변수해줘야함
        {
            TutorialMenualText.gameObject.SetActive(false);
            EnemyMove.Instance.TutorialMoveSpeed();
            EnemySummon.Instance.StartCoroutine("EnemySummons");
        }
        else if (_TextNumber == 26)
        {
            Ellisia.gameObject.SetActive(true);
        }
        else if (_TextNumber == 27)
        {
            CameraShake.Instance.ShakeCamera(1, 0.05f);
        }
        //else if (_TextNumber == 24)
        //{
        //}
        //else if (_TextNumber == 24)
        //{
        //}

        else
        {
            return;
        }
    }

    public void NextTextNumber()
    {
        TextNumber++;
    }

    public void BeforeTextNumber()
    {
        TextNumber--;
    }

    public void Tendency()
    {
        //TendencyUIData.Instance.GetSanctity(100); // 현재 릴리만 선택하게 하지만 원래라면 튜토리얼이 끝나고 선지수 100을 기본값으로 책정할 예정이었기 때문에 넣는것
        //TendencyUIData.Instance.GetDarkNess(100); // 만약 고칠예정이라면 튜토리얼이 끝날시, 100점을 미리 주고 선악지수를 추가 증정
        //ClearStageNumber.Instance.ClearStage();
        Debug.Log("Tendency 여기 들어옴 ");
    }
}
