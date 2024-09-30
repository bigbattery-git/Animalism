using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IUIConfMafiaAblilityContext
{
    [System.Serializable]
    public struct JobPrefabPath
    {
        public string name;
        public string[] prefabPath;
    }
    public void OnClickedJobIcon(ConfJobIconInfo _jobInfo);
    public enum PanalType
    {
        TownPeople, Variation, Mafia, MaxSize
    }
    public bool IsSelectedJob { get; }
    public bool IsSelectedPlayer { get; }
    public JobPrefabPath[] JobPrefabPaths { get; }
    public PanalType MafiaAbliityPanalState { get; }
}
public interface IUIConfWindowContext
{
    [System.Serializable]
    public class PlayerConfInfo
    {
        public enum PlayerState { DIE, ELECTED, ALIVE}
        public int SeatID;
        public PlayerState State;
    }
    public void OnClickedMap();
    public int TotalPlayerCount { get; }
    public bool IsOpenedConfWindow { get; }
    public bool HasPlayerList { get; }
    public List<PlayerConfInfo> PlayerList { get; }
}
public interface IUIConfChatContext
{
    [System.Serializable]
    public struct Chat
    {
        public string chatUserName;
        public string chatContents;
        public string chatCharacterPath;
    }
    public enum ChatType { All, Dead}
    public void OnChatted();
    public void OnClickedEmoticonButton();
    public void OnClickedChatType();
    public List<Chat> ChatList { get; }
    public ChatType ChatTypes { get; }

    // public ChatType ChatType { get; }
    // public ChatterType ChatterType { get; }
}

public interface IUIConfPublicContext
{
    public void OnClickedVoteButton();
    public void OnChangedConfState();
    public int VoteCount { get; }
    public bool IsVote { get; }
    public float LeftTime { get; }
    // public ConfState ConfState{ get; }
}
public interface IUIConfETCEvent
{
    public void OnClickedConfButton();
}