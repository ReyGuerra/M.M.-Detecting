using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    Player player;
    int speed;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    Vector2 lastDirection;

    Inventory inventory;
    // Start is called before the first frame update
    void Awake(){
        player = GetComponent<Player>();
        inventory = GetComponent<Inventory>();
        speed = player.getSpeed();
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            lastDirection = movement;
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {   
            animator.SetFloat("Horizontal", lastDirection.x);
            animator.SetFloat("Vertical", lastDirection.y);
            animator.SetFloat("Speed", 0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.ToggleUI();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Object detected.");
        if(other.gameObject.CompareTag("Item")){
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
                inventory.setText("Item added to inventory...");
                Item item = other.GetComponent<GameItem>().item;
                if(inventory.addItem(item)){
                    Debug.Log("Item Added");
                    Destroy(other.gameObject);
                }
                else{
                    Debug.Log("Inventory Full");
                }
            // }
        }
        else if(other.gameObject.CompareTag("Door")){
            other.gameObject.GetComponent<Door>().unlockDoor();
        }
    }
  
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
