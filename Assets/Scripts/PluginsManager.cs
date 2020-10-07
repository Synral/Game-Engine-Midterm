using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PluginsManager : MonoBehaviour
{
    const string DLL_NAME = "Midterm";

    //Methods
    [DllImport(DLL_NAME)]
    private static extern void ResetLogger();

    //Setters
    [DllImport(DLL_NAME)]
    private static extern void SaveCheckpointTime(float RTBC);

    //Getters
    [DllImport(DLL_NAME)]
    private static extern float GetTotalTime();
    [DllImport(DLL_NAME)]
    private static extern float GetCheckpointTime(int index);
    [DllImport(DLL_NAME)]
    private static extern int GetNumCheckpoints();

    float lastTime = 0.0f;

    public void ReloadLogger()
    {
        ResetLogger();
    }
    public void SaveTime(float checkpointTime)
    {
        SaveCheckpointTime(checkpointTime);
    }
    public float LoadTotalTime()
    {
        return GetTotalTime();
    }
    public float LoadCheckpointTime(int index)
    {
        if (index >= GetNumCheckpoints())
        return -1.0f;
        else
        return GetCheckpointTime(index);
    }

    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float currentTime = Time.time;
            float checkpointTime = currentTime - lastTime;
            lastTime = currentTime;
            SaveTime(checkpointTime);
        }

        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0+i))
            {
                Debug.Log(LoadCheckpointTime(i));
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
            Debug.Log(LoadTotalTime());
    }

    private void OnDestroy() 
    {
        ReloadLogger();    
    }
}
