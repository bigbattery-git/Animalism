using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Missons.Village.FindCorrectNote
{
    public enum SpawnNoteState { Random, RandomOverrap, Test}
    public class FindCorrectNoteManager : OVMissionOrigin
    {
        [Header("Sprites")]
        [SerializeField] private Sprite[] rndNotes;
        [SerializeField] private Sprite[] notes;
        [SerializeField] private Sprite[] showNotes;

        public Sprite[] Notes => showNotes;

        [Header("Ability")]
        [SerializeField] private SpawnNoteState spawnNoteState;
        private int[] noteNums;
        private UIBtn[] uiBtns;

        [Header("Button")]
        [SerializeField] private Btn btnStart;
        [SerializeField] private Btn btnCheckClear;

        [Header("UI")]
        [SerializeField] private GameObject ui;

        [Header("Spawn Note")]
        [SerializeField] private RectTransform spawnTransform;
        [SerializeField] private GameObject notePrefabs;
        [SerializeField][Range(6,20)] private int spawnNoteCount;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Canvas canvas;
        [SerializeField] private float muteTime = 2f;

        private List<Note> noteObjects = new List<Note>();

        [ContextMenu("Override Show")]

        public override void Show()
        {
            base.Show();

            Init();
        }
        public override void Hide()
        {
            StopAllCoroutines();
            noteObjects.Clear();

            int childCount = spawnTransform.childCount;

            for (int i = 0; i < childCount; i++)
                Destroy(spawnTransform.GetChild(i).gameObject);

            if (audioSource)
            {
                audioSource.Stop();
            }

            OVSoundRoot.Instance.Mission.ID45PlayingMusicBefore.Stop();
            OVSoundRoot.Instance.Mission.ID45PlayingMusic.Stop();

            base.Hide();
        }

        private void Init()
        {
            switch (spawnNoteState)
            {
                case SpawnNoteState.Random:
                    SetRandomNoteNumsWithoutOverlapping();
                    break;
                case SpawnNoteState.RandomOverrap:
                    SetRandomNoteNums();
                    break;
                case SpawnNoteState.Test:
                    SetTestNoteNums();
                    break;
            }

            ui.gameObject.SetActive(true);

            uiBtns = GetComponentsInChildren<UIBtn>();
            foreach (var ui in uiBtns)
                ui.Init();

            btnStart.InitStart();
            btnCheckClear.InitCheckClear();
        }

        private void SetRandomNoteNums()
        {
            noteNums = new int[6];

            int rndNum = 0;

            for (int i = 0; i < noteNums.Length; i++)
            {
                rndNum = Random.Range(0, notes.Length);
                noteNums[i] = rndNum;
            }
        }

        private void SetTestNoteNums()
        {
            noteNums = new int[6];

            for (int i = 0; i < noteNums.Length; i++)
                noteNums[i] = 1;
        }
        private void SetRandomNoteNumsWithoutOverlapping()
        {
            noteNums = new int[6];

            List<int> rndNums = new List<int>();

            for(int i =0; i < notes.Length; i++)
                rndNums.Add(i);

            for(int i = 0; i < noteNums.Length; i++)
            {
                int rndNum = Random.Range(0, rndNums.Count);

                noteNums[i] = rndNums[rndNum];

                rndNums.RemoveAt(rndNum);
            }
        }

        public void CheckClear()
        {
            for(int i = 0; i < noteNums.Length; i++)
                if (noteNums[i] != uiBtns[i].NoteNum) return;

            MissionClear();
        }

        public void PlayMusic()
        {
            ui.SetActive(false);            
            StartCoroutine(PlayMusicCo());
        }

        private IEnumerator PlayMusicCo()
        {
            OVSoundRoot.Instance.Mission.ID45PlayingMusicBefore.Play();
            yield return new WaitForSeconds(muteTime);

            OVSoundRoot.Instance.Mission.ID45PlayingMusic.Play();

            for (int i = 0; i< spawnNoteCount - 6; i++)
            {
                noteObjects.Add(SpawnNote(rndNotes[Random.Range(0, rndNotes.Length)]));
            }

            int splitNum = spawnNoteCount / 6;
            for(int i = 0; i< 6; i++)
            {
                Sprite insertSprite = notes[noteNums[i]];
                noteObjects.Insert(Random.Range(splitNum * i, splitNum * (i+1)), SpawnNote(insertSprite));
            }

            foreach(var notes in noteObjects)
            {
                notes.gameObject.SetActive(true);
                yield return new WaitForSeconds((float)20 / spawnNoteCount);
            }

            while(spawnTransform.childCount != 0)
            {
                yield return null;
            }

            noteObjects.Clear();
            ui.SetActive(true);            
        }

        private Note SpawnNote(Sprite _sprite)
        {
            Note note = Instantiate(notePrefabs, spawnTransform).GetComponent<Note>();
            note.Init(_sprite, canvas);
            note.GetComponent<RectTransform>().localPosition = Vector3.zero;
            note.gameObject.SetActive(false);

            return note;
        }
    }
}