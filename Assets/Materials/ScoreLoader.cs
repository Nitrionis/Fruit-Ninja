using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		GetComponent<Text>().text = ScoreController.LastScore.ToString();
	}
}
