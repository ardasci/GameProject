using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftController : MonoBehaviour
{
    public float throttleIncrement = 0.1f;
    public float maxThrust = 200f;
    public float responsiveness = 10f;
    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;
    private Rigidbody rb;
    public Transform propella;
    public VariableJoystick variableJoystick;
    public Movement playerMove;
    private float verticalInput;
    private float horizontalInput;
    private float responsiveModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerMove = GetComponentInParent<Movement>();
    }

    private void HandleInputs()
    {
        roll = horizontalInput;
        pitch = verticalInput;
        yaw = Input.GetAxis("Yaw");
        if (verticalInput < 0) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        playerMove.enabled = false;
        horizontalInput = variableJoystick.Horizontal;
        verticalInput = variableJoystick.Vertical;
        HandleInputs();
        propella.Rotate(Vector3.forward * throttle / responsiveness);
    }
    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responsiveModifier);
        rb.AddTorque(transform.right * pitch * responsiveModifier);
        rb.AddTorque(-transform.forward * roll * responsiveModifier);
    }
}
