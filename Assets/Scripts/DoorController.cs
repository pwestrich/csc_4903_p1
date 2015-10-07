using UnityEngine;
using System.Collections;

public class DoorController : ObjectController {

	public float moveDistance;
	public float speed;
	public float delay;

	private bool _moved;
	private Vector3 _movement;

	void Start(){

		_moved = false;
		_movement = transform.rotation * new Vector3(moveDistance, 0, 0);

	}

	public override void performAction(GameObject player){

		if (_moved) {

			return;

		}

		//when this object is activated, move the door so it opens
		Vector3 destination = transform.position + _movement;

		_moved = true;

		StartCoroutine("moveDoor");

	}

	private IEnumerator moveDoor(){
	
		Vector3 destination = transform.position + _movement;

		while (transform.position != destination) {

			transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);

			yield return null;

		}

		Debug.Log("Waiting: " + delay);
		yield return new WaitForSeconds(delay);

		destination -= _movement;

		while (transform.position != destination) {

			transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
			
			yield return null;
			
		}

		_moved = false;

	}

}
