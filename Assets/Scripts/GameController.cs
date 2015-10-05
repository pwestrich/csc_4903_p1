using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController controller;

	public PlayerController player;

	public int lives;
	public int health;
	public int ammo;
	
	// Use this for initialization
	void Awake(){

		if (controller == null) {

			controller = this;
			DontDestroyOnLoad(gameObject);
			OnLevelWasLoaded(0);

		} else {

			Destroy(gameObject);

		}
	
	}

	void OnLevelWasLoaded(int level){

		health = 100;

	}
	
	// Update is called once per frame
	void Update(){
	
	}

	public void die(){

		lives--;

		if (lives == 0) {

			//print "YouLose" or something

		} else {

			//reload the level
			Application.LoadLevel(Application.loadedLevel);

		}

	}
}
