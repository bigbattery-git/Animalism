using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


// https://www.notion.so/Public-OVillage-Sound-2023-11-05-71a3c341bf61432ba289b631277203e0?pvs=4
public enum WalkingSound { Corridor, MetalFloor, StoneDirtPath, WoodenFloor, 
    BrickPavedPath, StoneFloor, UnpavedDirtPath, GrassyDirtPath}
public class OvillageBGM : MonoBehaviour
{
    public AudioSource FactoryBGM;
    public AudioSource ClockTowerBGM;
    public AudioSource IntroBGMInno;
    public AudioSource IntroBGMMafia;
    public AudioSource IntroBGMMutNonKill;
    public AudioSource IntroBGMMutKill;
    public AudioSource OutroBGMInnoMission;
    public AudioSource OutroBGMInnoVote;
    public AudioSource OutroBGMMafia;
    public AudioSource OutroBGMMutNonKill;
    public AudioSource OutroBGMMutKill;

    [Header("Walking Sound")]
    public AudioSource[] Corridor;
    public AudioSource[] MetalFloor;
    public AudioSource[] StoneDirtPath;
    public AudioSource[] WoodenFloor;
    public AudioSource[] BrickPavedPath;
    public AudioSource[] StoneFloor;
    public AudioSource[] UnpavedDirtPath;
    public AudioSource[] GrassyDirtPath;

    public AudioSource GetRandomWalkingSound(WalkingSound _walkingSound)
    {
        AudioSource[] walkingSound = BrickPavedPath;

        switch (_walkingSound)
        {
            case WalkingSound.Corridor:
                walkingSound = Corridor;
                break;
            case WalkingSound.MetalFloor: 
                walkingSound = MetalFloor;
                break;
            case WalkingSound.StoneDirtPath:
                walkingSound = StoneDirtPath;
                break;
            case WalkingSound.WoodenFloor:
                walkingSound = WoodenFloor;
                break;
            case WalkingSound.BrickPavedPath:
                walkingSound = BrickPavedPath;
                break;
            case WalkingSound.StoneFloor:
                walkingSound = StoneFloor;
                break;
            case WalkingSound.UnpavedDirtPath:
                walkingSound = UnpavedDirtPath;
                break;
            case WalkingSound.GrassyDirtPath:
                walkingSound = GrassyDirtPath;
                break;
        }

        if (walkingSound != null)
            return walkingSound[UnityEngine.Random.Range(0, walkingSound.Length)];

        return null;
    }
}