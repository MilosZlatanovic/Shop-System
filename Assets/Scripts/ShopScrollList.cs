using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScrollList : MonoBehaviour
{
    public List<Item> itemList;
    public Transform contentPanel;
    public ShopScrollList otherShop;
    public TextMeshProUGUI myGoldDisplay;

    public float gold;
    public SimpleObjectPool buttonObjectPool;
    Color _color;
    SwipeMenu swipeMenu;
   
    SampleButton sampleButton1;
 
   
    private void Start()
    {

        /* if (buttonPrefab == null)
         {*/
    //    Instantiate(buttonPrefab, transform.parent);
       // Instantiate(priceText, transform.parent);

      //  priceText.text = item1.price.ToString();

        // }

        // sampleButton1 = GetComponent<SampleButton>();
        /*  buttonScript = GameObject.FindWithTag("Button").GetComponent<ButtonScript>();
         if (buttonScript == null)
         {
             Debug.LogError("swipeMenu is Null");
         }*/

        //  buttonScript.button.onClick.AddListener(sampleButton1.HandleClick);

        swipeMenu = GetComponent<SwipeMenu>();
        if (swipeMenu == null)
        {
            Debug.LogError("SwipeMenu is: NULL");
        }
        _color = swipeMenu.colorInactive;
      
        RefreshDisplay();
      
    }
    public void RefreshDisplay()
    {

        myGoldDisplay.text = "Gold: " + gold.ToString();
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;

         //  swipeMenu.SetupActiveItems(0, false, _color);
            //  Debug.Log("DDDDDDDD");
            buttonObjectPool.ReturnObject(toRemove);
        }
    }
    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            float newZ = 0f;
            newButton.transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
            newButton.transform.SetParent(contentPanel, false);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
           
            sampleButton.Setup(item, this);
        }
    }
    public void TryTransferItemToOtherShop(Item item)
    {
        if (otherShop.gold >= item.price)
        {
            gold += item.price;
            otherShop.gold -= item.price;

            AddItem(item, otherShop);
            RemoveItem(item, this);

            RefreshDisplay();
            otherShop.RefreshDisplay();

        }
        else
        {

            Debug.Log("NO Gold");
        }
    }
    void AddItem(Item itemToAdd, ShopScrollList shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Item itemToRemove, ShopScrollList shopList)
    {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--)
        {
            if (shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
            }
        }
    }
}