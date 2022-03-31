using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Texture crosshairTexture;
    public CharacterController controller;
    public ItemPickup[] availableItems; //List with Prefabs of all the available items

    //Avabiable items slots 
    int[] itemSlots = new int[8];
    bool showInventory = false;
    float windowAnimation = 1;
    float animationTimer = 0;


    //UI Drag & Drop 
    int hoveringOverIndex = -1;
    int itemIndexToDrag = -1;
    Vector2 dragOffset = Vector2.zero;


    //Item Pick up
    ItemPickup detectedItem;
    int detectedItemIndex;



    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //Initialize Item Slots
        for (int i =0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = -1;
        }
    }


     void Update()
    {
        //Show/Hide Inventory
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            showInventory = !showInventory;
            animationTimer = 0;

            if(showInventory)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }


        if(animationTimer < 1)
        {
            animationTimer += Time.deltaTime;
        }

        if(showInventory)
        {
            windowAnimation = Mathf.Lerp(windowAnimation, 0, animationTimer);
            
        }
        else
        {
            windowAnimation = Mathf.Lerp(windowAnimation, 1f, animationTimer);
        }

        //Begin item drag
        if(Input.GetMouseButtonDown(0) && hoveringOverIndex > -1 && itemSlots[hoveringOverIndex] > -1)
        {
            itemIndexToDrag = hoveringOverIndex;
        }

        //Release dragged item
        if(Input.GetMouseButtonUp(0) && itemIndexToDrag > -1)
        {
            if(hoveringOverIndex < 0)
            {
                //Drop the item outside
                Instantiate(availableItems[itemSlots[itemIndexToDrag]], PlayerController.cam.position +
                    PlayerController.cam.forward, Quaternion.identity);
                itemSlots[itemIndexToDrag] = -1;
            }
            else
            {
                //Switch items between the selected slot and the one we are hovering on
                int itemIndexTmp = itemSlots[itemIndexToDrag];
                itemSlots[itemIndexToDrag] = itemSlots[hoveringOverIndex];
                itemSlots[hoveringOverIndex] = itemIndexTmp;
            }
        }
    }

}

