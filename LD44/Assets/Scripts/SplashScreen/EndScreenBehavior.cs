using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenBehavior : MonoBehaviour
{
    public List<string> DisplayedTexts;
    public List<string> EndingTexts;

    private TextMeshProUGUI _TM;
    private int _displayedTextsIndex = 0;
    private bool endingDisplayed = false;

    private void OnEnd()
    {
        // EXIT GAME OR LOOP TO TITLE
        SceneManager.LoadScene(Constants.title_scene_name, LoadSceneMode.Single);
    }

    private string getEndingText()
    {
        endingDisplayed = true;

        string s = ""; 
        // C'est sale mais c'est pour le rendu !
        if (EndingTexts.Count >= 3)
        {
            int death_count = PlayerPrefs.GetInt(Constants.death_count, 1);
            if (death_count <= 3)
            {
                s = EndingTexts[0];
            }
            else if (death_count <= 6)
            {
                s = EndingTexts[1];
            }
            else
            {
                s = EndingTexts[2];
            }
        }

        return s;
    }

    // Start is called before the first frame update
    void Start()
    {
        endingDisplayed = false;
        _TM = GetComponent<TextMeshProUGUI>();
        _TM.text = DisplayedTexts[_displayedTextsIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!endingDisplayed)
            {
                _displayedTextsIndex++;
                string message = (_displayedTextsIndex >= DisplayedTexts.Capacity) ?
                    getEndingText() : DisplayedTexts[_displayedTextsIndex];
                _TM.text = message;
            }
            else
            {
                OnEnd();
            }

        }
    }
}
