using UnityEngine;
using System.Collections;

public class DoorController : ObjectController {

	public Vector3 moveDistance;
	public float speed;
	public float delay;

	private bool _moved;

	void Start(){

		_moved = false;
		moveDistance = transform.rotation * moveDistance;

	}

	public override void performAction(GameObject player){

		if (_moved) {

			return;

		}

		//when this object is activated, move the door so it opens
		Vector3 destination = transform.position + moveDistance;

		_moved = true;

		StartCoroutine("moveDoor");

	}

	private IEnumerator moveDoor(){
	
		Vector3 destination = transform.position + moveDistance;

		while (transform.position != destination) {

			transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);

			yield return null;

		}

		Debug.Log("Waiting: " + delay);
		yield return new WaitForSeconds(delay);

		destination -= moveDistance;

		while (transform.position != destination) {

			transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
			
			yield return null;
			
		}

		_moved = false;

	}

}
