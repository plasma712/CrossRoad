using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSeletionPoint : Singleton<MouseSeletionPoint>
{
    public GameObject My;
    public int TileNumbering = 0; // 일단 1일 경우에만 소환이 가능하게 하자.
    public int TutorialTileNumbering;
    public GameObject Effect;

    public void OnMouseEnter()
    {
        if (MonsterSummon.Instance.bBuy == true)
        {
            MonsterSummon.Instance.iTileNumbering = TileNumbering;
            MonsterSummon.Instance.TileIn = true;
            MonsterSummon.Instance.vPoint = My.transform.position;
        }

    }
    public void OnMouseExit()
    {
        if (MonsterSummon.Instance.bBuy == true)
        {
            MonsterSummon.Instance.vPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 5)); ;
        }
    }

    private void Start()
    {
        TutorialTileNumberChange();
        //Effect.gameObject.SetActive(false);
        if(TileNumbering==1)
        {
            EffectControTrue();
        }
        EffectControfalse();
    }

    public void TutorialTileNumberChange()
    {
        if (ClearStageNumber.Instance.StageNumber == 0)
        {
            TileNumbering = 0;
            Map.Instance.TileList[58].GetComponent<MouseSeletionPoint>().TileNumbering = 1;
        }
        else
            return;
    }

    public void EffectControTrue()
    {
        Effect.gameObject.SetActive(true);
    }
    public void EffectControfalse()
    {
        Effect.gameObject.SetActive(false);
    }
}
