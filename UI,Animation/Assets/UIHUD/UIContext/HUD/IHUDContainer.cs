using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHUDContainer
{
    public bool IsOperated { get; }
    public enum STATE { NONE, READY, RING, REPORT, END }
    public STATE State { get; }
    public void Show();
    public void Hide();
    public void PlayRing();
    public void PlayReport();
}