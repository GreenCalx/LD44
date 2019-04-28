using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBehaviour : MonoBehaviour
{
    int index;
    public ShopItem selectedItem;
    public ShopItem[] items;

    private float waitTime = 0.15f;
    private float timer;
    private bool selectorReady;

    // Start is called before the first frame update
    void Start()
    {
        items = GetComponentsInChildren<ShopItem>();
        index = 0;
        selectedItem = (items.Length > 0) ?
                        items[0] : null;
        if (!!selectedItem)
        {
            Image button = selectedItem.gameObject.GetComponent<Image>();
            if (!!button)
                button.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ----------------------------------------------------
        // TIMER 
        timer += Time.deltaTime;
        if ( (timer >= waitTime)&& !selectorReady)
        { selectorReady = true; timer = 0f; }
        else { selectorReady = false; }

        if (selectorReady)
        {
            // ----------------------------------------------------
            // SELECT ITEM
            items = GetComponentsInChildren<ShopItem>();
            if (items.Length > 0)
            {
                bool upPressed = (Input.GetAxis(PlayerInputs._Key_vertical) < 0f);
                bool downPressed = (Input.GetAxis(PlayerInputs._Key_vertical) > 0f);

                if (upPressed)
                    index = (index >= items.Length) ? 0 : (index + 1);
                else if (downPressed)
                    index = (index <= 0) ? (items.Length - 1) : (index - 1);

                if (upPressed || downPressed)

                {
                    // old item
                    selectorReady = false;
                    if (!!selectedItem)
                    {
                        Image button1 = selectedItem.gameObject.GetComponent<Image>();
                        if (!!button1)
                            button1.color = Color.white;
                    }

                    // new item
                    try
                    {
                        selectedItem = ((index >= 0) && (items.Length > index)) ?
                                        items[index] : items[0];
                        Image button2 = selectedItem.gameObject.GetComponent<Image>();
                        if (!!button2)
                            button2.color = Color.red;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        print(" SELECTED ITEM OUF OF RANGE : " + index);
                    }

                }

                // ----------------------------------------------------
                // UDPDATE INFO
                if (!!selectedItem)
                {
                    string item_name = selectedItem.item_name;

                    //INFO TEXT
                    Text[] infotexts = GetComponentsInChildren<Text>();
                    foreach (Text t in infotexts)
                    {
                        if (t.name == Constants.shopitem_infotext)
                            t.text = Constants.shopItems_InfoText[item_name];
                    }

                    // INFO IMAGE
                    /*
                    GameObject infoimagetGO = GameObject.FindGameObjectWithTag(Constants.shopitem_infoimage);
                    if (!!infoimagetGO)
                    {
                        Image infoimage = infoimagetGO.GetComponent<Image>();
                        Sprite s = Sprite.Create()
                        if (!!infoimage)
                            infoimage.sprite = Constants.shopItems_InfoImage[item_name];
                    }
                    */
                }// !updateinfo
                 // ----------------------------------------------------
            }
            // ----------------------------------------------------
            // BUY
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject player = GameObject.Find("Player");
                if (!!player)
                {
                    PlayerBehavior pb = player.GetComponent<PlayerBehavior>();
                    if (!!pb)
                    {
                        int money = pb.getBankAccount();
                        int price = selectedItem.item_price;
                        if (money >= price)
                        {
                            pb.spendMoney(price);
                            selectedItem.buy();

                            items = GetComponentsInChildren<ShopItem>();
                            if (items.Length > 0)
                            {
                                index = 0;
                                selectedItem = items[index];
                            }

                        }
                    }

                }
            }

        }//! selectorReady
    }//!update
}
