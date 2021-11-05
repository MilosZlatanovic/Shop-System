using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SwipeMenu : MonoBehaviour
{
    private const int HALFDISTANCE = 4;
    private const int DIVIDED_DISTANCE = 2;
    private float MIDPOINT = 0.1f;
    /// <summary>
    Scrollbar sBar;   ///  Caching Component Scrollbar;
    public GameObject scrollbar;
    /// </summary>
    private float scroll_pos = 0;
    float[] pos;
    /// <summary>
    Transform itemTransform;  /// Caching Component Transform
                              /// </summary>

                              /// <summary>                           
    Vector2 scaleZoom; /// Caching Vector2
    Vector2 scaleNormal;
    /// </summary>
    public Color colorActive, colorInactive;

    float[] itemPos;
    float[] itemChild;

    Color img;

    public Button buttonPrefab;
    TextMeshProUGUI costText;

    OutfitChanger outfitChangerScript;


    private void Start()
    {
        // Instantiate(buttonPrefab.transform, transform.parent);
        /*  costText = buttonPrefab.GetComponentInChildren<TextMeshProUGUI>();
          if (costText == null)
          {
              Debug.Log("costText is null");
          }*/
        //   costText.text = item.price.ToString();

        outfitChangerScript = GetComponent<OutfitChanger>();
        if (outfitChangerScript == null)
        {
            Debug.Log("Outfit Changer Script Is: Null");
        }

        sBar = scrollbar.GetComponent<Scrollbar>();
        itemTransform = GetComponent<Transform>();
        scaleZoom = new Vector2(1f, 1f);
        scaleNormal = new Vector2(0.7f, 0.7f);

    }


    void Update()
    {
        float distance = SetDistance();
        scroll_pos = Mathf.Clamp01(sBar.value);

        if (Input.GetMouseButton(0))
        {
            scroll_pos = Mathf.Clamp01(sBar.value);
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / DIVIDED_DISTANCE) && scroll_pos > pos[i] - (distance / DIVIDED_DISTANCE))
                {
                    sBar.value = Mathf.Lerp(sBar.value, pos[i], 0.1f);
                }
            }
        }
        ZoomIn(distance);
    }

    private void ZoomIn(float distance)
    {
        for (int i = 0; i < pos.Length; i++)
        {

            if (scroll_pos < pos[i] + (distance / HALFDISTANCE) && scroll_pos > pos[i] - (distance / HALFDISTANCE))
            {
                //  Debug.LogWarning("Current Selected Level" + i);


                itemTransform.GetChild(i).localScale = Vector2.Lerp(itemTransform.GetChild(i).localScale, scaleZoom, MIDPOINT);
                //   StartZoom(i);
                SetupActiveItems(i, true, colorActive);
               
             //   outfitChangerScript.hemlet.sprite = itemTransform.GetChild(i).gameObject.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().sprite;
                outfitChangerScript.castle.sprite = itemTransform.GetChild(i).gameObject.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().sprite;

                // outfitChangerScript.hemlet =





                /*itemTransform.GetChild(i).gameObject.transform.GetChild(4).gameObject.GetComponent<Image>().color = img;*/

                CanvasGroup gfgggg = itemTransform.GetChild(i).gameObject.transform.GetChild(5).gameObject.GetComponent<CanvasGroup>();
                gfgggg.alpha = 1f;
                CanvasGroup f = itemTransform.GetChild(i).gameObject.transform.GetChild(4).gameObject.GetComponent<CanvasGroup>();
                f.alpha = 1f;
                /* TextMeshPro gg11 = itemTransform.GetChild(i).gameObject.transform.GetChild(4).gameObject.GetComponentInChildren<TextMeshPro>();*/

                //dsds.GetComponentInChildren<Image>().color = img;
                //         Debug.Log(pos.Length.ToString() + " " + " " + i);

                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        itemTransform.GetChild(j).localScale = Vector2.Lerp(itemTransform.GetChild(j).localScale, scaleNormal, MIDPOINT);

                        //   itemTransform.GetChild(j).gameObject.transform.GetChild(4).gameObject.GetComponent<Image>().color = img;

                        //  EndZoom(j);
                        CanvasGroup gfgg = itemTransform.GetChild(j).gameObject.transform.GetChild(5).gameObject.GetComponent<CanvasGroup>();
                        //  gfgg.alpha = 0f;
                        CanvasGroup g = itemTransform.GetChild(j).gameObject.transform.GetChild(4).gameObject.GetComponent<CanvasGroup>();
                        //  g.alpha = 0;
                        SetupActiveItems(j, false, colorInactive);
                        // g.LeanAlpha(1f, 2f);
                    }
                }
            }
        }
    }

    private float SetDistance()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);


        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        return distance;
    }

    public enum ItemComponents
    {
        NameText = 0,
        IconImg = 1,
        DescriptionBtn = 2,
        UpgradeBarImg = 3,
        BuyBtn = 4,
        PriceText = 5,
        EquipBnt = 6,
        UpgradeBtn = 7




    }
    public ItemComponents itemComponents;
    bool _isActive;

    public void SetupActiveItems(int _w, bool _isTrue, Color _color)
    {
        itemPos = new float[itemTransform.childCount];

        for (int x = 0; x < itemPos.Length; x++)
        {
            itemChild = new float[itemTransform.GetChild(x).gameObject.transform.childCount];
            // itemPos[i] = gameObject.transform.GetChild(0);
            for (int s = 0; s < itemChild.Length; s++)
            {

                if (s == 6 || s == 7)
                {

                }
                else if (s == 1)
                {

                }

                else
                {
                    GameObject itemsChildren = itemTransform.GetChild(_w).gameObject.transform.GetChild(s).gameObject;
                    itemsChildren.SetActive(_isTrue);


                    /*       CanvasGroup gfgg = itemTransform.GetChild(x).gameObject.GetComponent<CanvasGroup>();
                           gfgg.alpha = AnimationCurve;*/
                }
            }
            itemTransform.GetChild(_w).gameObject.GetComponent<Image>().color = _color;
        }
    }

    public void StartZoom(int i)
    {
        LeanTween.scale(itemTransform.GetChild(i).gameObject, scaleZoom, 0.3f).setEaseInOutSine();
    }
    public void EndZoom(int j)
    {
        //  LeanTween.scale(itemTransform.GetChild(j).gameObject, scaleNormal, 0.5f);
        itemTransform.GetChild(j).LeanScale(scaleNormal, 0.3f);
    }
}


