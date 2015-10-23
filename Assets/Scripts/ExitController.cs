using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour, ObjectController {

	public int targetLevel;

	public void performAction(GameObject player){

		Application.LoadLevel(targetLevel);

	}

}
