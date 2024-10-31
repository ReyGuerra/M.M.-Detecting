using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{

    // public UnityEngine.UI.Image image;
    // public Color toggled, untoggled;

    // private void Awake(){
    //     Unselect();
    // }

    // public void Select(){
    //     image.color = toggled;
    // }

    // public void Unselect(){
    //     image.color = untoggled;
    // }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
        
    }


}
