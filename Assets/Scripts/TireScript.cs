using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireScript : MonoBehaviour
{
    [SerializeField] float impact = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 direction = (other.transform.position - transform.position);
            direction.y = 0;
            Vector3.Normalize(direction);
            (other.attachedRigidbody).AddForce(direction*impact, ForceMode.Impulse);
        }
        
          
    }
}
