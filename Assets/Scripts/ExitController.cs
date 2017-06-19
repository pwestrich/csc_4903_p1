using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour, ObjectController {

	public int targetLevel;

	public void performAction(GameObject player){

		SceneManager.LoadScene(targetLevel);

	}

}
