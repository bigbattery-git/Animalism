using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BKeyManager : MonoBehaviour
{
    public KeyCode killKey;
    public KeyCode itemKey;
    public KeyCode reportKey;
    public KeyCode ringKey;
    void Update()
    {
        InputKey();
    }
    private void InputKey()
    {
        if (Input.GetKeyDown(killKey))
        {
            
        }

        if (Input.GetKeyDown(itemKey))
        {
            
        }

        if (Input.GetKeyDown(reportKey))
        {
            
        }

        if (Input.GetKeyDown(ringKey))
        {
            
        }
    }
}