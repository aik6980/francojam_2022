using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_selection_mgr : MonoSingleton<Story_selection_mgr>
{
    public TextAsset m_curr_text_asset;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
