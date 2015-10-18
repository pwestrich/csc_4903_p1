using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour, ObjectController {

	public Vector3 moveDistance;
	public float speed;
	public float delay;

	private bool _moved;
	private AudioSource _audio;

	void Start(){

		_moved = false;
		moveDistance = transform.rotation * moveDistance;
		_audio = GetComponent<AudioSource>();

	}

	public void performAction(GameObject player){

		if (_moved) {

			return;

		}

		if (_audio) {

			_audio.Play();

		}

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
