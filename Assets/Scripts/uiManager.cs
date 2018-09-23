using UnityEngine;
using System.Collections;

public class uiManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Single(){
		Application.LoadLevel ("LevelSelectScene1P");
	}
	public void Multiplayer(){
		Application.LoadLevel ("LevelSelectScene2P");
	}
	public void Tutorial(){
		Application.LoadLevel ("TutorialScene");
	}
	public void Exit(){
		Application.LoadLevel ("MainMenuScene");
	}

}
