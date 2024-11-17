using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    private static CheckpointManager instance;
    public int lastCheckpoint = -1;
    [SerializeField] int numberOfCheckpoints = 1;
    private void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(instance); } else { Destroy(gameObject); }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public void checkpointTouched(int id)
    {
        if (id == lastCheckpoint + 1)
        {
            lastCheckpoint = id;
        }
        else if (id == 0 && lastCheckpoint == numberOfCheckpoints - 1)
        {
            //TODO::what happens when we reach the finish
        }
        else if (id == 0 && lastCheckpoint == -1) { 
            //First time crossing start line. 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
