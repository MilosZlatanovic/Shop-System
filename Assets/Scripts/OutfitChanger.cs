using System.Collections.Generic;
using UnityEngine;

public class OutfitChanger : MonoBehaviour
{
    [Header("Sprite To Change")]
    public SpriteRenderer hemlet;
    public SpriteRenderer castle;

     [Header("Strite To Choose")]
     public List<Sprite> options = new List<Sprite>();

     private int currentOption = 0;

     public void NextOption()
     {

         currentOption++;
         if (currentOption >= options.Count)
         {
             currentOption = 0;
         }

         hemlet.sprite = options[currentOption];

     }

     public void PreviousOption()
     {
         currentOption--;
         if (currentOption < 0)
         {
             currentOption = options.Count - 1;
         }

         hemlet.sprite = options[currentOption];

     }
}
