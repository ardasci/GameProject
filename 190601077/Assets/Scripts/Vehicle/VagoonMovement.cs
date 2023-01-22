using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagoonMovement : MonoBehaviour
{
    public LocomotiveMovement loomotiveMovement;
    public float offsetBetweenLocomotive = -0.035f;

    void Update()
    {
        if (loomotiveMovement == null)
            return;

        var timeTravelled = loomotiveMovement.GetCurrentTimeTravelled() + offsetBetweenLocomotive;
        transform.position = loomotiveMovement.pathCreator.path.GetPointAtTime(timeTravelled, loomotiveMovement.endOfPathInstruction);
        transform.rotation = loomotiveMovement.pathCreator.path.GetRotation(timeTravelled, loomotiveMovement.endOfPathInstruction);

    }
}
