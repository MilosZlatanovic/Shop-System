using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Shop System/Items/Default")]
public class DefaultButton_SO : Item
{
    public void Awake()
    {
        type = ButtonType.Default;
    }
}
