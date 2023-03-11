using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTurning : MonoBehaviour
{
    float xRotation = 0f;
    public Vector2 turn;
    public float Sensitivity = 50;
    public Vector3 deltaMove;
    public float speed = 1;
    float sensitivity;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        sensitivity = Sensitivity * 10;
    }
    void Update()
    {

        turn.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        turn.y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xRotation -= turn.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, turn.x, 0);
    }
}