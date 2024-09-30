using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanBoardManager : MonoBehaviour
{
    GameObject[] childGameObject;
    bool isClear = false;
    private void Awake()
    {
        childGameObject = new GameObject[transform.childCount];
        for (int i = 0; i < childGameObject.Length; ++i)
        {
            childGameObject[i] = transform.GetChild(i).gameObject;
        }
    }
    private void Update()
    {
        if (!isClear)
        {
            Debug.Log("ABCDESL");
            Clear();
        }        
    }
    void Clear()
    {
        int a = 0;
        for (int i = 0; i < transform.childCount; ++i)
        {
            if(childGameObject[i].activeSelf == false)
            {
                a++;
            }
        }
        if (a == transform.childCount)
        {
            Debug.Log("Claer");
            isClear = true;
        }
    }
}