
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.StainedGlassRotation
{
    public class Glass : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        private const float rotateSpeed = 100f;
        private const float limitAngle = 10f;

        [SerializeField] bool isCanMove = true;
        [SerializeField] bool needToRotate;

        [SerializeField] private bool isCorrectState = false;
        private LevelManager levelManager;
        public bool IsCorrectState => isCorrectState;

        public Vector2 CenterPosition;
        public RectTransform center;
        public float startAngle;
        public Vector2 StartPosition;
        public float RotationSpeed = 0.05f;

        [SerializeField] private AudioSource rollSound;
        private void Awake()
        {
            CenterPosition = center.anchoredPosition;
            levelManager = GetComponentInParent<LevelManager>();
        }
        private void Start()
        {
            if (needToRotate)
            {
                int RndZ = Random.Range(100, 300);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, RndZ));
                isCanMove = true;
            }
            else
            {
                isCanMove = false;
            }
        }

        private void OnEnable()
        {
            if(needToRotate)
            {
                int RndZ = Random.Range(100, 300);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, RndZ));

                isCorrectState = false;

                isCanMove = true;
            }
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            StartPosition = eventData.position;
            float startAngle = Mathf.Atan2(StartPosition.y, StartPosition.x);         
        }


        public void OnDrag(PointerEventData eventData)
        {
            if (!isCanMove) return;

            if (!OVSoundRoot.Instance.Mission.ID3Rolling.isPlaying)
            {
                OVSoundRoot.Instance.Mission.ID3Rolling.Play();
            }

            Vector2 direction = eventData.position - CenterPosition;
            float endAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (endAngle < 0f) endAngle += 360f;

            direction = StartPosition - CenterPosition;
            float startAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (startAngle < 0f) startAngle += 360f; //

            float angleDiff = endAngle - startAngle;

            if (startAngle >= 270f && endAngle <= 90f)
            {
                angleDiff += 360f;
                transform.rotation *= Quaternion.AngleAxis(angleDiff * RotationSpeed, Vector3.back);
            }
            else if (startAngle <= 90 && endAngle >= 270)
            {
                angleDiff -= 360f;
                transform.rotation *= Quaternion.AngleAxis(angleDiff * RotationSpeed, Vector3.back);
            }
            else
            {
                transform.rotation *= Quaternion.AngleAxis(angleDiff * RotationSpeed, Vector3.forward);
            }

            StartPosition = eventData.position;

            Debug.Log("ID3Rolling, Keeping");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (transform.localEulerAngles.z < limitAngle || (360 - transform.localEulerAngles.z) < limitAngle)
            {
                if (!isCorrectState)
                {
                    
                }
                isCorrectState = true;

                OVSoundRoot.Instance.Mission.ID3Matching.Play();

                levelManager.CheckClear();
            }
            else
            {
                isCorrectState = false;
            }
        }

        public void HoldGlass() => isCanMove = false;
    }
}