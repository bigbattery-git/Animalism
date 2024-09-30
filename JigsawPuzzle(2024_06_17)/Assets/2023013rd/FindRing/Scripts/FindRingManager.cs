using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Missons.Village.FindRing
{
    public class FindRingManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] obstacles;
        [SerializeField] private GameObject ringPrefab;
        private List <GameObject> obstaclesList = new List <GameObject>();
        private GameObject ring;
        [SerializeField] private int m_column;
        [SerializeField] private int m_row;

        private void Awake()
        {            
            SpawnObstaclesAndRing(m_column, m_row);
        }
        private void SpawnObstaclesAndRing(int _column, int _row)
        {
            Transform backGroundTransform = transform.Find("Background").GetComponent<Transform>();
            ring = Instantiate(ringPrefab, backGroundTransform);
            for (int i = 0; i < _row; ++i)
            {
                for(int j = 0; j < _column; ++j)
                {
                    int rndObstacle = UnityEngine.Random.Range(0, obstacles.Length);

                    GameObject obj = Instantiate(obstacles[rndObstacle], backGroundTransform);
                    obstaclesList.Add(obj);
                }
            }
            
        }
        private void ResetRingPosition()
        {
            RectTransform backGround = transform.Find("Background").GetComponent<RectTransform>();
            float width = UnityEngine.Random.Range(150 , backGround.rect.width - 150);
            float height = UnityEngine.Random.Range(150, backGround.rect.height - 150);
            ring.GetComponent<RectTransform>().position = backGround.position + new Vector3(width, height);
        }
        private void ResetObstaclePotion(int _column, int _row)
        {
            RectTransform backGround = transform.Find("Background").GetComponent<RectTransform>();
            Vector2 startSpawnVector = new Vector2(backGround.rect.width, backGround.rect.height);
            int listCount = 0;
            for (int i = 0; i < _row; ++i)
            {
                for (int j = 0; j < _column; ++j)
                {   
                    int rndtransform = UnityEngine.Random.Range(-100, 101);

                    Vector2 spawnVector = backGround.position + new Vector3((startSpawnVector.x / _row) * i + rndtransform, (startSpawnVector.y / _column) * j + rndtransform);

                    if(obstaclesList[listCount].activeInHierarchy == false) obstaclesList[listCount].SetActive(true);
                    obstaclesList[listCount].GetComponent<RectTransform>().position = spawnVector;
                    listCount++;
                }
            }
        }
        private void DeactiveObstacles()
        {
            foreach(var obstacle in obstaclesList)
            {
                obstacle.SetActive(false);
            }
        }
        private void OnEnable()
        {
            ResetRingPosition();
            ResetObstaclePotion(m_column,m_row);            
        }
        public void OnClickCancleButton()
        {

        }
        public void Clear()
        {
            Debug.Log("GameClear");
        }
    }
}