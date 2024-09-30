using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.OrganizeBooks
{
    public class BookManager : MonoBehaviour
    {
        [SerializeField] private BookBundle[] bookBundles;
        private void OnEnable()
        {
            int rnd = Random.Range(0, bookBundles.Length);
            for(int i = 0; i < bookBundles.Length; i++)
            {
                if(i == rnd)
                {
                    bookBundles[i].gameObject.SetActive(true);
                }
                else
                {
                    bookBundles[i].gameObject.SetActive(false);
                }
            }
        }
    }
}