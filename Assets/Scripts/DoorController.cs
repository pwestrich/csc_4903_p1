using UnityEngine;
using System.Collections;

public class DoorController : ObjectController {

	public float moveDistance;
	public float speed;

	private bool _moved;

	void Start(){

		_moved = false;

	}

	public override void performAction(GameObject player){

		//when this object is activated, move the door so it opens
		Vector3 destination = transform.position + new Vector3(0.0f, 0.0f, moveDistance);

		_moved = true;

		StartCoroutine("moveDoor", destination);

	}

	private IEnumerator moveDoor(Vector3 destination){

		while (transform.position != destination) {

			transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);

			yield return null;

		}

	}

}
