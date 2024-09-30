using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.CleaningTheFloor
{
    public class Life : MonoBehaviour
    {
        [SerializeField] GameObject lifePrefab;
        [SerializeField] Sprite usedLife;

        [SerializeField] List <Image> lifeImage = new List<Image> ();

        CleaningTheFloorManager manager;

        private void Start()
        {
            manager = GameObject.Find("Cleaning the floor").GetComponent<CleaningTheFloorManager>();

            CreateLife(manager.MissionSetCount);

            manager.onClearMission.AddListener(ChangeLifeSprite);
        }
        private void CreateLife(int _life)
        {
            for(int i = 0; i< _life; ++i)
            {
               GameObject obj = Instantiate(lifePrefab, this.transform);
               Image image = obj.GetComponent<Image>();
                lifeImage.Add(image);
            }
        }
        public void ChangeLifeSprite()
        {
            lifeImage[manager.MissionClearCount].sprite = usedLife;
            lifeImage[manager.MissionClearCount].GetComponent<RectTransform>().sizeDelta = new Vector2(122.2821f, 132.4557f);
        }
    }
}