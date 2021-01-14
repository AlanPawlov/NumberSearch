using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BigCrutchLang : MonoBehaviour
{
    public Dropdown language_selector;
    public GameManager game_mngr;
    // Start is called before the first frame update
    void Start()
    {
        language_selector.value = game_mngr.cur_language;
    }
}
