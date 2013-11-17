﻿using UnityEngine;
using System.Collections;

public class MenuObject : MonoBehaviour {

	public bool isQuit = false;
	public bool isCredits = false;
	// Use this for initialization


	void OnMouseEnter() 
	{
		renderer.material.color = Color.red; 
	}

	void OnMouseExit()
	{
		renderer.material.color = Color.white; 
	}

	void OnMouseDown()
	{
		if(isQuit){
			Application.Quit(); 
		}
		else if(isCredits)
		{
			//do the credits 
		}
		else
		{
			Application.LoadLevel("Proto_1");
		}
	}
}	