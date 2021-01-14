using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class AdsViewer : MonoBehaviour
{
    public string app_id = "";//ID app in unity ads
    public string gen_banner_id = "";//banner id 
    public string interstitial_ad= "";//interstitial id 
    public bool test_mode;
    public int cur_round_counter;
    public int max_round_counter;//when show ads
 
void Start()
    {
        Advertisement.Initialize(app_id, test_mode);
        
        StartCoroutine(ShowBanner());
    }

    IEnumerator ShowBanner()
    {
        while(!Advertisement.IsReady(gen_banner_id))
        {
            yield return new WaitForSeconds(0.5f);
        }    
        Advertisement.Banner.Show(gen_banner_id);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public void AddRound(int round)
    {
        cur_round_counter += round;
        
        if (cur_round_counter >= max_round_counter)
        {
            ShowInterstitialAD();
        }
    }

    public void ShowInterstitialAD()
    {
        Advertisement.Show(interstitial_ad);
        cur_round_counter = 0;
        Debug.Log("ShowInterstitialAD");
    }
}
