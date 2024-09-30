using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.TalkNPC
{
    [System.Serializable]
    public struct TalkSelectData
    {
        public int selectID;
        public string selectText;
    }

    [System.Serializable]
    public class TalkingData
    {
        public string talkBubbleData;
        public string talkBubbleWorngData;

        public int correctID;

        public TalkSelectData[] talkSelectData = new TalkSelectData[3];
    }

    [CreateAssetMenu(fileName = "NPC Talk Data_", menuName = "NPC Talk Data")]
    public class TalkData : ScriptableObject
    {
        public TalkingData[] talkingData;
        public string talkFinishMissionData;
    }
}

