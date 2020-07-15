using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Inventory : MonoBehaviour
{
    public Transform itemPanel;
    public GameObject itemPrefab;


    public Dictionary<string, int> inventoryList = new Dictionary<string, int>();

    public void AddItem(string itemName, int itemNum)
    {
        if (inventoryList.ContainsKey(itemName))
        {
            inventoryList[itemName] = inventoryList[itemName] + itemNum;
        }
        else
        {
            inventoryList.Add(itemName, itemNum);
        }
    }

    public void AddItem(string itemName)
    {
        if (inventoryList.ContainsKey(itemName))
        {
            inventoryList[itemName] = inventoryList[itemName] + 1;
        }
        else
        {
            inventoryList.Add(itemName, 1);
        }
    }


    public void removeItem(string itemName)
    {
        if (inventoryList.ContainsKey(itemName))
        {
            inventoryList[itemName]= inventoryList[itemName] - 1;
            if (inventoryList[itemName] == 0)
            {
                inventoryList.Remove(itemName);
            }
        }
    }

    public void removeItem(string itemName, int itemNum)
    {
        if (inventoryList.ContainsKey(itemName))
        {
            inventoryList[itemName] = inventoryList[itemName] - itemNum;

            if (inventoryList[itemName] == 0)
            {
                inventoryList.Remove(itemName);
            }else if(inventoryList[itemName] < 0)
            {
                Debug.Log("error item list");
            }
        }
    }

    public void UpdateInventoryView()
    {
        if (itemPanel.childCount != 0)
        {
            foreach (Transform child in itemPanel)
            {
                Destroy(child.gameObject);
                Debug.Log("destroy item");
            }
        }
        foreach (KeyValuePair<string, int> item in inventoryList)
        {
            GameObject newItem = Instantiate(itemPrefab, itemPanel, false);
            newItem.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().SetText(item.Key);            
        }
        Debug.Log("Item View Update");
    }

    // Start is called before the first frame update
    void Start()
    {
        //AddItem("Ключь карта");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
