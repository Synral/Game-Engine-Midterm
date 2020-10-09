using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    float cameraX = 0.0f;
    float cameraY = 0.0f;
    float mouseSens = 1000.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float rotationX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;
        float rotationY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;
        cameraX -=rotationY;
        cameraX = Mathf.Clamp(cameraX, -90.0f, 90.0f);

        cameraY += rotationX;
        
        transform.localRotation = Quaternion.Euler(cameraX, cameraY, 0.0f);
        player.Rotate(Vector3.up * rotationX);
    }
}
