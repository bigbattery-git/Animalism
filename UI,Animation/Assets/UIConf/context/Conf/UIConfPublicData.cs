using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Context/Conf/PublicData", fileName = "PublicDataContext", order = 3)]
public class UIConfPublicData : ScriptableObject, IUIConfPublicContext
{
    [SerializeField] private int voteCount;
    [SerializeField] private bool isVote;
    [SerializeField] private float leftTime;
    public int VoteCount => voteCount;
    public bool IsVote => isVote;
    public float LeftTime => leftTime;

    public void OnChangedConfState()
    {
        
    }

    public void OnClickedVoteButton()
    {
        
    }
}
