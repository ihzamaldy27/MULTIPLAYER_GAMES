using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private int slot;
    private GameObject[] slotGame;

    public GameObject slotHolder;

    public Transform @throw;

    private void Start()
    {
        slot = 2;
        slotGame = new GameObject[slot];
        for(int i = 0; i < slot; i++)
        {
            slotGame[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slotGame[i].GetComponent<Slot>().ItemObject == null)
                slotGame[i].GetComponent<Slot>().empty = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RemoveItem(@throw);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other);
        if(other.tag == "Item")
        {
            //Debug.Log("test");
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("item");
                GameObject pickup = other.gameObject;
                ItemData data = pickup.GetComponent<ItemData>();

                AddItem(data.icon, data.ItemObject);
            }
        }
    }

    void AddItem(Sprite itemIcon, GameObject itemObj)
    {
        for (int i = 0; i < slot; i++)
        {
            if (slotGame[i].GetComponent<Slot>().empty)
            {
                itemObj.GetComponent<ItemData>().pickUp = true;

                slotGame[i].GetComponent<Slot>().ItemObject = itemObj;
                slotGame[i].GetComponent<Slot>().icon = itemIcon;

                itemObj.transform.parent = slotGame[i].transform;
                itemObj.SetActive(false);

                slotGame[i].GetComponent<Slot>().SlotUpdate();
                slotGame[i].GetComponent<Slot>().empty = false;
                break;
            }
        }
    }

    void RemoveItem(Transform away)
    {
        for (int i = 0; i < slot; i++)
        {
            if (!slotGame[i].GetComponent<Slot>().empty)
            {
                GameObject game;

                game = slotGame[i].GetComponent<Slot>().ItemObject;

                game.transform.parent = away.parent;
                game.SetActive(true);

                game.transform.position = away.position + new Vector3(1, 1, 1);

                slotGame[i].GetComponent<Slot>().SlotRemove();
                slotGame[i].GetComponent<Slot>().empty = true;
                break;
            }
        }
    }
}
