using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresserManager : MonoBehaviour
{
    public static PresserManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public bool CallMissionClear()
    {
        Debug.Log("clear!");
        return true;            
    }
}
