using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter_HubToArena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehavior pb = collision.GetComponent<PlayerBehavior>();
        if (!!pb)
            SceneManager.LoadScene(Constants.arena_scene_name, LoadSceneMode.Additive);
    }
}
