﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonsterSelectListManager : Singleton<MonsterSelectListManager>
{
    List<MonsterDataSave> Monsters;

    [SerializeField]
    GameObject MonsterListPreFab;

    [SerializeField]
    RectTransform ContentRectTrans;

    public void Init()
    {
        Monsters = new List<MonsterDataSave>();
        GameObject tmp;
        if (TutorialText.Instance.SummonSuccess == 0)
        {
            for (int i = 0; i < XMLMonster.Instance.Monsters.Count; i++)
            {
                tmp = Instantiate(MonsterListPreFab, ContentRectTrans);
                Monsters.Add(tmp.GetComponent<MonsterDataSave>());
                Monsters[Monsters.Count - 1].Init(XMLMonster.Instance.Monsters[i]);// 
            }

        }
        else
        {
            for (int i = 1; i < XMLMonster.Instance.Monsters.Count; i++)
            {
                tmp = Instantiate(MonsterListPreFab, ContentRectTrans);
                Monsters.Add(tmp.GetComponent<MonsterDataSave>());
                Monsters[Monsters.Count - 1].Init(XMLMonster.Instance.Monsters[i]);// 
            }
        }
        ContentRectTrans.sizeDelta = new Vector2(ContentRectTrans.sizeDelta.x, 230 * XMLMonster.Instance.Monsters.Count);

    }
}
