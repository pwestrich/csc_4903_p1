using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour, ObjectController {

	public Vector3 moveDistance;
	public float speed;
	public float delay;

	public AudioClip openSound;
	public AudioClip closeSound;

	private bool _moved;
	private AudioSource _source;

	void Start(){

		_moved = false;
		moveDistance = transform.rotation * moveDistance;
		_source = GetComponent<AudioSource>();

	}

	public void performAction(GameObject player){

		if (_moved) {

			return;

		}

		_moved = true;

		StartCoroutine("moveDoor");

	}

	private IEnumerator moveDoor(){
		
		_source.clip = openSound;
		_source.Play();

		Vector3 destination = transform.position + moveDistance;

		while (Vector3.Distance(transform.position, destination) > 0.01f) {

			transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);

			yield return null;

		}

		yield return new WaitForSeconds(delay);

		if (gameObject.tag != "Secret") {

			_source.clip = closeSound;
			_source.Play();

			destination -= moveDistance;

			while (Vector3.Distance(transform.position, destination) > 0.01f) {

				transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
				
				yield return null;
				
			}

			_moved = false;

		}

	}

}
