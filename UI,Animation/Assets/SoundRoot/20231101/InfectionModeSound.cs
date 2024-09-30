using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.notion.so/Infection-mode-SoundList-2023-11-05-87ede050b87a46c78ab873787172b030?pvs=4
public class InfectionModeSound : MonoBehaviour
{
    public AudioSource introOutroBGM;
    public AudioSource roomInOut;
    public AudioSource[] walkingSound;
    public AudioSource[] roundStartEnd;
    public AudioSource[] roundStateShowing;
    public AudioSource useItem_FoodSupply;
    public AudioSource useItem_Steal;
    public AudioSource useItem_Threat;
    public AudioSource[] noUseSupply;
    public AudioSource[] increaseDegreeOfInfection;
    public AudioSource stayDegreeOfInfection;
    public AudioSource useItem;
    public AudioSource getItem;
    public AudioSource lobbyWaitionRoomResult;

    public AudioSource GetRandomWalkingSound() => walkingSound[Random.Range(0, walkingSound.Length)];
    public AudioSource GetRandomRoundStartEnd()
    {
        foreach(AudioSource rse in roundStartEnd)
            rse.Stop();

        return roundStartEnd[Random.Range(0, roundStartEnd.Length)];
    }
    public AudioSource GetRanDomRoundStateShowing() => roundStateShowing[Random.Range(0, roundStateShowing.Length)];
    public AudioSource GetRandomNoUSeSupply() => noUseSupply[Random.Range(0, noUseSupply.Length)];
}
