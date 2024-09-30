using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ConfJobIconInfo
{
    public int jobID;
}
public class ConfJobIcon : MonoBehaviour
{
    public ConfJobIconInfo iconInfo = new ConfJobIconInfo();
    public Button btnConfJob;

    private void Start()
    {
        btnConfJob = GetComponent<Button>();
    }
}