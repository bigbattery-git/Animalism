using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.OrganizeBooks
{
    public class Book : MonoBehaviour, IPointerDownHandler
    {
        public int bookID;
        [SerializeField] private BookBundle bundle;

        public void OnPointerDown(PointerEventData eventData)
        {
            OVSoundRoot.Instance.Mission.ID59CleaningBook.Play();
            bundle.SetBookTransform(this.transform);
        }
    }
}