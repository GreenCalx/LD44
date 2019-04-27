using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_ScaleToScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        float h = Screen.height;
        float w = Screen.width;

        RectTransform imageRect         = gameObject.GetComponent<RectTransform>();
        imageRect.sizeDelta = new Vector2(w, h);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
