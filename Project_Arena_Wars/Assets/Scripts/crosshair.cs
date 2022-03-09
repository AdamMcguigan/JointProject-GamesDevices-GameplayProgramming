using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour
{
    private Vector3 MouseCoords;
    public float MouseSensitivity = 0.1f;
    void Update()
    {
        GameObject crosshair = GameObject.Find("crosshair");
        MouseCoords = Input.mousePosition;
        MouseCoords = Camera.main.ScreenToWorldPoint(MouseCoords);
        crosshair.transform.position = Vector2.Lerp(transform.position, MouseCoords, MouseSensitivity);
        //print(MouseCoords);
    }
}
