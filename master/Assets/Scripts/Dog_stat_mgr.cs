using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Image_table
{
    //================================================
    // Public Variable
    //================================================
    private Dictionary<string, Sprite> _data;
    public Dictionary<string, Sprite> Data
    {
        get {
            if (_data == null)
                _init_dataset();
            return _data;
        }
    }

    public string[] _name = new string[] { "Otis" };
    public Sprite[] _sprite;

    //================================================
    // Private Method
    //================================================
    private void _init_dataset()
    {
        _data = new Dictionary<string, Sprite>();

        if (_name.Length != _sprite.Length)
            Debug.LogError("Emotion and Sprite have different lengths");

        for (int i = 0; i < _name.Length; i++)
            _data.Add(_name[i], _sprite[i]);
    }
}

public class Dog_stat_mgr : MonoBehaviour
{
    public Image_table Dog_image_tbl;

    // global persistent variable
    private static Dog_stat_mgr persistence_obj;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (persistence_obj == null)
        {
            persistence_obj = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
