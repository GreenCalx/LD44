using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // INIT GAME STATS
        PlayerPrefs.SetInt(Constants.bank_account, Constants.STARTING_MONEY);
        PlayerPrefs.SetInt(Constants.bank_account, 0);
        foreach (string key in Constants.unlocked_items.Keys)
        {
            PlayerPrefs.SetInt(key, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
       bool spacePressed = Input.GetKey(KeyCode.Space);
        if (spacePressed)
            SceneManager.LoadScene(Constants.splash_screen_name, LoadSceneMode.Single);


    }


}
