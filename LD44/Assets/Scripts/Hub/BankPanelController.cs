using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BankPanelController : MonoBehaviour
{
    public GameObject player;
    public int bankAccount;
    
    // Start is called before the first frame update
    void Start()
    {
        updatePanel();
    }

    // Update is called once per frame
    void Update()
    {
        updatePanel();
    }

    void updatePanel()
    {
        if (!!player)
        {
            PlayerBehavior pb = player.GetComponent<PlayerBehavior>();
            bankAccount = (!!pb) ? pb.getBankAccount() : 0;
            string bankAccount_str = "" + bankAccount;
            TextMeshProUGUI t = GetComponentInChildren<TextMeshProUGUI>();
            if (!!t)
                t.text = bankAccount_str;
        }
    }
}
