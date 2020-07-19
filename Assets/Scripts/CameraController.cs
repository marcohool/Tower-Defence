using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{

    private float panSpeed = 100f;
    private bool _esc = true;
    private float scrollSpeed = 40f;
    private string _inputKey;
    private float _currentZoom = 0;
    private float ZoomRotation = 1;
    private readonly Vector2 zoomAngleRange = new Vector2( 20, 70 );
    private Vector3 _initialPosition;
    private Vector3 _initialRotation;

    private void Start()
    {
        _initialPosition = transform.position;
        _initialRotation = transform.eulerAngles;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _esc = !_esc;
        }

        if (!_esc)
        {
            return;
        }

        

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - 5f)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= 5f)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= 5f)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - 5f)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        
        
        _currentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * scrollSpeed;
        _currentZoom = Mathf.Clamp( _currentZoom, -70f, 10f );
        transform.position = new Vector3( transform.position.x, transform.position.y - (transform.position.y - (_initialPosition.y + _currentZoom)) * 0.1f, transform.position.z );
        float x = transform.eulerAngles.x - (transform.eulerAngles.x - (_initialRotation.x + _currentZoom * ZoomRotation)) * 0.1f;
        x = Mathf.Clamp( x, zoomAngleRange.x, zoomAngleRange.y );
        transform.eulerAngles = new Vector3( x, transform.eulerAngles.y, transform.eulerAngles.z );
    }
    
}
