using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FameBar : MonoBehaviour
{
    private GameObject Player;
    private Slider Slider;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        var Fame = Player.GetComponent<FameStacker>();
        Slider.value = Fame.convertFameToMoney();
    }
}
