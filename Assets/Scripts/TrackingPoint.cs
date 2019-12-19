using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingPoint : MonoBehaviour
{
	public Vector3 prevPosition;
	public Vector3 currPosition;

    // Start is called before the first frame update
    void Start()
    {
		prevPosition = transform.position;
		currPosition = transform.position;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		prevPosition = currPosition;
		currPosition = transform.position;
	}
}
