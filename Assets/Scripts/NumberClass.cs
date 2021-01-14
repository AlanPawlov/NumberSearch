using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberClass : MonoBehaviour {
	public Transform _transform;
	public int number;
	public GameManager game_mngr;
	public Image btn_img;

	void Start () {
		_transform=transform;
		btn_img=_transform.GetComponent<Image>();
		number=int.Parse(_transform.name);
		game_mngr=GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

	}

	public void SetNumber(){
		if(game_mngr.CheckClickNumber(number)){
            if (btn_img!=null)
            {
                btn_img.color = Color.gray;
            }
        }
		else{
			btn_img.color=Color.red;
		}
	}
}
