using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject Prefab;
	public float Angle;
	public float Distance;
	public float MaxOffset;
	public float Interval;
	public float Force;
	public float Height;
	public int MaxFruisCount;

	private LinkedList<GameObject> fruits = new LinkedList<GameObject>();
	private LinkedList<GameObject> fruitCut = new LinkedList<GameObject>();

	private float localtime = 0;

	void Start()
    {
        
    }

    void Update()
    {
		localtime += Time.deltaTime;
		if (localtime >= Interval && fruits.Count < MaxFruisCount) {
			localtime = 0;
			CreateNewFruit();
		}
		var node = fruits.First;
		while (node != null) {
			var next = node.Next;
			if (node.Value.transform.position.y < Height - 1) {
				GameObject.Destroy(node.Value);
				fruits.Remove(node);
			}
			node = next;
		}
	}

	private void CreateNewFruit()
	{
		var forvard = transform.forward;
		var rotation = Quaternion.AngleAxis((Random.value - 0.5f) * Angle, Vector3.up);
		var pos = rotation * (forvard * Distance) + Vector3.up * Height + transform.position;
		var fruit = Instantiate(Prefab, pos, Quaternion.identity);
		fruits.AddLast(fruit);
		fruit.gameObject.GetComponent<Rigidbody>().AddForce(Force * Vector3.up, ForceMode.Impulse);
	}
}
