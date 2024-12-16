using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class GameAnalytics : MonoBehaviour
{

    public static GameAnalytics instance;
    private  bool isInitialize = false;
    private void Awake()
    {
        if (instance !=null && instance !=this)
        {
            Destroy(instance );
        }
        else
        {
            instance = this;
        }
    }

    private async void Start()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
        isInitialize = true;
    }
     public void NextLevel(string CurrentLevel)
    {
        if(!isInitialize)
        {
            return;
        }

        CustomEvent Event = new CustomEvent("Level1_Completed")
        {
            {"Level_Name", CurrentLevel}
        };
        AnalyticsService.Instance.RecordEvent(Event);
        AnalyticsService.Instance.Flush();
        Debug.Log("Level1_Completed");
    }
  
}
