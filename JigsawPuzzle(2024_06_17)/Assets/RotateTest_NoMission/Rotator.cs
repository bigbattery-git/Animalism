using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [ContextMenu("Print Log")]
    public void ShowRotationZ()
    {
        Debug.Log($"{this.gameObject.name}'s rotationX : {this.transform.localEulerAngles.z}");
    }
}
