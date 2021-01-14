using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Localizator : MonoBehaviour
{
    public GameManager game_mngr;
    public enum Language
    {
        english,
        russian,
        deutsch,
        francias,
        chines,
        indian,
        japan
    }
    public Language selected_language;
    public int cur_language;
    public Text cur_text;
    public string[] list_text;//english, russian, deutsch, francias, chines, indian, japan
    void Start()
    {
        game_mngr = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (PlayerPrefs.HasKey("selected_language"))
        {
            cur_language = SaveLoadData.LoadDataInt("selected_language");
            cur_text.text = list_text[cur_language];
        }
    }

    public void SelectLanguage(Dropdown sel_lang)
    {
        cur_language = sel_lang.value;
        Debug.Log(cur_language);
        cur_text.text = list_text[cur_language];
        SaveLoadData.SaveData("selected_language", cur_language);
    }
    
    public void SelectLanguage(int selected_language)
    {
        cur_text.text = list_text[selected_language];
    }
}
