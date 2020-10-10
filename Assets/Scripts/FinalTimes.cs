using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTimes : MonoBehaviour
{
    public Text[] checkpointTimes;
    public PluginsManager plugins;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7;i++)
        checkpointTimes[i] = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        checkpointTimes[0].text = "Congratulations!";
        checkpointTimes[1].text = "Checkpoint 1: " + plugins.LoadCheckpointTime(0);
        checkpointTimes[2].text = "Checkpoint 2: "+ plugins.LoadCheckpointTime(1);
        checkpointTimes[3].text = "Checkpoint 3: "+ plugins.LoadCheckpointTime(2);
        checkpointTimes[4].text = "Checkpoint 4: "+ plugins.LoadCheckpointTime(3);
        checkpointTimes[5].text = "Checkpoint 5: "+ plugins.LoadCheckpointTime(4);
        checkpointTimes[6].text = "Total Run Time: "+plugins.LoadTotalTime();
    }
}
