using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnSelectIcon : MonoBehaviour
{
    public UnityEvent onTabSelected;
    public UnityEvent onTabDeselected;

    private void Update()
    {
        Select();
        Deselect();
    }

    public void Select()
    {
        if (onTabSelected != null)
        {
            onTabSelected.Invoke();
        }
    }
    public void Deselect()
    {
        if (onTabDeselected != null)
        {
            onTabDeselected.Invoke();
        }
    }

}
