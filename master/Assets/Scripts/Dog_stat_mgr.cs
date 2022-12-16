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

    int[] m_dog_stats;

    // Start is called before the first frame update
    void Start()
    {
        Reset_game();
    }

    public void Reset_game()
    {
        m_dog_stats = new int[(int)Dog_enum.Nums];
        m_story_map = new Dictionary<Dog_enum, Story>();

        foreach (var txt_asset in JSONStory_map.Data)
        {
            var story = new Story(txt_asset.Value.text);
            m_story_map.Add(From_string(txt_asset.Key), story);

            var dog_enum = From_string(txt_asset.Key);
            m_dog_stats[(int)dog_enum] = (int)story.variablesState["affinity"];
        }
    }

    public Story get_story(Dog_enum dog_enum)
    {
        var txt_asset = JSONStory_map.Data[dog_enum.ToString()];
        var story = new Story(txt_asset.text);

        return story;
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

    public void read_from_ink(Story story, Dog_enum dog_enum)
    {
        m_dog_stats[(int)dog_enum] = (int)story.variablesState["affinity"];
    }

    public void write_to_ink(Story story, Dog_enum dog_enum)
    {
        story.variablesState["affinity"] = m_dog_stats[(int)dog_enum];
    }

    public void debug_print()
    {
        string dbg_txt = "";

        for (int i = 0; i < (int)Dog_enum.Nums; ++i)
        {
            dbg_txt += ((Dog_enum)i).ToString() + ":" + m_dog_stats[i] + "\n";
        }
        Debug.Log(dbg_txt);
    }
}
