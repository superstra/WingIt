using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private Transform track;
    [SerializeField] private Transform arrow;
    [SerializeField] private MeshRenderer rendering;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ud = Input.GetAxisRaw("Vertical");
        float lr = Input.GetAxisRaw("Horizontal");
        dir = new Vector3(lr, 0, ud);
        if (dir.magnitude >= 0.04) {
            dir.Normalize();
            Quaternion quat = Quaternion.LookRotation(dir, new Vector3(0,1,0));
            arrow.transform.SetPositionAndRotation(track.position, quat);
            rendering.enabled = true;
        }
        else
        {
            rendering.enabled = false;
        }
    }
}
