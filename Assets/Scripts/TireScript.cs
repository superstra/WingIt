using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TireScript : MonoBehaviour
{
    [SerializeField] float impact = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { 
            Vector3 refl = (other.transform.position - transform.position);
            refl.y = 0;
            Vector3.Normalize(refl);
            Vector3 inDir = other.attachedRigidbody.velocity.normalized;

            Vector3 newDir = Vector3.Reflect(inDir, refl);
            (other.attachedRigidbody).velocity = newDir * other.attachedRigidbody.velocity.magnitude;
            other.attachedRigidbody.AddForce(newDir*impact, ForceMode.Impulse);


        }
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 direction = (other.transform.position - transform.position);
            direction.y = 0;
            Vector3.Normalize(direction);
            (other.attachedRigidbody).AddForce(direction*impact, ForceMode.Impulse);
        }
        
          
    }*/
}
    