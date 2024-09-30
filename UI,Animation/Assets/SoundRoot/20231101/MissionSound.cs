using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MissionSound : MonoBehaviour
{
    [Header("Public Mission Sound")]
    public AudioSource MissionClearSound;
    public AudioSource MissionInProgressSound;
    public AudioSource MissionObjectSelectSound;
    public AudioSource PushSabotageButton;

    [Header("Church")]    
    public AudioSource ID2CleanTombstone;
    public AudioSource ID3Rolling;
    public AudioSource ID3Rolling2;
    public AudioSource ID3Matching;
    public AudioSource ID4PushingWater;
    public AudioSource ID4PushingSalt;
    public AudioSource ID5GettingItem;
    public AudioSource ID6PuttingHoneycomb;
    public AudioSource ID7SprayingWater;
    public AudioSource ID8SprayingBeans;
    public AudioSource ID8GettingBeans;
    public AudioSource ID9StartingWeigh;
    public AudioSource ID9Weighing1;
    public AudioSource ID9Weighing2;

    [Header("Restorant")]
    public AudioSource ID10StartingBurning;
    public AudioSource ID11StartingCurculating;
    public AudioSource ID1213CleaningDish;
    public AudioSource ID1213CleaningDish2;
    public AudioSource ID12CleaningTable;
    public AudioSource ID14CleaningFloor;
    public AudioSource ID14CleanedFloor;

    [Header("Inn")]
    public AudioSource ID16PickingKey;
    public AudioSource ID1718PickMoney1;
    public AudioSource ID1718PickMoney2;
    public AudioSource ID18StartPuttingMoney;
    public AudioSource ID19PrefaringChess;
    public AudioSource ID20CleaningMirror;
    public AudioSource ID21ShakingPillow;

    [Header("TrainStation")]
    public AudioSource ID22FindingStation;
    public AudioSource ID24TalkingTurtle1;
    public AudioSource ID24TalkingTurtle2;
    public AudioSource ID24TalkingTurtle3;
    public AudioSource ID24TalkingTurtle4;
    public AudioSource ID25LoadingCargo;
    public AudioSource ID26FillingOil;
    public AudioSource ID26FiringLamp;
    public AudioSource ID85Ticketing;

    [Header("Train1")]
    public AudioSource ID27MovingCoal;
    public AudioSource ID27GettingRing;
    public AudioSource ID28BreakingCoal;
    public AudioSource ID29OpeningDoor;
    public AudioSource ID29ClosingDoor;
    public AudioSource ID29PuttingCoal;
    public AudioSource ID29Firing;

    [Header("Train3")]
    public AudioSource ID30AdjustingFrameAngle;
    public AudioSource ID31CleaningChair;
    public AudioSource ID32PullingOutNail;
    public AudioSource ID32PuttingNail;
    public AudioSource ID32Hammering;

    [Header("Train4")]
    public AudioSource ID33UnloadingCargo;
    public AudioSource ID34MovingCover;
    public AudioSource ID34MovingTrash1;
    public AudioSource ID34MovingTrash2;

    [Header("Bank")]
    public AudioSource ID37TalkingFox1;
    public AudioSource ID37TalkingFox2;
    public AudioSource ID37TalkingFox3;
    public AudioSource ID38Writing;
    public AudioSource ID40CleaningWindow;
    public AudioSource ID41CarringVine;
    public AudioSource ID42OpeningSafe1;
    public AudioSource ID42OpeningSafe2;
    public AudioSource ID42OpeningSafe3;
    public AudioSource ID42OpeningSafe4;

    [Header("Store")]
    public AudioSource ID43PuttingObject;
    public AudioSource ID44CuttingCake;
    public AudioSource ID45PlayingMusicBefore;
    public AudioSource ID45PlayingMusic;
    public AudioSource ID46OpeningMap;

    [Header("Factory")]
    public AudioSource ID48MatchPuzzle;
    public AudioSource ID49ReadyToBreak;
    public AudioSource ID49PuttingDown;
    public AudioSource ID50TurningPipe;
    public AudioSource ID50MatchingPipe;

    [Header("Health Center")]
    public AudioSource ID51TakingBottle;
    public AudioSource ID52TurningDial1;
    public AudioSource ID52TurningDial2;
    public AudioSource ID52CallingDial;
    public AudioSource ID53_1;
    public AudioSource ID53_2;
    public AudioSource ID54OpeningBlanket;

    [Header("TownHall")]
    public AudioSource ID55ChoppingWood;
    public AudioSource ID56Firing;
    public AudioSource ID56FiringWood;
    public AudioSource ID57PouringTea;
    public AudioSource ID58MatchingBall;
    public AudioSource ID59CleaningBook;

    [Header("PoliceOfficer")]
    public AudioSource ID84TalkingCroco1;
    public AudioSource ID84TalkingCroco2;
    public AudioSource ID84TalkingCroco3;
    public AudioSource ID84TalkingCroco4;
    public AudioSource ID61Finding;
    public AudioSource ID62TurningHandle;
    public AudioSource ID62OpeningDoor;
    public AudioSource ID63MatchingPicture1;
    public AudioSource ID63MatchingPicture2;

    [Header("Judge")]
    public AudioSource ID83TalkingWolf1;
    public AudioSource ID83TalkingWolf2;
    public AudioSource ID83TalkingWolf3;
    public AudioSource ID83TalkingWolf4;
    public AudioSource ID69Hammering;
    public AudioSource ID70Signing;

    [Header("Tower")]
    public AudioSource ID72MatchingTime;
    public AudioSource ID73TurningLever;
    public AudioSource ID74TurningGear;
    public AudioSource ID76MatchingFrequency;

    [Header("Streat")]
    public AudioSource ID79MovingTrash;
    public AudioSource ID79FindingJewel;
    public AudioSource ID80MovingTrash1;
    public AudioSource ID80MovingTrash2;
    public AudioSource ID81OpeningBox;
    public AudioSource D82ShakingTree;

    public void PlayRndSound(AudioSource[] _sources)
    {
        foreach (var source in _sources)
        {
            if (source.isPlaying)
                source.Stop();
        }

        int rndNum = Random.Range(0, _sources.Length);

        _sources[rndNum].Play();
    }
}