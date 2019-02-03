using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStageNumber : Singleton<ClearStageNumber>
{
    public int StageNumber;

    XMLClearSceneData CurrentData;

    public void Start()
    {
        CurrentClearStage();
    }

    public void CurrentClearStage()
    {
        CurrentData = XMLClearScene.Instance.GetClearSceneData(0);
        StageNumber = CurrentData.ClearSceneNumber;
    }

    public void ClearStage()
    {
        Debug.Log("클리어스테이지 들어옴");
        StageNumber++;
        XMLClearScene.Instance.CreateXml();        
    }
}
