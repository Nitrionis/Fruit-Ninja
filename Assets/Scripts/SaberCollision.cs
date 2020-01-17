using UnityEngine;

public class SaberCollision : MonoBehaviour
{
	public Transform suberRotation;
	public TrackingPoint trackingPoint;
	public Cutter cutter;
    public LifeController lController;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Test SaberCollision OnTriggerEnter");
		cutter.OnLineDrawn(
			start: trackingPoint.prevPosition,
			end: trackingPoint.currPosition,
			Cutter.GetDepth(
				trackingPoint.prevPosition,
				trackingPoint.currPosition,
                suberRotation.transform.position),
			new GameObject[] { other.gameObject });
	}
}
