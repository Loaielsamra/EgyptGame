using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera Cam;
    public float zoomSpeed;
    public KeyCode zoomButton;

    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(zoomButton))
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 5, zoomSpeed * Time.deltaTime);
        }
        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 10, zoomSpeed * Time.deltaTime);
        }
    }
}
