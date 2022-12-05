using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_preload_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Scene_UI_TitleScreen");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
