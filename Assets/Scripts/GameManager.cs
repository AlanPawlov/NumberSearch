using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    public int cur_number;
    public Text timer_text;
    public bool ready_now = false;
    public float sec_for_gt = 1;
    public int timer_sec = 0;
    public int timer_min = 0;
    public int error_count = 0;
    public int width_row_number = 3;
    public NumberGenerator nmb_gen;
    public Text row_count_text;
    public Text total_time_text;
    public Text total_errors;
    public Transform numbers_panel;
    public UnityEvent HitEvent;
    public Text[] record_text = new Text[5];
    public int[] record_int = new int[5];
    public int round_count;
    public int agree_privacy_polit = 0;
    public bool pause;
    public RomanSystemConverter converter;
    public bool roman_system_mode;
    public GameObject privacy_polit_panel;

    // 0-english, 1-russian, 2-deutsch,
    // 3-francias, 4-chines, 5-indian, 6-japan
    public int cur_language = 0;
    public void ShowRecord()
    {
        record_text[0].text = SaveLoadData.LoadData("3x3");
        record_text[1].text = SaveLoadData.LoadData("4x4");
        record_text[2].text = SaveLoadData.LoadData("5x5");
        record_text[3].text = SaveLoadData.LoadData("6x6");
        record_text[4].text = SaveLoadData.LoadData("round_counter");
    }
    public void PrivacyAgree(int agree)
    {
        SaveLoadData.SaveData("agree_privacy_polit", agree);
        if (agree==0)
        {
            Application.Quit();
        }
    }
    void Start () {
    
		ready_now=false;
        timer_text.enabled=false;
        
        if (PlayerPrefs.HasKey("selected_language"))
        {
            cur_language = SaveLoadData.LoadDataInt("selected_language");
        }
        if (PlayerPrefs.HasKey("agree_privacy_polit")==false|| SaveLoadData.LoadDataInt("agree_privacy_polit")==0)
        {
            privacy_polit_panel.SetActive(true);
        }
        else
        {
            agree_privacy_polit = SaveLoadData.LoadDataInt("agree_privacy_polit");
            privacy_polit_panel.SetActive(false);
        }
        if (PlayerPrefs.HasKey("3x3"))
        {
            record_int[0] = int.Parse(SaveLoadData.LoadData("3x3"));
        }
        if (PlayerPrefs.HasKey("4x4"))
        {
            record_int[1] = (int)int.Parse(SaveLoadData.LoadData("4x4"));
        }
        if (PlayerPrefs.HasKey("5x5"))
        {
            record_int[2] = (int)int.Parse(SaveLoadData.LoadData("5x5"));
        }
        if (PlayerPrefs.HasKey("6x6"))
        {
            record_int[3] = (int)int.Parse(SaveLoadData.LoadData("6x6"));
        }
        if (PlayerPrefs.HasKey("round_counter"))
        {
            record_int[4] = (int)int.Parse(SaveLoadData.LoadData("round_counter"));
        }
    }

    public void InitGame(float row_count){
		Debug.Log(row_count);
		row_count_text.text=row_count.ToString();
		width_row_number=(int) row_count;
	}

	public void StartGame(){
        timer_min = 0;
        timer_sec = 0;
        error_count = 0;
        cur_number = 0;
        nmb_gen.GenerateField(width_row_number);
		ready_now=true;
        timer_text.enabled=true;
	}

    public void EndGame()
    {
		Debug.Log("EndGame");
		StopAllCoroutines();
		ready_now=false;
        total_errors.text = error_count.ToString();
        total_time_text.text = timer_text.text;
        timer_text.enabled = false;
        timer_min = 0;
        HitEvent.Invoke();
        if (!pause)
        {
            record_int[4]++;    
            SaveLoadData.SaveData("round_counter", record_int[4].ToString());
            switch (width_row_number)
            {
                case 3:
                    if (timer_sec < record_int[0])
                    {
                        record_int[0] = timer_sec;
                        SaveLoadData.SaveData("3x3", record_int[0].ToString());
                    }
                    break;
                case 4:
                    if (timer_sec < record_int[1])
                    {
                        record_int[1] = timer_sec;
                        SaveLoadData.SaveData("4x4", record_int[1].ToString());
                    }
                    break;
                case 5:
                    if (timer_sec < record_int[2])
                    {
                        record_int[2] = timer_sec;
                        SaveLoadData.SaveData("5x5", record_int[2].ToString());
                    }
                    break;
                case 6:
                    if (timer_sec < record_int[3])
                    {
                        record_int[3] = timer_sec;
                        SaveLoadData.SaveData("6x6", record_int[3].ToString());
                    }
                    break;
            }

        }
        else
        {
            pause = false;
        }

        for (int i = numbers_panel.childCount; i > 0; i--)
        {
            DestroyImmediate(numbers_panel.GetChild(0).gameObject);
        }
    }

    void Update () {
		if (ready_now && !pause){
			StartCoroutine(GameTimer());
		}
	}
	public IEnumerator GameTimer(){
		ready_now=false;
		timer_sec++;
		timer_text.text=timer_sec.ToString();
		yield return new WaitForSeconds(sec_for_gt);
		ready_now=true;
	}
    
	public bool CheckClickNumber(int click_number){
		if(click_number!=cur_number){
			Debug.Log("false number");
            timer_sec += 5;
            timer_text.text = timer_sec.ToString();
            error_count++;
            return (false);
		}
		else{
			Debug.Log("true number");
			cur_number+=1;
			if(cur_number>=(width_row_number*width_row_number)){

                EndGame();
			}
			return(true);
		}

	}
    public void RomanMode()
    {
        if (roman_system_mode == true)
        {
            roman_system_mode = false;
        }
        else
        {
            roman_system_mode = true;
        }
    }
    public void PauseGame()
    {
        pause = true;
    }
    public void ResumeGame()
    {
        pause = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
