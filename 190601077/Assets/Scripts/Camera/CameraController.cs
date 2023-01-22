using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float DistanceToPlayer;
    public float baseDistanceToPlayer;
    public Movement playerMovement;
    public Transform TargetTransform;
    public Transform AircraftTargetTransform;
    public Vehicle vehicle;


    public float speed;
    void Start()
    {
        baseDistanceToPlayer = Vector3.Distance(transform.position, TargetTransform.position);

    }

    void LateUpdate()
    {

        if (playerMovement.isWalking)
        {
            if (!vehicle.isInAircraft)
            {
                transform.position = Vector3.Lerp(transform.position, CalculatePos(), speed);
            }

            else
            {
                TargetTransform = AircraftTargetTransform;     
                transform.position = Vector3.Lerp(transform.position, CalculatePos(), speed);
            }
           
        }

        else
        {
            transform.position = Vector3.Lerp(transform.position, InitPos(), speed);
        }


    }


    private Vector3 CalculatePos()
    {
        var pos = transform.position;

        var direction = transform.forward * -1;

        pos = TargetTransform.position + direction.normalized * DistanceToPlayer;

        return pos;
    }

    private Vector3 InitPos()
    {
        var pos = transform.position;

        var direction = transform.forward * -1;

        pos = TargetTransform.position + direction.normalized * baseDistanceToPlayer;

        return pos;
    }
}
