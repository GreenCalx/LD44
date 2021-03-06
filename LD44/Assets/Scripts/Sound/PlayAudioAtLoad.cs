﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioAtLoad : MonoBehaviour
{
    GameObject AM;
    public float FameMax = 2000;
    // Start is called before the first frame update
    void Start()
    {
        AM = GameObject.Find("Audio Manager");
        var AM_c = AM.GetComponent<AudioManager>();
        AM_c.Play("Crowd");
    }

    // Update is called once per frame
    void Update()
    {
        AM = GameObject.Find("Audio Manager");
        var AM_c = AM.GetComponent<AudioManager>();
        var Money = GameObject.Find("Player").GetComponent<FameStacker>().convertFameToMoney();
        var volume = 0.1 + ( Mathf.Clamp(Money / FameMax, 0, 1) ) * 0.2;
        AM_c.SetVolume("Crowd", (float)volume);
    }
}
