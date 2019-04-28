using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SplashScreenBehavior : MonoBehaviour
{
    public List<string> DisplayedTexts;
    private TextMeshProUGUI _TM;
    private int _CurrentIdx = 0;

    private void OnEnd()
    {
        //load scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        _TM = GetComponent<TextMeshProUGUI>();
        _TM.text = DisplayedTexts[_CurrentIdx];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            ++_CurrentIdx;
            if (_CurrentIdx >= DisplayedTexts.Capacity) OnEnd();
            _TM.text = DisplayedTexts[_CurrentIdx];
        }
    }
}
