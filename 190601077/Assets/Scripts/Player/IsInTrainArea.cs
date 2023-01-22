using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInTrainArea : MonoBehaviour
{
    public GameObject stopTrainButton;
    public Collider trainArea;
    public Collider trainAreaExit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrainArea"))
        {
            stopTrainButton.SetActive(true);
            trainArea.enabled = false;
            trainAreaExit.enabled = true;
        }

        if (other.CompareTag("TrainAreaExit"))
        {
            stopTrainButton.SetActive(false);
            trainArea.enabled = true;
            trainAreaExit.enabled = false;
        }
    }
}
