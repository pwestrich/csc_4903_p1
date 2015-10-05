using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float fireDelay;
	public float fireDistance;

	private float fireCooldown = 0.0f;

	// Use this for initialization
	void Start(){
	
	}
	
	void FixedUpdate(){

		float fire = Input.GetAxis("Fire1");

		if (fire > 0.0f && fireCooldown <= 0.0f) {

			this.fire();
			fireCooldown = fireDelay;

		} else if (fireCooldown > 0.0f) {

			fireCooldown -= Time.deltaTime;

		}
	
	}

	void OnTriggerEnter(Collider other){

		if (other.CompareTag("Death")) {

			//kill the player
			GameController.controller.die();

		}

	}

	private void fire(){

		//animate gun

		//do raycast
		int middleX = Camera.main.pixelWidth / 2;
		int middleY = Camera.main.pixelHeight / 2;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(middleX, middleY, 0));
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, fireDistance)) {

			GameObject obj = hit.collider.gameObject;

			Debug.Log("Hit something: " + obj);

		}

	}
}

