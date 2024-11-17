using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager cm;

    [SerializeField] int checkpointID = -1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            //Debug.Log("Player touched Checkpoint " + checkpointID.ToString());
            cm.checkpointTouched(checkpointID);
        }
    }

    private void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointManager>();
    }
}
