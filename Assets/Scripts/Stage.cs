using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public string id { get; set; }
    public string location { get; set; }
    public string StepText { get; set; }
    public Dictionary<string, Answer> Answers { get; set; }
    public List<string> AddList;
    public List<string> RemoveList;

    public Stage()
    {
        this.Answers = new Dictionary<string, Answer>();
    }

}

public class Answer
{
    public string answerText { get; set; }
    public string necessary { get; set; }
}
