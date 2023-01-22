using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject carInPlayer;
    public GameObject yachtInPlayer;
    public GameObject aircraftInPlayer;
    public GameObject carInArea;
    public GameObject yachtInArea;
    public GameObject aircraftInArea;
    public GameObject exitCarButton;
    public GameObject exitYachtButton;
    public GameObject stashobject;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Animator animatorController;
    public bool isInAircraft;

    private void Awake()
    {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            carInPlayer.SetActive(true);
            carInArea.SetActive(false);
            exitCarButton.SetActive(true);
            stashobject.SetActive(false);

        }

        if (other.CompareTag("Yacht"))
        {
            yachtInPlayer.SetActive(true);
            yachtInArea.SetActive(false);
            exitYachtButton.SetActive(true);
            animatorController.enabled = false;
        }

        if (other.CompareTag("Aircraft"))
        {
            aircraftInPlayer.SetActive(true);
            aircraftInArea.SetActive(false);
            skinnedMeshRenderer.enabled = false;
            stashobject.SetActive(false);
            isInAircraft = true;
        }
    }

    public void ExitCar()
    {
        carInPlayer.SetActive(false);
        carInArea.SetActive(true);
        this.transform.position = new Vector3(this.transform.position.x - 3, this.transform.position.y, this.transform.position.z);
        exitCarButton.SetActive(false);
        stashobject.SetActive(true);

    }

    public void ExitYacth()
    {
        yachtInPlayer.SetActive(false);
        yachtInArea.SetActive(true);
        this.transform.position = new Vector3(297, this.transform.position.y,-16);
        exitYachtButton.SetActive(false);
        animatorController.enabled = true;
    }
}
