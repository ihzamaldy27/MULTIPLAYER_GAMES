using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaultable : MonoBehaviour
{
    Vaultable vaulting;
    public bool lompat = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vault")
        {
            lompat = true;
            if (lompat)
            {
                Debug.Log("Player siap Vaulting");
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Vault")
        {
            lompat = false;
            if (!lompat)
            {
                Debug.Log("Player meninggalkan Vault");
            }
        }
    }
}
