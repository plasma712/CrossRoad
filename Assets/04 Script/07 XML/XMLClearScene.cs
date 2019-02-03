using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLClearScene : Singleton<XMLClearScene>
{
    List<XMLClearSceneData> ClearScenes;

    //string filePath = "./Assets/Resources/ClearSceneList.xml";
    string filePath = "./Assets/08 NewFolder/ClearSceneList.xml";

    private void Awake()
    {
        LoadXml();
    }

    public void CreateXml()
    {
        ClearScenes = new List<XMLClearSceneData>();

        for(int i = 0; i < 1; i++)
        {
            XMLClearSceneData ClearScene = new XMLClearSceneData
            {
                ClearSceneNumber = ClearStageNumber.Instance.StageNumber
            };
            ClearScenes.Add(ClearScene);
        }

        XmlDocument Document = new XmlDocument();
        XmlElement ClearSceneListElement = Document.CreateElement("ClearSceneList");
        Document.AppendChild(ClearSceneListElement);

        foreach(XMLClearSceneData ClearScene in ClearScenes)
        {
            XmlElement ClearSceneElement = Document.CreateElement("ClearScene");
            ClearSceneElement.SetAttribute("ClearSceneNumber", ClearScene.ClearSceneNumber.ToString());

            ClearSceneListElement.AppendChild(ClearSceneElement);
        }
        Document.Save(filePath);

        LoadXml();
    }

    public void NewGameCreateXml()
    {
        ClearScenes = new List<XMLClearSceneData>();

        for (int i = 0; i < 1; i++)
        {
            XMLClearSceneData ClearScene = new XMLClearSceneData
            {
                ClearSceneNumber = i
            };
            ClearScenes.Add(ClearScene);
        }

        XmlDocument Document = new XmlDocument();
        XmlElement ClearSceneListElement = Document.CreateElement("ClearSceneList");
        Document.AppendChild(ClearSceneListElement);

        foreach (XMLClearSceneData ClearScene in ClearScenes)
        {
            XmlElement ClearSceneElement = Document.CreateElement("ClearScene");
            ClearSceneElement.SetAttribute("ClearSceneNumber", ClearScene.ClearSceneNumber.ToString());

            ClearSceneListElement.AppendChild(ClearSceneElement);
        }
        Document.Save(filePath);

        LoadXml();
    }

    public void LoadXml()
    {
        ClearScenes = new List<XMLClearSceneData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement ClearSceneListElement = Document["ClearSceneList"];

        foreach (XmlElement ClearSceneElement in ClearSceneListElement.ChildNodes)
        {
            XMLClearSceneData ClearScene = new XMLClearSceneData
            {
                ClearSceneNumber = System.Convert.ToInt32(ClearSceneElement.GetAttribute("ClearSceneNumber"))
            };
            ClearScenes.Add(ClearScene);
        }
    }

    public int ClearSceneLength()
    {
        return ClearScenes.Count;
    }

    public XMLClearSceneData GetClearSceneData(int _num)
    {
        for (int i = 0; i < ClearSceneLength(); i++)
        {
            return ClearScenes[i];
        }
        return null;
    }
}

public class XMLClearSceneData
{
    public int ClearSceneNumber;
}

