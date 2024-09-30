using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.OrganizeBooks
{
    public class BookBundle : MonoBehaviour
    {
        private const int NullID = -1;

        private int clickedBookID = NullID;
        private int changeBookID = NullID;
        private bool isClear;

        [SerializeField] private OVMissionOrigin origin;

        private void OnEnable()
        {
            MixBooks();
            isClear = false;
            clickedBookID = NullID;
            changeBookID = NullID;
        }

        private void MixBooks()
        {
            Book[] books = transform.GetComponentsInChildren<Book>();
          
            foreach (Book book in books)
            {
                int rnd = Random.Range(1, books.Length);
                book.transform.SetSiblingIndex(rnd);
            }
        }

        public void SetBookTransform(Transform _transform)
        {
            if (isClear) return;

            if(clickedBookID == NullID)
            {
                clickedBookID = _transform.GetSiblingIndex();
                transform.GetChild(clickedBookID).localScale = new Vector3(1.1f, 1.1f, 1.1f);

                return;
            }

            if(changeBookID == NullID)
            {
                changeBookID = _transform.GetSiblingIndex();
            }

            changeChildIndex();          
        }
        
        private void changeChildIndex()
        {
            Transform clickedBookTransform = transform.GetChild(clickedBookID);
            Transform changeBookTransform = transform.GetChild(changeBookID);

            transform.GetChild(clickedBookID).localScale = new Vector3(1.0f, 1.0f, 1.0f);

            clickedBookTransform.SetSiblingIndex(changeBookID);
            changeBookTransform.SetSiblingIndex(clickedBookID);

            clickedBookID = NullID;
            changeBookID = NullID;

            Book[] books = transform.GetComponentsInChildren<Book>();
            for (int i = 0; i < transform.childCount; i++)
            {
                if (books[i].bookID != i)
                {
                    return;
                }
            }

            origin.MissionClear();
            isClear = true;
        }
    }
}