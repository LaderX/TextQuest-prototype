using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using System.IO;

public class LoadXML /*: MonoBehaviour*/
{

    public TextAsset asset { get; set; }
    public Dictionary<string, Stage> questMap { get; set; }

  /*  
    public LoadXML(TextAsset asset)
    {
        this.asset = asset;
    }
   */

    // Use this for initialization
    /*
    void Start()
    {
        questMap = new Dictionary<string, Stage>();
        //change the read mechanism once
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(asset.text));
        XmlElement xRoot = document.DocumentElement;
        foreach (XmlNode xnode in xRoot)
        {
            Stage stage = new Stage();
            stage.Answers = new List<string>();
            XmlNode attr = xnode.Attributes.GetNamedItem("id");
            if (attr != null)
                stage.id = attr.Value;
            foreach (XmlNode childnode in xnode.ChildNodes)
            {
                
                if (childnode.Name == "text")
                {
                    stage.StepText = childnode.InnerText;
                }
                if (childnode.Name == "answer")
                {
                    XmlNode attrLink = childnode.Attributes.GetNamedItem("link");
                    if (attrLink != null) { stage.Answers.Add(attrLink.Value); }                       
                    
                }
            }
            questMap.Add(stage.id, stage);
        }
        
    }

    */

    public void Initialization()
    {
        questMap = new Dictionary<string, Stage>();
        //change the read mechanism once
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(asset.text));
        XmlElement xRoot = document.DocumentElement;
        foreach (XmlNode xnode in xRoot)
        {
            Stage stage = new Stage();
            //stage.Answers = new Dictionary<string, string>();
            //stage.AddList = new List<string>();
            XmlNode attr = xnode.Attributes.GetNamedItem("id");
            if (attr != null)
                stage.id = attr.Value;
            XmlNode attrLocatin = xnode.Attributes.GetNamedItem("location");
            if (attrLocatin != null)
                stage.location = attrLocatin.Value;

            foreach (XmlNode childnode in xnode.ChildNodes)
            {

                if (childnode.Name == "text")
                {
                    stage.StepText = childnode.InnerText;
                }
                if (childnode.Name == "answer")
                {
                    Answer ans = new Answer();
                    

                    XmlNode attrLink = childnode.Attributes.GetNamedItem("link");
                    ans.answerText = childnode.InnerText;
                    

                    if (childnode.Attributes.GetNamedItem("necessary") !=null) { 
                        XmlNode attrNecessary = childnode.Attributes.GetNamedItem("necessary");
                        ans.necessary = attrNecessary.Value;
                    }

                    if (attrLink != null) { stage.Answers.Add(attrLink.Value, ans); }

                }


                //Add
                if (childnode.Name == "add") {
                    stage.AddList = new List<string>();
                    foreach (XmlNode addItem in childnode.ChildNodes)
                    {

                        if (addItem.Name == "item")
                        {
                            XmlNode attrName = addItem.Attributes.GetNamedItem("name");
                            if (attrName != null) { stage.AddList.Add(attrName.Value); }

                        }
                    }
                }

                //Remove
                if (childnode.Name == "remove")
                {
                    stage.RemoveList = new List<string>();
                    foreach (XmlNode addItem in childnode.ChildNodes)
                    {

                        if (addItem.Name == "item")
                        {
                            XmlNode attrName = addItem.Attributes.GetNamedItem("name");
                            if (attrName != null) { stage.RemoveList.Add(attrName.Value); }

                        }
                    }
                }
            }
            questMap.Add(stage.id, stage);
        }
    }
}
