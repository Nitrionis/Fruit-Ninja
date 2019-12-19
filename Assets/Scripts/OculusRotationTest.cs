using UnityEngine;

public class OculusRotationTest : MonoBehaviour
{
#if UNITY_EDITOR
	public float speed = 1;
	private float x = 0;
	private float y = 0;

#endif
	// Update is called once per frame
	void Update()
    {
#if !UNITY_EDITOR
		transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
#else
		y += Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
		x += Input.GetAxis("Mouse X") * Time.deltaTime * speed;
		transform.rotation = Quaternion.Euler(new Vector3(y, x, 0));
#endif
	}
}
