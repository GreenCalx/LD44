using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathAltarController : MonoBehaviour
{
    public GameObject player;
    public int deathCount;

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
            deathCount = (!!pb) ? pb.getDeathCount() : 0;
            string deathCount_str = "" + deathCount;
            TextMeshProUGUI t = GetComponentInChildren<TextMeshProUGUI>();
            if (!!t)
                t.text = deathCount_str;
        }
    }
}
