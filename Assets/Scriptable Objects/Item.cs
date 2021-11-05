using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    Weapons,
    Armor,
    Castles,
    Protection,
    Eqipment,
    Treasures,
    Default
}

[System.Serializable]
public abstract class Item : ScriptableObject
{
    public GameObject gameObject;
    public string itemName;
    public Sprite icon;
    public float price = 1;
    public ButtonType type;
    [TextArea(5, 10)]
    public string description;
   
}
