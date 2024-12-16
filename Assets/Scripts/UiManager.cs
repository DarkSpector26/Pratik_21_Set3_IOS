using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject Levelpanael;
    private string CurrentLevel = "Level1";

   public  void NextLevel()
    {
        Levelpanael.SetActive(true);
        GameAnalytics.instance.NextLevel(CurrentLevel);
    }
}
