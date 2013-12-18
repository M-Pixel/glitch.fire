using UnityEngine;
using System.Collections;

public class gameOverManager : MonoBehaviour {
	public GUIStyle myGuiStyle;
	private bool suspend;
	public string levelToLoad; 
	// Use this for initialization
	void Start () {
		StartCoroutine(returnToStart());
		myGuiStyle.normal.textColor = new Color (1, 0.5f, 0);
		myGuiStyle.alignment = TextAnchor.MiddleCenter;
		myGuiStyle.fontSize = 30;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetAxisRaw("Jump") == 1 && suspend == false) {
			string levelName;
			int level = GameObject.Find("GlobalVars").GetComponent<GlobalVars>().level;
			if (level == 1) {
				levelName = "Proto_1";
			} else {
				levelName = "Level" + level;
			}
			Application.LoadLevel(levelName);
			suspend = true;
		}
*/

		if(Input.GetKeyDown("space"))
		{
			Application.LoadLevel(levelToLoad); 
		}
	}

	void OnGUI() {
		GUI.Label (
			new Rect (
				Screen.width / 2 - 150,
				Screen.height * 0.65f - 150,
				300,
				300),
			"Press SPACE to retry",
			myGuiStyle
		);
	}

	IEnumerator returnToStart()
	{
		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel("titleScreen"); 
	}
}
