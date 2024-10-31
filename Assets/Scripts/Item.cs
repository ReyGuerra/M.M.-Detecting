using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.CodeEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "M.M. Detecting/Item")]
public class Item : ScriptableObject
{
    [SerializeField] itemType type;
    [SerializeField] useType use;
    [SerializeField] public Sprite image;
    [SerializeField] string description;
    [SerializeField] bool useable = true;
    [SerializeField] int itemCode = -1;
    

    public enum itemType{
        clue,
        key, 
        potion,
        eat

    }

    public enum useType{
        read,
        unlock,
        consume,
    }

    public void setItemCode(int code){
            itemCode = code;
    }
    public int getItemCode(){
        return itemCode;
    }

    public void setItemDescription(string objectDescription){
            description = objectDescription;
    }

    public string getItemDescription(){
            return description;
    }
}
