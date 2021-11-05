using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{

    public Button buyButton;
    public TextMeshProUGUI nameLabel;

    public TextMeshProUGUI priceText;
    public Image iconImage;
    public TextMeshProUGUI description;

    private Item item;
    private ShopScrollList scrollList;

    public GameObject stickMan;
    
    string buy = "Buy \n";
    
    

    void Start()
    {
       
        //scrollList.RefreshDisplay();
        //  buyButton.onClick.AddListener(HandleClick);



        //   newButton.onClick.AddListener(HandleClick);

       //  buyButton.onClick.AddListener(HandleClick);
    }
    public void Setup(Item currentItem, ShopScrollList currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        stickMan = item.gameObject;
        iconImage.sprite = item.icon;
        priceText.text = buy + item.price.ToString();
        scrollList = currentScrollList;
        description.text = item.description;

    }
    public void HandleClick()
    {
        scrollList.TryTransferItemToOtherShop(item);
    }

}
