using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class OVSoundRoot 
{
    private static OVSoundRoot instance;
    public static OVSoundRoot Instance { get { if (instance == null) instance = new OVSoundRoot(); return instance; } }

    public MissionSound Mission;
}