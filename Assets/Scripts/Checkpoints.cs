using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public PluginsManager plugins;
    public GameObject[] checkpoints;
    public bool[] active;
    // Start is called before the first frame update
    void Start()
    {
        active = new bool[6];
        for (int i=0;i<6;i++)
        active[i] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resetCheckpoints()
    {
        for (int i = 0; i < 6; i++)
        active[i] = false;
    }
    void activateCheckpoints(int index)
    {
        active[index] = true;
        if (index != 1)
        plugins.saveCheckpoint();
    }

    public void respawn()
    {
        Debug.Log(active);
        for (int i=5;i>=0;i--)
        if (active[i])
        {
            transform.position = checkpoints[i].transform.position;
            break;
        }
    }
}