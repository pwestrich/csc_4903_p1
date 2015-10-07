using UnityEngine;
using System.Collections;

public abstract class EnemyController : MonoBehaviour {

	public int maxHealth;			//how much health can he have?

	private int _currentHealth;	//how much health dues he currently have?

	//what should happen if an enemy is hit?
	public abstract void getHit(int pain);

	//what should the enemy do every frame?
	public abstract void tick();

	//what happens when he dies?
	public abstract void die();

}
