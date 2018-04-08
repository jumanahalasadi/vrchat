using UnityEngine;

public class LineRendererTest : MonoBehaviour
{
	private LineRenderer _lineRenderer;
	public void Start()
	{
		_lineRenderer = gameObject.AddComponent<LineRenderer>();
		_lineRenderer.SetWidth(0.2f, 0.2f);
		_lineRenderer.enabled = false;
	}

	private Vector3 _initialPosition;
	private Vector3 _currentPosition;
	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_initialPosition = GetCurrentMousePosition().GetValueOrDefault();
			_lineRenderer.SetPosition(0, _initialPosition);
			_lineRenderer.SetVertexCount(1);
			_lineRenderer.enabled = true;
		} 
		else if (Input.GetMouseButton(0))
		{
			_currentPosition = GetCurrentMousePosition().GetValueOrDefault();
			_lineRenderer.SetVertexCount(2);
			_lineRenderer.SetPosition(1, _currentPosition);

		} 
		else if (Input.GetMouseButtonUp(0))
		{
			_lineRenderer.enabled = false;
			var releasePosition = GetCurrentMousePosition().GetValueOrDefault();
			var direction = releasePosition - _initialPosition;
			Debug.Log("Process direction " + direction);
		}
	}

	private Vector3? GetCurrentMousePosition()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		var plane = new Plane(Vector3.forward, Vector3.zero);

		float rayDistance;
		if (plane.Raycast(ray, out rayDistance))
		{
			return ray.GetPoint(rayDistance);

		}

		return null;
	}

}