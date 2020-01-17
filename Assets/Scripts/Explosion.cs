using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
	public static bool IsNeedLoadScene = false;
	private bool wasActive = false;
	public GameObject prefab;

	public void OnTriggerEnter(Collider other)
	{
		if (
			!wasActive && this.tag != "nonSlisable" && 
			other.gameObject.tag != "nonSlisable" && 
			other.gameObject.tag != "Sliceable"
			) 
		{
			Debug.LogError("Explosion");
			Instantiate(prefab, transform.position, Quaternion.identity);
			wasActive = true;
			IsNeedLoadScene = true;
			//SceneManager.LoadScene("VitalyTestScene");
		}
	}
}
