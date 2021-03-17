using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool empty;

    public GameObject ItemObject;
    public Sprite icon;

    public Transform slotIcon;
    private void Start()
    {
        slotIcon = transform.GetChild(0);
    }

    public void SlotUpdate()
    {
        slotIcon.GetComponent<Image>().sprite = icon;
    }

    public void SlotRemove()
    {
        ItemObject.GetComponent<ItemData>().pickUp = false;
        ItemObject = null;
        icon = null;
        slotIcon.GetComponent<Image>().sprite = null;

    }
}
