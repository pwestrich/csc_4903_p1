using UnityEngine;
using System.Collections;

public abstract class ObjectController : MonoBehaviour {

	//performs an action when the player interacts with it
	public abstract void performAction(GameObject player);
	
}
