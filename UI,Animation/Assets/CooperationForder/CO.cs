using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CO
{
    public enum ServerVoiceType { TEXT, VOICE, MAXSIZE };
    public enum ModeType { NONE = -1, OVIlLAGE, PANDEMIC, MAXSIZE }
    public enum Language { NONE = -1, KO, EN, MAXSIZE }

    [System.Serializable]
    public class LobbyData
    {
        public string RoomName;

        public string HostName;
        public Language Language;
        public ModeType Mode;
        public int CurrentPlayerCount;
        public int TotalPlayerCount;
        public ServerVoiceType VoiceType;
        public bool IsPublic;
        public bool IsStarted;
    }
}

