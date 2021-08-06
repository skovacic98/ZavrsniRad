using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretMovement : MonoBehaviour
{
    public float turretSpeed = 50.0f;
    public float maxAngleDown = 70.0f;
    public float maxAngleUp = 0.0f;
    public float zAxis = 0.0f;
    public Text angleLabel;


    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        float zInput = Input.GetAxisRaw("Vertical");
        if (zInput != 0)
        {
            zAxis += (Time.deltaTime * zInput * turretSpeed);
            zAxis = Mathf.Clamp(zAxis, maxAngleDown, maxAngleUp);
            transform.rotation = Quaternion.Euler(0, 0, zAxis);
            angleLabel.text = "ANGLE: " + zAxis;
        }
    }
}
