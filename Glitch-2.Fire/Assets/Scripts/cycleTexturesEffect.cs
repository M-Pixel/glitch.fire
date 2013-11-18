using UnityEngine;
using System.Collections;

public class cycleTexturesEffect : MonoBehaviour {
	//use this script to animate textures. 

	//set these in the editor by dragging them from the Hierarchy pane
	public Texture2D[] textures;
	public AudioClip[] steps; 
	public float changeInterval = 1.0f;
	
	//an internal value used to remember state
	private int currentTextureIndex = 0;
	private int currentSoundIndex = 1; 
	
	bool go = true;
	
	
	// Use this for initialization
	void Start () {
		//yield WaitForSeconds(3.0f); 
		//Make sure the textures have been assigned. Unity will often give you a nice
		//clear error message if you've forgotten to assign a value to something in a
		//script, but in this case it just complains about dividing by zero (see below)
		/*if (textures.Length > 0) {
			//the arguments here are the function name, how long to wait before starting,
			//how long to wait between calls
			InvokeRepeating("CycleTextures", changeInterval, changeInterval);
		} else {
			Debug.LogWarning ("No textures specified for gameObject "+gameObject.name+"!");
		}
		if (textures.Length > 0) {
			//the arguments here are the function name, how long to wait before starting,
			//how long to wait between calls
			InvokeRepeating("CycleSounds", changeInterval, changeInterval);
		} else {
			Debug.LogWarning ("No sounds specified for gameObject "+gameObject.name+"!");
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(CycleTexture());
	
	}

	IEnumerator CycleTexture()
	{
		yield return new WaitForSeconds(3.0f); 
		currentTextureIndex = ++currentTextureIndex % textures.Length;
		guiTexture.texture = textures[currentTextureIndex];
		yield return new WaitForSeconds(3.0f); 
	}
	/*
	void CycleTextures () {
		//this is where the division by zero happens. The % is the modulo
		//operator, which means "divide by this and get the remainder".
		//If there's nothing in the textures list, its length will be zero,
		//which causes the error.
		
		//These lines cause the object to show a series of textures (the ones
		//you chose in the editor) in sequence, over and over. See the end of
		//the Player class for more detail.
	//	
		currentTextureIndex = ++currentTextureIndex % textures.Length;
		guiTexture.texture = textures[currentTextureIndex];
		
	}
	*/


}
