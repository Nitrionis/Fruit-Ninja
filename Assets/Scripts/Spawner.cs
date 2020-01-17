using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public FruitsManager fruitsManager;
	public float Angle;
	public float Distance;
	public float MaxOffset;
	public float Interval;
	public float Force;
	public float Height;
	public int MaxFruisCount;

	public LifeController lController;

	private LinkedList<GameObject> fruits = new LinkedList<GameObject>();
	private LinkedList<GameObject> fruitCut = new LinkedList<GameObject>();

	private float localtime = 0;

	void Start()
    {
		Time.timeScale = 0.7f;
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

                if(node.Value.tag == "Sliceable" && node.Value.layer != 4) {
					lController?.AddDamage(); //To damage
				}

				fruits.Remove(node);
			}
			node = next;
		}
		node = fruitCut.First;
		while (node != null) {
			var next = node.Next;
			if (node.Value.transform.position.y < Height - 1) {
				GameObject.Destroy(node.Value);
				fruitCut.Remove(node);
			}
			node = next;
		}
	}

	public void NewFruitCut(GameObject gameObject) => fruitCut.AddLast(gameObject);

	private void CreateNewFruit()
	{
		var forvard = transform.forward;
		var rotation = Quaternion.AngleAxis((Random.value - 0.5f) * Angle, Vector3.up);
		var pos = rotation * (forvard * Distance) + Vector3.up * Height + new Vector3(transform.position.x, 1, transform.position.z);
		var fruit = Instantiate(fruitsManager.GetNextFruit(), pos, Random.rotation);
		fruits.AddLast(fruit);
		fruit.gameObject.GetComponent<Rigidbody>().AddForce(Force * Vector3.up, ForceMode.Impulse);
	}
}
