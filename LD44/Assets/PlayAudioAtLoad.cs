using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioAtLoad : MonoBehaviour
{
    GameObject AM;
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

    }
}
