using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartMenuScript : MonoBehaviour {

	public void onButtonStartClick(){
		SceneManager.LoadScene (1);
	}
}
