using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : Singleton<EnemySummon>
{
    public GameObject My;
    //public Transform Enemey; 문제생기면 GameObject Enemey 삭제후 넣으면 됨
    public GameObject Enemey;

    public int iSecond = 1; // 나중에 난이도에 따라 조절 할 예정
    public int iCountingMonster = 0;
    int TutorialTextOneMore = 0;
    public List<GameObject> MonsterList = new List<GameObject>();
    public GameObject MonsterObject;
    private void Start()
    {
        //StartCoroutine("EnemeySummon");
    }

    IEnumerator EnemySummons()
    {
        while (true)
        {
            //TutorialText.Instance.EventProduct(24);
            Debug.Log("여기검사");
            if (iCountingMonster < 10)
            {
                Debug.Log("튜토리얼텍스트원모얼 : " + TutorialTextOneMore);
                if (TutorialTextOneMore == 0)
                {
                    Debug.Log("튜토리얼텍스트원모얼 : " + TutorialTextOneMore);
                    TutorialText.Instance.LilyLeft.gameObject.SetActive(false);
                    TutorialText.Instance.TutoriaMainTextLayOut.gameObject.SetActive(false);
                    TutorialTextOneMore++;
                    yield return new WaitForSeconds(0.01f);// 한번 늦추기
                }
                MonsterObject = Instantiate(Enemey, My.transform.position, Quaternion.identity);
                //MonsterAttack.Instance.EnemeyList(iCountingMonster);
                iCountingMonster++;
                MonsterList.Add(MonsterObject);
                yield return new WaitForSeconds(iSecond);

                Debug.Log("몬스터생성수... : " + iCountingMonster);
                Debug.Log("튜토리얼텍스트원모얼 : " + TutorialTextOneMore);
                if (iCountingMonster > 9)//10개 까지만 생산
                {
                    Debug.Log("여기 들어는 오냐?");
                    //if로 감쌀부분 (튜토리얼 SceneNumber로 제어해서 단 한번만 쓸예정)
                    if (TutorialTextOneMore == 1)
                    {
                        yield return new WaitForSeconds(0.1f);
                        Debug.Log("EnemySummon들어옴");
                        //TutorialText.Instance.TextNumber++;
                        Debug.Log(TutorialText.Instance.TextNumber);
                        TutorialText.Instance.LilyLeft.gameObject.SetActive(true);
                        TutorialText.Instance.TutoriaMainTextLayOut.gameObject.SetActive(true);
                        TutorialText.Instance.TutorialMenualText.gameObject.SetActive(true);
                        Debug.Log("텍스트 Number : " + TutorialText.Instance.TextNumber);
                        TutorialText.Instance.StartCoroutine("TutorialTextCoroutine");
                        TutorialTextOneMore++;
                        StopCoroutine("EnemySummons");
                    }
                    else
                        StopCoroutine("EnemySummons");
                }
            }
            else
                break;
        }
    }
    IEnumerator TutorialEnemeySummon()
    {
        while (true)
        {
            Debug.Log("튜토리얼적생성코루틴");
            MonsterObject = Instantiate(Enemey, My.transform.position, Quaternion.identity);
            //MonsterAttack.Instance.EnemeyList(iCountingMonster);
            iCountingMonster++;
            MonsterList.Add(MonsterObject);
            yield return new WaitForSeconds(iSecond);

            if (iCountingMonster == 1)//1개 까지만 생산
            {
                StopCoroutine("TutorialEnemeySummon");
                break;
            }
        }
    }
}
