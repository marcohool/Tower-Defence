using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{

    private float panSpeed = 30f;
    private bool _esc = true;
    private float scrollSpeed = 20f;
    private string _inputKey;

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
        
        Vector3 pos = transform.position;
        pos.y -= Input.GetAxis("Mouse ScrollWheel") * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, 10f, 100f);
        transform.position = pos;
    }

    private void moveCamera()
    {
        
    }
}
