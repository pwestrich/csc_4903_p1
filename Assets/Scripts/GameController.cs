using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController controller;

	public PlayerController player;

	public int lives;
	public int health;
	public int maxAmmo;
	public int currentAmmo;

	public float fireDistance;

	public Text livesText;
	public Text ammoText;
	public Text healthText;

	private int _currentClip;


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

		livesText.text = "Lives: " + lives;
		ammoText.text = "Ammo: " + currentAmmo;
		healthText.text = "Health: " + health;
	
	}

	public void fire(){
	
		//check and decrement ammo
		if (currentAmmo == 0) {

			return;

		}

		--currentAmmo;

		//see if we hit anything
		int middleX = Camera.main.pixelWidth / 2;
		int middleY = Camera.main.pixelHeight / 2;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(middleX, middleY, 0));
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, fireDistance)) {
			
			GameObject obj = hit.collider.gameObject;
			
			Debug.Log("Hit something: " + obj);
			
		}
		
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
