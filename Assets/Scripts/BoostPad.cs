using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{
    [SerializeField] float impulseStrength = 150f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {

            Vector3 directionToGo = transform.rotation * Vector3.forward;
            other.attachedRigidbody.AddForce(directionToGo*impulseStrength, ForceMode.Impulse);
        }
    }
}
