using Missons.Village.StainedGlassRotation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.OpenTheSafe
{
    public class Handle : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {

        #region 레거시
        /*
        [SerializeField] private float rotateSpeed = 30.0f;

        private float angle;

        private float finishAngle;
        private Vector2 target, mouse;

        private RectTransform rectTransform;

        private int preNum;
        private int currentNum;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            target = rectTransform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            mouse = Camera.main.ScreenToWorldPoint(eventData.position);

            angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg + finishAngle;

            this.transform.rotation = Quaternion.AngleAxis(angle - 90 , Vector3.forward);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            finishAngle = rectTransform.rotation.z;
        }

        private float SetAnglePosition(float _angle)
        {
            float angle = Mathf.CeilToInt(_angle);            

            // 1
            if(angle <= 0 &&  angle > -37)
            {
                currentNum = 1;
                return -37f;
            }

            // 2
            else if(angle <= -37 &&  angle > -70)
            {
                currentNum = 2;
                return -70f;
            }

            // 3
            else if(angle <= -70 && angle > -108)
            {
                currentNum = 3;
                return -108f;
            }

            // 4
            else if(angle <= -108 && angle > -143)
            {
                currentNum = 4;
                return -143f;
            }

            // 5
            else if(angle <= -143 && angle > -180)
            {
                currentNum = 5;
                return -180f;
            }

            // 6
            else if(angle <= -180 && angle > -215)
            {
                currentNum = 6;
                return -215f;
            }

            // 7
            else if(angle <= -215 && angle > -251)
            {
                currentNum = 7;
                return -251f;
            }
            
            // 8
            else if (angle > -270 && angle <= -251 || angle <= 90 &&  angle > 72)
            {
                currentNum = 8;
                return 72f;
            }

            // 9
            else if(angle <= 72 && angle > 39)
            {
                currentNum = 9;
                return 39f;
            }

            // 0
            else if(angle <= 39 && angle > 0)
            {
                currentNum = 0;
                return 0;
            }
            
            return 0f;
        }
        */
        #endregion
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

        public float AngleAccu = 0.0f;

        private void Awake()
        {
            CenterPosition = center.anchoredPosition;
            Debug.Log("CenterPosition : " + CenterPosition.x + ", " + CenterPosition.y);
            levelManager = GetComponentInParent<LevelManager>();
        }
        private void Start()
        {
            if (needToRotate)
            {
                int RndZ = UnityEngine.Random.Range(100, 300);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, RndZ));
                isCanMove = true;
            }
            else
            {
                isCanMove = false;
            }
        }

        private void Update()
        {
            float angle = 36;

            if(AngleAccu > angle)
            {
                AngleAccu -= angle;
                //transform.rotation = Quaternion.AngleAxis(30 + transform.rotation.z, Vector3.back);
                transform.rotation *= Quaternion.AngleAxis(-angle, Vector3.back);
            }

            if (AngleAccu < -angle)
            {
                AngleAccu += angle;
                // transform.rotation = Quaternion.AngleAxis(-30 + transform.rotation.z, Vector3.back);
                transform.rotation *= Quaternion.AngleAxis(angle, Vector3.back);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            StartPosition = eventData.position;
            float startAngle = Mathf.Atan2(StartPosition.y, StartPosition.x);
        }


        public void OnDrag(PointerEventData eventData)
        {
            Vector2 direction = eventData.position - CenterPosition;
            Debug.Log($"endPosition : {eventData.position.x}, {eventData.position.y}\n");
            float endAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (endAngle < 0f) endAngle += 360f;

            Debug.Log($"startPosition : {StartPosition.x}, {StartPosition.y}\n");
            direction = StartPosition - CenterPosition;
            float startAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (startAngle < 0f) startAngle += 360f; //

            float angleDiff = endAngle - startAngle;

            Debug.Log($"startAngle : {startAngle}\n" +
                $"endAngle : {endAngle}, " +
               $"angleDiff : {angleDiff}");

            if (startAngle >= 270f && endAngle <= 90f)
            {
                angleDiff += 360f;
                AngleAccu += angleDiff;
               //transform.rotation *= Quaternion.AngleAxis(angleDiff * RotationSpeed, Vector3.back);
            }
            else if (startAngle <= 90 && endAngle >= 270)
            {
                angleDiff -= 360f;
                AngleAccu += angleDiff;
                //transform.rotation *= Quaternion.AngleAxis(angleDiff * RotationSpeed, Vector3.back);
            }
            else
            {
                AngleAccu += angleDiff;
                //transform.rotation *= Quaternion.AngleAxis(angleDiff * RotationSpeed, Vector3.forward);
            }

            StartPosition = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {


           
        }

        public void HoldGlass() => isCanMove = false;
    }
}