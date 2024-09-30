using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    [SerializeField] RectTransform thisthis;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(thisthis.anchoredPosition, thisthis.anchoredPosition * Vector3.right * 1000);
        Gizmos.DrawLine(thisthis.anchoredPosition, thisthis.anchoredPosition * Vector3.left * 1000);
        Gizmos.DrawLine(thisthis.anchoredPosition, thisthis.anchoredPosition * Vector3.up * 1000);
        Gizmos.DrawLine(thisthis.anchoredPosition, thisthis.anchoredPosition * Vector3.down * 1000);
    }
}
