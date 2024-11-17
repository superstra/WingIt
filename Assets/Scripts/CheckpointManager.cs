using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    private static CheckpointManager instance;
    private int lastCheckpoint = -2;
    [SerializeField] GameManager gm;
    [SerializeField] TMP_Text progress;
    [SerializeField] int numberOfCheckpoints = 1;
    private void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(instance); } else { Destroy(gameObject); }
    }
    // Start is called before the first frame update
    void Start()
    {
        progress.text = "Checkpoint 0/" + numberOfCheckpoints;
    }

    public void checkpointTouched(int id)
    {
        if (id == lastCheckpoint + 1)
        {
            lastCheckpoint = id;
            progress.text ="Checkpoint "+ (id).ToString() + "/" + numberOfCheckpoints.ToString();
        }
        else if (id == 0 && lastCheckpoint == numberOfCheckpoints - 1)
        {
            //TODO::what happens when we reach the finish
            progress.text = "FINISHED!";
            gm.activeTimer = false;
        }
        else if (id == 0 && lastCheckpoint == -2) {
            //First time crossing start line
            lastCheckpoint = 0;
            gm.activeTimer = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
