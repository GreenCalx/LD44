using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScrollingAnimation : MonoBehaviour
{
    public List<string> DisplayedTexts;
    private RectTransform _RT;
    private TextMeshProUGUI _TM;
    public float ScrollSpeed = 10;
    public float InBetweenTime = 5;
    private float _CurrentTime = 1;
    private int _CurrentIdx = 0;
    private Vector2 _StartingPosition;
    private float TotalWidth =0;
    // Start is called before the first frame update
    void Start()
    {
        _RT = GetComponent<RectTransform>();
        _TM = GetComponent<TextMeshProUGUI>();
        _StartingPosition = _RT.position;
    }

    // Update is called once per frame
    void Update()
    {
       // RT.position = new Vector2(RT.position.x + ScrollSpeed * Time.fixedDeltaTime, RT.position.y);
    }

    void FixedUpdate()
    {
        if (_CurrentTime <= 0)
        {
            ++_CurrentIdx;
            if (_CurrentIdx >= DisplayedTexts.Capacity) _CurrentIdx = 0;
            _TM.text = DisplayedTexts[++_CurrentIdx];
            _RT.position = new Vector2(_RT.position.x + TotalWidth, _RT.position.y);
            _CurrentTime = InBetweenTime;
            TotalWidth = 0;
        }
        _CurrentTime -= Time.deltaTime;
        TotalWidth += ScrollSpeed * Time.fixedDeltaTime;
        _RT.position = new Vector2(_RT.position.x - ScrollSpeed * Time.fixedDeltaTime, _RT.position.y);
    }
}
