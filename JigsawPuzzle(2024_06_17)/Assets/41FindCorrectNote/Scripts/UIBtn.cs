using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Missons.Village.FindCorrectNote
{
    public class UIBtn : MonoBehaviour
    {
        [SerializeField] private FindCorrectNoteManager manager;
        [SerializeField] private Image image;
        private int noteNum;        
        public int NoteNum => noteNum;

        public void Init()
        {
            noteNum = 0;
            image.sprite = manager.Notes[noteNum];
        }

        public void SetRightNoteImage()
        {
            noteNum++;

            if (noteNum >= manager.Notes.Length) noteNum = 0;

            image.sprite = manager.Notes[noteNum];
        }

        public void SetLeftNoteImage()
        {
            noteNum--;

            if(noteNum < 0 ) noteNum = manager.Notes.Length - 1;

            image.sprite = manager.Notes[noteNum];
        }
    }
}