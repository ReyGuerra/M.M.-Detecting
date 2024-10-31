using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public Item item;
    [SerializeField] int itemNum;
    [SerializeField] string description;
    
    void Awake()
    {
        item.setItemDescription(description);
        item.setItemCode(itemNum);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
