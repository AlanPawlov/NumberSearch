using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberGenerator : MonoBehaviour {
	public GameManager game_mngr;
	public RectTransform button;
	public List<RectTransform> buttons_list;
	public GridLayoutGroup grid;
	public Vector2 cell_size;
	public float height_offset;
	public float width_offset;
    public RomanSystemConverter converter;

	void Start () {
        game_mngr = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        converter = game_mngr.converter;
    }

	public void GenerateField(int width_row){
		int total_element_count=width_row*width_row;
		if(Input.deviceOrientation==DeviceOrientation.LandscapeLeft||Input.deviceOrientation==DeviceOrientation.LandscapeRight){
			cell_size.x=Screen.width/(width_row*width_offset);
			cell_size.y=Screen.height/(width_row*height_offset);

		}
		else if(Input.deviceOrientation==DeviceOrientation.Portrait||Input.deviceOrientation==DeviceOrientation.PortraitUpsideDown){
			cell_size.x=Screen.width/(width_row*height_offset);
			cell_size.y=Screen.height/(width_row*width_offset);
		}
		else{
			cell_size.x=Screen.width/(width_row*width_offset);
			cell_size.y=Screen.height/(width_row*height_offset);
		}
		grid.constraintCount=width_row;
		grid.cellSize=cell_size;

		for(int i =0;i<total_element_count;i++){
			RectTransform inst_btn= Instantiate(button,Vector3.zero,Quaternion.identity);
			inst_btn.name=(i.ToString());
			buttons_list.Add(inst_btn);
			Text chld_txt= inst_btn.GetChild(0).GetComponent<Text>();
            if (game_mngr.roman_system_mode)
            {
                chld_txt.text = converter.ConvertToRomans(i.ToString());
            }
            else
            {
                chld_txt.text = i.ToString();
            }
        }
		while(buttons_list.Count>0){
			int random_element=Random.Range(0,buttons_list.Count);
			buttons_list[random_element].transform.SetParent(grid.transform);
			buttons_list.RemoveAt(random_element);
		}
	}
}
