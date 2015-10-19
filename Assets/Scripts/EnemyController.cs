using UnityEngine;
using System.Collections;

public abstract class EnemyController : MonoBehaviour {

	public int maxHealth;		//how much health can he have?
	public int damage;			//how much does he hurt per shot?
	public float accuracy;
	public float fireTime;		//how often can we fire?
	public float alertDistance;	//how far away do we care about things?
	public GameObject drop;		//what does he drop on death?
	public AudioClip deathSound;
	public AudioClip shootSound;
	public AudioClip alertSound;
	public AudioClip painSound;

	protected int _currentHealth;	//how much health dues he currently have?
	protected float _deathDelay;	//how long to wait before dying?
	protected float _fireCooldown;	//how long until we can fire again?
	protected bool _dying;			//Is he currently dying?
	protected AudioSource _source;	//what to play sounds from
	protected GameObject _player;	//where is he?

	void Start(){

		_currentHealth = maxHealth;
		_source = gameObject.GetComponent<AudioSource>();
		_deathDelay = deathSound.length;
		_player = GameObject.FindWithTag("Player");
		_dying = false;
	
	}

	void FixedUpdate(){

		//turn towards the player
		Vector3 direction = transform.position - _player.transform.position;
		Quaternion targetRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 1.0f);

		if (_fireCooldown <= 0.0f){

			//look for the player
			RaycastHit hit;
			bool result = Physics.Raycast(transform.position, -direction, out hit, alertDistance);

			if (result && (hit.collider.gameObject == _player)){

				//no aimbots
				float num = Random.value;

				if (num < accuracy){

					GameController.controller.getHit(damage);

				}

				_source.clip = shootSound;
				_source.Play();
				_fireCooldown = fireTime;

			}

		} else {

			//decrement cooldown
			_fireCooldown -= Time.deltaTime;

		}
	
	}

	//what should happen if an enemy is hit?
	public void getHit(int pain){

		if (_dying) return; //don't do anything if he's dying

		_currentHealth -= pain; //deduct health

		if (_currentHealth <= 0){

			//play death sound
			_source.clip = deathSound;
			_source.Play();
			_dying = true;

			Instantiate(drop, transform.position - new Vector3(0.0f, 0.9f, 0.0f), transform.rotation);

			StartCoroutine("die");

		} else {

			//play hurt sound
			_source.clip = painSound;
			_source.Play();

		}

	}

	//what happens when he dies?
	public IEnumerator die(){

		//do death animation
		yield return new WaitForSeconds(_deathDelay);

		//destroy
		Destroy(gameObject);

	}

}
