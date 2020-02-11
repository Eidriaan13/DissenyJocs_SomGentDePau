using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    

    

    public enum ItemType
    {
        Pedra,
        Adoqui,
        Ampolla,
        Molotov
    }

    public GameObject inventoryItemPos1;
    public int inventoryItem1_Qty = 0;
    public Text inventoryItem1_QtyText;

    public GameObject inventoryItemPos2;
    public int inventoryItem2_Qty = 0;
    public Text inventoryItem2_QtyText;

    public GameObject inventoryItemPos3;
    public int inventoryItem3_Qty = 0;
    public Text inventoryItem3_QtyText;

    public GameObject inventoryItemPos4;
    public int inventoryItem4_Qty = 0;
    public Text inventoryItem4_QtyText;


    public Image selectedHighlight;
    public ItemType selectedItem = ItemType.Pedra;

    public KeyCode item1_KeyCode = KeyCode.Alpha1;
    public KeyCode item2_KeyCode = KeyCode.Alpha2;
    public KeyCode item3_KeyCode = KeyCode.Alpha3;
    public KeyCode item4_KeyCode = KeyCode.Alpha4;


    private void Start()
    {
        inventoryItem1_QtyText.text = inventoryItem1_Qty.ToString();
        inventoryItem2_QtyText.text = inventoryItem2_Qty.ToString();
        inventoryItem3_QtyText.text = inventoryItem3_Qty.ToString();
        inventoryItem4_QtyText.text = inventoryItem4_Qty.ToString();
    }

    private void Update()
    {
        inventoryItem1_QtyText.text = inventoryItem1_Qty.ToString();
        inventoryItem2_QtyText.text = inventoryItem2_Qty.ToString();
        inventoryItem3_QtyText.text = inventoryItem3_Qty.ToString();
        inventoryItem4_QtyText.text = inventoryItem4_Qty.ToString();

        if (Input.GetKeyDown(item1_KeyCode))
        {
            selectedItem = ItemType.Pedra;
            selectedHighlight.transform.position = inventoryItemPos1.transform.position;
        }
        if (Input.GetKeyDown(item2_KeyCode))
        {
            selectedItem = ItemType.Adoqui;
            selectedHighlight.transform.position = inventoryItemPos2.transform.position;
        }
        if (Input.GetKeyDown(item3_KeyCode))
        {
            selectedItem = ItemType.Ampolla;
            selectedHighlight.transform.position = inventoryItemPos3.transform.position;
        }
        if (Input.GetKeyDown(item4_KeyCode))
        {
            selectedItem = ItemType.Molotov;
            selectedHighlight.transform.position = inventoryItemPos4.transform.position;
        }

    }




    public void BuyItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.Pedra:
                inventoryItem1_Qty++;
                break;

            case ItemType.Adoqui:
                inventoryItem2_Qty++;
                break;

            case ItemType.Ampolla:
                inventoryItem3_Qty++;
                break;

            case ItemType.Molotov:
                inventoryItem4_Qty++;
                break;

            default:
                break;
        }
    }
    public void ConsumeItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.Pedra:
                inventoryItem1_Qty--;
                break;

            case ItemType.Adoqui:
                inventoryItem2_Qty--;
                break;

            case ItemType.Ampolla:
                inventoryItem3_Qty--;
                break;

            case ItemType.Molotov:
                inventoryItem4_Qty--;
                break;

            default:
                break;
        }
    }


}
