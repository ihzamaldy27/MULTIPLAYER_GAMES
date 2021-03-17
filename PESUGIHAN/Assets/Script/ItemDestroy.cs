using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    public ItemData itemData;
    public GameObject itemObjek;
    public Transform setPoint;
    void Start()
    {
        itemObjek.GetComponent<ItemData>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (!itemData.pickUp))
        {
            if (itemData.pickUp)
            {
                itemData.destroyItem = false;
                Debug.Log("Item gagal dihancurkan");
                StopCoroutine(itemDestroy(itemObjek.gameObject));
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Pembakaran")
        {
            Debug.Log("Item ini siap dihancurkan");
            itemData.destroyItem = true;
            StartCoroutine(itemDestroy(itemObjek.gameObject));
        }
    }

    IEnumerator itemDestroy(GameObject item)
    {
         yield return new WaitForSeconds(5);
         Destroy(item);
    }
}
