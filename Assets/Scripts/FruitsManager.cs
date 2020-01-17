using UnityEngine;

public class FruitsManager : MonoBehaviour
{
	public bool useLoadZero = true;

	[Header("Strawberry")]
	public Color strawberryColor;
	public GameObject strawberryLoadZero;
	public GameObject strawberryLoadOne;

	[Space(10)]
	[Header("Apple")]
	public Color appleColor;
	public GameObject appleLoadZero;
	public GameObject appleLoadOne;

	[Space(10)]
	[Header("Pear")]
	public Color pearColor;
	public GameObject pearLoadZero;
	public GameObject pearLoadOne;

	[Space(10)]
	[Header("Banana")]
	public Color bananaColor;
	public GameObject bananaLoadZero;
	public GameObject bananaLoadOne;

	[Space(10)]
	[Header("Kiwi")]
	public Color kiwiColor;
	public GameObject kiwiLoadZero;
	public GameObject kiwiLoadOne;

	[Space(10)]
	[Header("Bomb")]
	public GameObject bombZero;

	private GameObject[] fruitsLoadZero;
	private GameObject[] fruitsLoadOne;

	void Awake()
	{
		fruitsLoadZero = new GameObject[6];
		fruitsLoadOne = new GameObject[6];

		int loadZeroIndex = 0;
		int loadOneIndex = 0;

		//var meshFilter = strawberryLoadZero.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, strawberryColor);
		fruitsLoadZero[loadZeroIndex++] = strawberryLoadZero;
		//meshFilter = strawberryLoadOne.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, strawberryColor);
		fruitsLoadOne[loadOneIndex++] = strawberryLoadOne;

		//meshFilter = appleLoadZero.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, appleColor);
		fruitsLoadZero[loadZeroIndex++] = appleLoadZero;
		//meshFilter = appleLoadOne.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, appleColor);
		fruitsLoadOne[loadOneIndex++] = appleLoadOne;

		//meshFilter = pearLoadZero.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, pearColor);
		fruitsLoadZero[loadZeroIndex++] = pearLoadZero;
		//meshFilter = pearLoadOne.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, pearColor);
		fruitsLoadOne[loadOneIndex++] = pearLoadOne;

		//meshFilter = bananaLoadZero.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, bananaColor);
		fruitsLoadZero[loadZeroIndex++] = bananaLoadZero;
		//meshFilter = bananaLoadOne.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, bananaColor);
		fruitsLoadOne[loadOneIndex++] = bananaLoadOne;

		//meshFilter = kiwiLoadZero.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, strawberryColor);
		fruitsLoadZero[loadZeroIndex++] = kiwiLoadZero;
		//meshFilter = kiwiLoadOne.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, strawberryColor);
		fruitsLoadOne[loadOneIndex++] = kiwiLoadOne;

		//meshFilter = kiwiLoadZero.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, strawberryColor);
		fruitsLoadZero[loadZeroIndex++] = bombZero;
		//meshFilter = kiwiLoadOne.GetComponent<MeshFilter>();
		//Сolorize(meshFilter.mesh, strawberryColor);
		fruitsLoadOne[loadOneIndex++] = bombZero;
	}

	public GameObject GetNextFruit()
	{
		int index = (int)(0.99f * Random.value * fruitsLoadZero.Length);
		return useLoadZero ? fruitsLoadZero[index] : fruitsLoadOne[index];
	}

	private static void Сolorize(Mesh mesh, Color color)
	{
		var colors = new Color[mesh.vertices.Length];
		for (int i = 0; i < colors.Length; i++) {
			colors[i] = color;
		}
		mesh.colors = colors;
	}
}
