using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using System.Xml;
using System.IO;

using TMPro;

public class StageCondition : MonoBehaviour
{
    public TextAsset asset;
    public Transform buttonPanel;
    public Font font;
    
    public GameObject mainText;
    public GameObject buttonPrefab;
    public GameObject locationButton;


    private Dictionary<string, Stage> questMap;
    private Inventory inv;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        LoadXML load = new LoadXML();
        load.asset = asset;
        load.Initialization();
        questMap = load.questMap;
        inv = GetComponent<Inventory>();

        updateStage("Start");
    }

    public void updateStage(string idStage)
    {
        if (buttonPanel.childCount != 0)
        {
            foreach (Transform child in buttonPanel)
            {
                
                Destroy(child.gameObject);
                Debug.Log("destroy button");
                
            }
        }

        mainText.GetComponent<TextMeshProUGUI>().SetText(questMap[idStage].StepText);
        locationButton.GetComponent<TextMeshProUGUI>().SetText(questMap[idStage].location);

        if (questMap[idStage].Answers.Count != 0)
        {
            foreach (KeyValuePair<string, Answer> kvp in questMap[idStage].Answers)
            {
                //string necessary= questMap[idStage].Answers[kvp.Key].necessary;
               if (questMap[idStage].Answers[kvp.Key].necessary == null)
                {
                    CreateButton(kvp.Key, questMap[idStage].Answers[kvp.Key].answerText);
                }
                else
                {
                    if (inv.inventoryList.ContainsKey(questMap[idStage].Answers[kvp.Key].necessary))
                    {
                        CreateButton(kvp.Key, questMap[idStage].Answers[kvp.Key].answerText);
                    }
                }
            }
        }

        //Add
        if(questMap[idStage].AddList != null)
        {
            foreach (string item in questMap[idStage].AddList)
            {
                inv.AddItem(item);
            }
            //inv.UpdateInventoryView();
        }

        //Remove
        if (questMap[idStage].RemoveList != null)
        {
            foreach (string item in questMap[idStage].RemoveList)
            {
                inv.removeItem(item);
            }
            //inv.UpdateInventoryView();
        }

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateButton( string id, string name)
    {
        GameObject newButton = Instantiate(buttonPrefab, buttonPanel, false);
        //Обращаемся к первому ребенку кнопки и устанавлем для него значение текста
        //We turn to the first child of the button and set the text value for it
        newButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(name);
        newButton.GetComponent<Button>().onClick.AddListener(delegate { PressButton(id); });

    }

    public void PressButton(string id)
    {
        updateStage(id);
    }
}
