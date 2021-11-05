using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public Image menuPanel, weaponPanel;
    public List<Image> images;
   // public GameObject dublleImg;
    int index;

   

    public void ShopActive() => menuPanel.gameObject.SetActive(true);
    public void WaponActive()
    {
        menuPanel.gameObject.SetActive(false);
        weaponPanel.gameObject.SetActive(true);
    }
    public void ArmoryActive()
    {

        /* index = dublleImg.transform.GetSiblingIndex();

         for (int i = 0; i < images.Count; i++)
         {
             if (i == index)
             {
                 index++;
                 images[i].rectTransform.sizeDelta = new Vector2(600f, 600f);

                 // return;
             }
             else
             {

             }

         }
         Debug.Log(index);*/
    }
}
