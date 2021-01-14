using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FontScaler : MonoBehaviour
{
    public enum TextSize
    {
        small,
        middle,
        big,
        for_numbers
    }
    public TextSize my_text_size;
    void Start()
    {
        Text my_text = gameObject.GetComponent<Text>();
        if (my_text_size == TextSize.big)
        {
            my_text.fontSize =  (int)Screen.height/10;
        }
        if (my_text_size == TextSize.middle)
        {
            my_text.fontSize = (int)Screen.height / 19;
        }
        if (my_text_size == TextSize.small)
        {
            my_text.fontSize = (int)Screen.height / 26;
        }
        if (my_text_size == TextSize.for_numbers)
        {
            my_text.fontSize = (int)Screen.height / 12;
        }
    }
}
