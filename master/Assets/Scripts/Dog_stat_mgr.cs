using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Name_data_map<T>
{
    //================================================
    // Public Variable
    //================================================
    private Dictionary<string, T> _data;
    public Dictionary<string, T> Data
    {
        get {
            if (_data == null)
                _init_dataset();
            return _data;
        }
    }

    public string[] _name = new string[] { "Otis" };
    public T[] _sprite;

    //================================================
    // Private Method
    //================================================
    private void _init_dataset()
    {
        _data = new Dictionary<string, T>();

        if (_name.Length != _sprite.Length)
            Debug.LogError("Emotion and Sprite have different lengths");

        for (int i = 0; i < _name.Length; i++)
            _data.Add(_name[i], _sprite[i]);
    }
}

public enum Dog_enum
{
    Otis,
    Pablo,
    Rusty,
    Betsy,
    Cesar,
    Freya,
    Nums
}

public class Dog_stat_mgr : MonoSingleton<Dog_stat_mgr>
{
    public Name_data_map<Sprite> Image_map;
    public Name_data_map<TextAsset> JSONStory_map;

    Dictionary<Dog_enum, Story> m_story_map;
    public Dictionary<Dog_enum, Story> Story_map
    {
        get => m_story_map;
    }

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

        m_story_map = new Dictionary<Dog_enum, Story>();

        foreach (var txt_asset in JSONStory_map.Data)
        {
            var story = new Story(txt_asset.Value.text);
            m_story_map.Add(From_string(txt_asset.Key), story);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public Dog_enum From_string(string name)
    {
        Dog_enum doggo_enum;
        Enum.TryParse(name, out doggo_enum);

        return doggo_enum;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
