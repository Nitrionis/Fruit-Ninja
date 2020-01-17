using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
	public GameObject scene;
	public GameObject startCube;
	public GameObject objectWithSpawner;
	public GameObject gameMenu;
	public Color skyboxcolor;
	public Camera[] cameras;
	
	void Start()
    {
		//foreach (var cam in cameras) {
		//	cam.backgroundColor = skyboxcolor;
		//}
		GoToMainUiMode();
	}

	public void GoToGameMode()
	{
		startCube.SetActive(false);
		objectWithSpawner.GetComponent<Spawner>().enabled = true;
		gameMenu.SetActive(true);
		scene?.SetActive(true);
		this.gameObject.SetActive(false);
	}

	public void GoToMainUiMode()
	{
		objectWithSpawner.GetComponent<Spawner>().enabled = false;
		gameMenu.SetActive(false);
	}
}
