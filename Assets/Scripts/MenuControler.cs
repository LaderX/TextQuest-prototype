using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControler : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject StageArtPanel;
    public GameObject SettingsPanel;

    Inventory inv;


    // Start is called before the first frame update
    void Start()
    {
         inv = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CloseAllOrOpenMenu()
    {
        InventoryPanel.SetActive(false);
        StageArtPanel.SetActive(false);

        if (SettingsPanel.activeInHierarchy) SettingsPanel.SetActive(false);
        else SettingsPanel.SetActive(true);
    }

    public void OpenCloseArt()
    {
        StageArtPanel.SetActive(!StageArtPanel.activeInHierarchy);

        if(InventoryPanel.activeInHierarchy == true)
        {
            InventoryPanel.SetActive(!InventoryPanel.activeInHierarchy);
        }

        if(StageArtPanel.activeInHierarchy != SettingsPanel.activeInHierarchy)
        {
            SettingsPanel.SetActive(!SettingsPanel.activeInHierarchy);
        }
    }

    public void OpenCloseInventory()
    {
        
        inv.UpdateInventoryView();

        InventoryPanel.SetActive(!InventoryPanel.activeInHierarchy);

        if (StageArtPanel.activeInHierarchy == true)
        {
            StageArtPanel.SetActive(!StageArtPanel.activeInHierarchy);
        }

        if (InventoryPanel.activeInHierarchy != SettingsPanel.activeInHierarchy)
        {
            SettingsPanel.SetActive(!SettingsPanel.activeInHierarchy);
        }
    }
}
