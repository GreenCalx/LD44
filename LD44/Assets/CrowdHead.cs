using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowdHead : MonoBehaviour
{
    GameObject FameBar;
    // Start is called before the first frame update
    void Start()
    {
        FameBar = GameObject.Find("FameBar");
    }

    // Update is called once per frame
    void Update()
    {
        var Slider = FameBar.GetComponent<Slider>();
        RectTransform RT = GetComponent<RectTransform>();
        RT.position = Slider.handleRect.position;
    }
}
