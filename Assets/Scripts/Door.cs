using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{

    public bool locked = true;
    public int doorCode = 1;
    
    [SerializeField] Inventory inventory;

    public void unlockDoor()
    {
        if(locked && inventory.useKey(doorCode)){
            locked = false;
            inventory.setText("Door is Unlocked and entered...");
        }
        else if (!locked)
        {
            inventory.setText("Entered door...");
        }
        else
        {
            inventory.setText("No key found.");
        }

    }
}
