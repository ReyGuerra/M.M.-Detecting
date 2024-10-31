using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory playerInventory;
    [SerializeField] public InventorySlot[] inventorySlots;
    // InventorySlot selectedSlot;
    [SerializeField] public GameObject mainInventoryUI;
    [SerializeField] public GameObject inventoryItemPrefab;
    [SerializeField] public InventorySlot descriptionSlot;

    [SerializeField] public DescriptionHandler descriptionHandler;
    [SerializeField] public TextMeshProUGUI textMesh;
    public int objectsInInventory = 0;

    public int[] slotCodes;

    
    // Start is called before the first frame update
    // public void SelectSlot(InventorySlot slot){
    //     selectedSlot.Unselect();
    //     selectedSlot = slot;
    //     selectedSlot.Select();
    // }

    private void Awake()
    {
        playerInventory = this;
    }
    void Start()
    {
        mainInventoryUI.SetActive(false);
    }

    public bool addItem(Item item){
    
        for (int index = 0; index < inventorySlots.Length; index++)
        {
            if (inventorySlots[index].GetComponentInChildren<InventoryItem>() == null)
            {
                placeInInventory(item, inventorySlots[index]);
                // slotCodes[index] = item.getItemCode();
                objectsInInventory += 1;
                return true;
            }
        }
        return false;
    }
    public void placeInInventory(Item item, InventorySlot slot)
    {
        GameObject newItemGameObject = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGameObject.GetComponent<InventoryItem>();
        inventoryItem.initializeItem(item);

        descriptionHandler.setCurrItem(item);
    }
    public void ToggleUI(){
        if(mainInventoryUI.activeSelf){
            mainInventoryUI.SetActive(false);
        }
        else{
            mainInventoryUI.SetActive(true);
        }
    }
    
    public bool useKey(int keyCode){
        if (objectsInInventory >= 1)
        {
            int index = 0;
            InventoryItem slotItem;
            for (index = 0; index < inventorySlots.Length; index++)
            {
                slotItem = inventorySlots[index].GetComponentInChildren<InventoryItem>();
                if (slotItem != null && slotItem.item.getItemCode() == keyCode)
                {
                    setText("Key used to unlock door...");
                    Debug.Log("Found item. Slot: " + index);
                    Destroy(inventorySlots[index].GetComponentInChildren<InventoryItem>().gameObject);
                    objectsInInventory--;
                    return true;
                }
            }
        }
        return false;
    }

    public void setText(string text){
        textMesh.enabled = true;
        textMesh.SetText(text);
        Invoke("DisableText", 5f);
    }

    public void DisableText(){
        textMesh.enabled = false;
    }

}
