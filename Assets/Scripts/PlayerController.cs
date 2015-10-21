using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float fireDelay;
	public float actionDistance;
	
	private float fireCooldown = 0.0f;

	// Use this for initialization
	void Start(){
	
	}
	
	void FixedUpdate(){

		float fire = Input.GetAxis("Fire1");

		if (fire > 0.0f && fireCooldown <= 0.0f) {

			GameController.controller.fire();
			fireCooldown = fireDelay;

		} else if (fireCooldown > 0.0f) {

			fireCooldown -= Time.deltaTime;

		}

		if (Input.GetKeyDown(KeyCode.E)) {

			performAction();

		}
	
	}

	void OnTriggerEnter(Collider other){

		if (other.CompareTag("Death")) {

			//kill the player
			GameController.controller.die();
 
		} else if (other.CompareTag("Ammo")){

			GameController.controller.addAmmo(16);
			Destroy(other.gameObject);

		} else if (other.CompareTag("Health")){

			GameController.controller.getHealth(20);
			Destroy(other.gameObject);

		} else if (other.CompareTag("Medkit")){

			GameController.controller.getHealth(50);
			Destroy(other.gameObject);

		}

	}

	private void performAction(){

		//do raycast
		int middleX = Camera.main.pixelWidth / 2;
		int middleY = Camera.main.pixelHeight / 2;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(middleX, middleY, 0));
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, actionDistance)) {

			GameObject obj = hit.collider.gameObject;

			ObjectController controller = obj.GetComponent<ObjectController>();

			if (controller != null) {

				controller.performAction(this.gameObject);

			}
				
		}

	}
	
}

