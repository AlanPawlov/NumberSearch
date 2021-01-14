using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// standart resolution = 800x480
/// all magic numbers calculated from this resolution
/// </summary>
public class UIScaler : MonoBehaviour
{
    public RectTransform timer_rect;
    public RectTransform pause_btn;
    public RectTransform timer_txt;
    public List<GridLayoutGroup> standart_grid;
    public GridLayoutGroup lvl_pref_grid;
    public GridLayoutGroup record_grid;
    public GridLayoutGroup total_result;
    public GridLayoutGroup number_panel_grid;
    public RectTransform drop_box_field;
    public RectTransform drop_box_element;
    public GridLayoutGroup toggle_grid;
    public RectTransform toggle_graph;
    public RectTransform toggle_checmark;
    public GridLayoutGroup warning_panel;// for privacy politic     
    

    void Start()
    {
        GameObject[] big_text = GameObject.FindGameObjectsWithTag("BigText");


        timer_rect.anchoredPosition = new Vector2(0f, Screen.height / (-12f));
        timer_rect.sizeDelta = new Vector2(Screen.width, Screen.height);
        float pause_btn_w = (Screen.height / 7.384615384615385f);
        pause_btn.sizeDelta =new Vector2 (pause_btn_w,pause_btn_w);
        pause_btn.anchoredPosition = new Vector2(0f, 0f);
        record_grid.cellSize = new Vector2(Screen.width / 4f, Screen.height / 8f);
        lvl_pref_grid.cellSize = new Vector2(Screen.width / 2f, Screen.height / 9.6f);
        lvl_pref_grid.padding.top = int.Parse((Screen.height / 4.8).ToString());
        total_result.cellSize = new Vector2(Screen.width / 3.2f, Screen.height / 9.6f);
        number_panel_grid.padding.top = int.Parse((Screen.height / 4.8).ToString());
        drop_box_element.sizeDelta = new Vector2(0f, Screen.height / 15);
        drop_box_field.sizeDelta = new Vector2(0f, Screen.height / 2);
        toggle_grid.cellSize = new Vector2(Screen.width/4f,Screen.height/9.6f);
        toggle_graph.sizeDelta = new Vector2(Screen.height / 9.6f, Screen.height / 9.6f);
        toggle_checmark.sizeDelta = new Vector2(Screen.height / 9.6f, Screen.height / 9.6f);
        warning_panel.padding.top =(int) (Screen.height / 9.6f);
        warning_panel.cellSize = new Vector2(Screen.width, Screen.height / 4.8f);
        warning_panel.spacing =new Vector2  (0,Screen.height / 24);
        for (int i = 0; i < standart_grid.Count; ++i)
        {
            standart_grid[i].padding.top = (Screen.height / 48);
            standart_grid[i].cellSize = new Vector2(Screen.width / 1.6f, Screen.height / 4.8f);
            standart_grid[i].spacing = new Vector2(0f, Screen.height / 48f);
        }

    }
}
