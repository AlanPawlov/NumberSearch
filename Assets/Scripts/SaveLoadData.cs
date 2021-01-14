using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadData : MonoBehaviour
{
    public static void SaveData(string key, string text)
    {
        PlayerPrefs.SetString(key, text);
    }
    
    public static void SaveData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    static public string LoadData(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetString(key);
        }
        return null;
    }

    static public int LoadDataInt(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        return 0;
    }

}

