using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnterController : MonoBehaviour
{
    public GameObject shopParentUIGO;
    private ShopBehaviour shop;

    // Start is called before the first frame update
    void Start()
    {
        if (!!shopParentUIGO)
            shop = shopParentUIGO.GetComponentInChildren<ShopBehaviour>();
        exitShop();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void playerOnShop()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("ENTER SHOP");
            // ENTER SHOP
            if (!!shop)
                shop.gameObject.SetActive(true);
        }
    }

    public void exitShop()
    {
        if (!!shop)
            shop.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehavior pb = collision.GetComponent<PlayerBehavior>();
        if (!!pb)
        {
            playerOnShop();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerBehavior pb = collision.GetComponent<PlayerBehavior>();
        if (!!pb)
        {
            playerOnShop();
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
