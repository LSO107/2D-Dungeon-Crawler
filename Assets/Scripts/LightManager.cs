// Lee (1720076)
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private Light[] m_SceneLights;
    private Camera m_Camera;
    private float m_WindowBuffer = 0.45f;

    // Find all lights in the game and put them into an array
    // Deactivate all lights in the game
	private void Awake ()
	{
	    m_Camera = GetComponent<Camera>();
	    m_SceneLights = FindObjectsOfType<Light>();
	    foreach (var light1 in m_SceneLights)
	    {
            light1.gameObject.SetActive(false);
	    }
	}
	
	// Set lights active if "IsInRange"
	private void Update ()
	{
	    foreach (var lightsource in m_SceneLights)
	    {
	        lightsource.gameObject.SetActive(IsInRange(lightsource.transform.position));
	    }
	}

    // Check if light is in range of the camera view
    private bool IsInRange(Vector3 position)
    {
        var pointOnCamera = m_Camera.WorldToViewportPoint(position);

        return pointOnCamera.x >= -m_WindowBuffer
               && pointOnCamera.x <= 1 + m_WindowBuffer
               && pointOnCamera.y >= -m_WindowBuffer
               && pointOnCamera.y <= 1 + m_WindowBuffer;

    }
}
