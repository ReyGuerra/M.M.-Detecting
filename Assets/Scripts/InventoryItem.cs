using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq.Expressions;
using UnityEngine.Timeline;


public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler//, IPointerClickHandler
{
    
    [HideInInspector] public Item item;
    public UnityEngine.UI.Image image;
    public Transform parentAfterDrag;


    // public void Start(){
    //     initializeItem(item);
    // }
    public void initializeItem(Item newItem){
        item = newItem;
        image.sprite = newItem.image;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {   
        // Inventory.playerInventory.placeInInventory(item, Inventory.playerInventory.descriptionSlot);

        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag); 
    }
}
