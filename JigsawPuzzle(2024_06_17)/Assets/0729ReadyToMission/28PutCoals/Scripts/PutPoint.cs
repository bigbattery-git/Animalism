using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PutCoals
{
    public class PutPoint : MonoBehaviour
    {
        [SerializeField] private PutCoalsManager manager;

        [SerializeField] private GameObject coverClose;
        [SerializeField] private GameObject coverOpen;

        IEnumerator closeDoor;
        private void OnEnable()
        {
            CloseDoor(false);
        }
        private void OnDisable()
        {
            if(closeDoor != null)
                StopCoroutine(closeDoor);
        }
        private void CloseDoor(bool _isClosed)
        {
            coverClose.SetActive(_isClosed);
            coverOpen.SetActive(!_isClosed);
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!Input.GetMouseButton(0))
            {
                if (collision.CompareTag("MiniGameObject"))
                {
                    manager.CountUp();
                    Destroy(collision.gameObject);

                    closeDoor = CloseDoorCo();

                    if(gameObject.activeInHierarchy)
                    StartCoroutine(closeDoor);

                    manager.SpawnCoal();
                    Debug.Log("Putted");
                }
            }
        }

        IEnumerator CloseDoorCo()
        {
            CloseDoor(true);
            OVSoundRoot.Instance.Mission.ID29ClosingDoor.Play();
            OVSoundRoot.Instance.Mission.ID29Firing.Stop();
            yield return new WaitForSeconds(manager.waitTime);

            CloseDoor(false);
            OVSoundRoot.Instance.Mission.ID29OpeningDoor.Play();
            OVSoundRoot.Instance.Mission.ID29Firing.Play();
        }
    }
}