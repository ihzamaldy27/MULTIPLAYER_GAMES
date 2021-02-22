using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public ItemData[] data_item = new ItemData[2];
    public int[] item = new int [2];
    public Image[] SlotUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showItem()
    {
        for (int i = 0; i < SlotUI.Length; i++)
        {
            SlotUI[i].sprite = data_item[i].sprite;
            data_item[0].gameObject.SetActive(false);
        }
    }
}
