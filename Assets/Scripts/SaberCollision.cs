using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberCollision : MonoBehaviour
{
	public Transform hand;
	public TrackingPoint trackingPoint;
	public Cutter cutter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Test SaberCollision OnTriggerEnter");
		cutter.OnLineDrawn(
			start: trackingPoint.prevPosition,
			end: trackingPoint.currPosition,
			Cutter.GetDepth(
				trackingPoint.prevPosition,
				trackingPoint.currPosition,
				hand.transform.position),
			new GameObject[] { other.gameObject });
	}
}
