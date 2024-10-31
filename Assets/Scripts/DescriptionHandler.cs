using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionHandler : MonoBehaviour
{
    public Item currItem;
    public string descriptionText;
    public UnityEngine.UI.Image itemImage;

    public TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    public void setCurrItem(Item item){
        currItem = item;
        itemImage.sprite = item.image;
        descriptionText = item.getItemDescription();

        textMeshPro.SetText(descriptionText);
    }





}
