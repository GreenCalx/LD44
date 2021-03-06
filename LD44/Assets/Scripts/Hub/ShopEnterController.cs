﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnterController : MonoBehaviour
{
    public GameObject shopParentUIGO;

    private ShopBehaviour shop;
    private PlayerBehavior capturedPlayerBehavior;
    private bool playerInShop;

    // Start is called before the first frame update
    void Start()
    {
        if (!!shopParentUIGO)
            shop = shopParentUIGO.GetComponentInChildren<ShopBehaviour>();
        if (!!shop)
            shop.gameObject.SetActive(false);

        playerInShop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && playerInShop)
            exitShop();
    }


    public void playerOnShop(PlayerBehavior iPlayerBehavior)
    {
        if (Input.GetKey(KeyCode.Space) && !playerInShop)
        {
            playerInShop = true;

            if (Constants.DEBUG_ENABLED)
                print("ENTER SHOP");
            // ENTER SHOP
            if (!!shop)
                shop.gameObject.SetActive(true);

            if (!!iPlayerBehavior)
            {
                capturedPlayerBehavior = iPlayerBehavior;
                capturedPlayerBehavior.onPause = true;
            }

        }
    }

    public void exitShop()
    {
        if (playerInShop)
        {
            if (Constants.DEBUG_ENABLED)
                print("EXIT SHOP");

            if (!!shop)
                shop.gameObject.SetActive(false);

            playerInShop = false;
            if (!!capturedPlayerBehavior)
            {
                capturedPlayerBehavior.onPause = false;
                capturedPlayerBehavior = null;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerBehavior pb = collision.GetComponent<PlayerBehavior>();
        if (!!pb)
        {
            playerOnShop(pb);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerBehavior pb = collision.GetComponent<PlayerBehavior>();
        if (!!pb)
        {
            exitShop();
        }
    }
}
