using UnityEngine;

public class ScreenLineRenderer : MonoBehaviour
{
	public delegate void LineDrawnHandler(Vector3 begin, Vector3 end, Vector3 depth);
	public event LineDrawnHandler OnLineDrawn;

	private bool dragging;
	private Vector3 start;
	private Vector3 end;
	private Camera cam;

	public Material lineMaterial;

	void Start()
	{
		cam = Camera.main;
		dragging = false;
	}

	private void OnEnable()
	{
		Camera.onPostRender += PostRenderDrawLine;
	}

	private void OnDisable()
	{
		Camera.onPostRender -= PostRenderDrawLine;
	}

	// Update is called once per frame
	void Update()
	{
		if (!dragging && Input.GetMouseButtonDown(0)) {
			start = cam.ScreenToViewportPoint(Input.mousePosition);
			dragging = true;
		}

		if (dragging) {
			end = cam.ScreenToViewportPoint(Input.mousePosition);
		}

		if (dragging && Input.GetMouseButtonUp(0)) {
			// Finished dragging. We draw the line segment
			end = cam.ScreenToViewportPoint(Input.mousePosition);
			dragging = false;

			var startRay = cam.ViewportPointToRay(start);
			var endRay = cam.ViewportPointToRay(end);

			// Raise OnLineDrawnEvent
			OnLineDrawn?.Invoke(
				startRay.GetPoint(cam.nearClipPlane),
				endRay.GetPoint(cam.nearClipPlane),
				endRay.direction.normalized);
		}
	}

	private void PostRenderDrawLine(Camera cam)
	{
		if (dragging && lineMaterial) {
			GL.PushMatrix();
			lineMaterial.SetPass(0);
			GL.LoadOrtho();
			GL.Begin(GL.LINES);
			GL.Color(Color.black);
			GL.Vertex(start);
			GL.Vertex(end);
			GL.End();
			GL.PopMatrix();
		}
	}
}