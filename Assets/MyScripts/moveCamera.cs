using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    [SerializeField] private float heightSpeed = 0.5f;
    [SerializeField] private float minValue = 1.0f;
    [SerializeField] private float maxValue = 100.0f;

    void Update()
    {
        moveCameraScript();
    }

    void moveCameraScript()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * speed;
        float zAxisValue = Input.GetAxis("Vertical") * speed;
        float yValue = 0.0f;

        Vector3 camPos = transform.position;
        Vector3 rotateValue;
        rotateValue = new Vector3(0, 0.8f, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            yValue = -heightSpeed;
            if (camPos.y <= minValue)
            {
                camPos = new Vector3(camPos.x + xAxisValue, minValue, camPos.z + zAxisValue);
            }
        }


        else if (Input.GetKey(KeyCode.Space))
        {
            yValue = heightSpeed;
            if (camPos.y >= maxValue)
            {
                camPos = new Vector3(camPos.x + xAxisValue, maxValue, camPos.z + zAxisValue);
            }
        }

        else if (Input.GetKey(KeyCode.Q))
        {
            transform.eulerAngles = transform.eulerAngles - rotateValue;
        }

        else if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles = transform.eulerAngles + rotateValue;
        }

        transform.position = new Vector3(camPos.x + xAxisValue, camPos.y + yValue, camPos.z + zAxisValue);
        

    }
}
