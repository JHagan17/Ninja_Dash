using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    //private Inventory inventory;
    //private Transform itemSlotContainer;
    //private Transform itemSlotTemplate;

    //private void Awake()
    //{
    //    itemSlotContainer = transform.Find("ItemSlotContainer");
    //    itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    //}

    //public void SetInventory(Inventory inventory)
    //{
    //    this.inventory = inventory;
    //    RefreshInVentoryItems();
    //}

    //private void RefreshInVentoryItems()
    //{
    //    int i = 0;
    //    int y = 0;
    //    float itemSlotCellSize = 10f;

    //    foreach (Item item in inventory.GetItemList())
    //    {
    //        RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
    //        itemSlotRectTransform.gameObject.SetActive(true);
    //        itemSlotRectTransform.anchoredPosition = new Vector2(i * itemSlotCellSize, y * itemSlotCellSize);
    //        Image image = itemSlotRectTransform.Find("image").GetComponents<Image>();
    //        image.sprite = item.GetItemPrefab();
    //        i++;

    //        if (i > 4)
    //        {
    //            i = 0;
    //            y++;
    //        }
    //    }
    //}
}
