using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public int item_index;
    public Sprite itemInfoImage;

    public string item_name { get; set; }
    public int item_price { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        item_name   = Constants.items[item_index];
        item_price  = Constants.shopItems_Price[item_name];
        string  item_price_str = "" + item_price;
        
        // SHOP ITEM
        Text[] texts = GetComponentsInChildren<Text>();
        foreach (Text t in texts)
        {
            if (t.name == Constants.shopitem_name)
                t.text = item_name;
            else if (t.name == Constants.shopitem_price)
                t.text = item_price_str;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buy()
    {
        Destroy(gameObject);
    }
}
