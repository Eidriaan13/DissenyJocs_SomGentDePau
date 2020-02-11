using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopController : MonoBehaviour
{
    
    public Text itemName;
    public Image itemImage;
    public Text dany;
    public Text alcance;
    public Text cost;
    public Text pes;

    public Item_Weapon pedra;
    public Item_Weapon adoqui;
    public Item_Weapon ampolla;
    public Item_Weapon molotov;

    public Inventory.ItemType selectedItem = Inventory.ItemType.Pedra;
    public Item_Weapon selectedItem_2;

    public Inventory inventoryController;

    public int actualMoney;
    public Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        itemName.text = pedra.displayName;
        itemImage.sprite = pedra.displayImage;
        dany.text = "Dany: " + pedra.dany.ToString();
        alcance.text = "Alcance: " + pedra.alcance.ToString();
        cost.text = "Cost: " + pedra.cost.ToString();
        pes.text = "Pes: " + pedra.pes.ToString();

        selectedItem = Inventory.ItemType.Pedra;
        selectedItem_2 = pedra;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = actualMoney.ToString();
    }

    public void ClickItem(string item)
    {
        switch (item)
        {
            case "pedra":
                itemName.text = pedra.displayName;
                itemImage.sprite = pedra.displayImage;
                dany.text = "Dany: " + pedra.dany.ToString();
                alcance.text = "Alcance: " + pedra.alcance.ToString();
                cost.text = "Cost: " + pedra.cost.ToString();
                pes.text = "Pes: " + pedra.pes.ToString();

                selectedItem = Inventory.ItemType.Pedra;
                selectedItem_2 = pedra;

                break;

            case "adoqui":
                itemName.text = adoqui.displayName;
                itemImage.sprite = adoqui.displayImage;
                dany.text = "Dany: " + adoqui.dany.ToString();
                alcance.text = "Alcance: " + adoqui.alcance.ToString();
                cost.text = "Cost: " + adoqui.cost.ToString();
                pes.text = "Pes: " + adoqui.pes.ToString();

                selectedItem = Inventory.ItemType.Adoqui;
                selectedItem_2 = adoqui;

                break;

            case "ampolla":
                itemName.text = ampolla.displayName;
                itemImage.sprite = ampolla.displayImage;
                dany.text = "Dany: " + ampolla.dany.ToString();
                alcance.text = "Alcance: " + ampolla.alcance.ToString();
                cost.text = "Cost: " + ampolla.cost.ToString();
                pes.text = "Pes: " + ampolla.pes.ToString();

                selectedItem = Inventory.ItemType.Ampolla;
                selectedItem_2 = ampolla;

                break;

            case "molotov":
                itemName.text = molotov.displayName;
                itemImage.sprite = molotov.displayImage;
                dany.text = "Dany: " + molotov.dany.ToString();
                alcance.text = "Alcance: " + molotov.alcance.ToString();
                cost.text = "Cost: " + molotov.cost.ToString();
                pes.text = "Pes: " + molotov.pes.ToString();

                selectedItem = Inventory.ItemType.Molotov;
                selectedItem_2 = molotov;

                break;

            default:
                break;
        }
    }

    public void BuyItem()
    {
        if (actualMoney >= selectedItem_2.cost)
        {
            inventoryController.BuyItem(selectedItem);
            actualMoney -= selectedItem_2.cost;
        }
        
    }
}
