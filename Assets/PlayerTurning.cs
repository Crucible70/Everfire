using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurning : MonoBehaviour
{
    float xRotation = 0f;
    public Vector2 turn;
    public float Sensitivity = 50;
    float sensitivity;
    void Start()
    {
        sensitivity = Sensitivity * 10;
    }
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        turn.y = Input.GetAxis("Mouse Y") * 0 * Time.deltaTime;
        xRotation -= turn.y;
        xRotation = Mathf.Clamp(xRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(xRotation, turn.x, 0);
    }
}