using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 미션 관련 Utility 클래스
/// </summary>
public static class OVMissionUtility
{
    /// <summary>
    /// 오브젝트를 마우스로 드래그해서 옮길 때 사용하는 함수
    /// </summary>
    /// <param name="_rectTransform">대상 오브젝트 RectTransform</param>
    /// <param name="_canvas">이동 기준이 되는 Canvas</param>
    /// <param name="_eventData">OnDrag 파라미터 eventData</param>
    public static void ObjectMoveToDrag(RectTransform _rectTransform, Canvas _canvas, PointerEventData _eventData)
    {        
        // 캔버스의 RenderMode에 따라 Drag and Drop 방법이 달라짐
        switch (_canvas.renderMode)
        {
            // canvas�� Render Mode�� Overlay�� ��
            // canvas�� ī�޶��� ���۷����� ���� �ʿ䰡 �����Ƿ� UI ��ġ�� eventData ��ġ�� ���� �ϸ� ��
            case RenderMode.ScreenSpaceOverlay:
                _rectTransform.position = _eventData.position;
                break;

            // canvas�� Render Mode�� Camera�� ��
            // UI�� ī�޶� �°� ��ġ�ϹǷ� eventData�� ��ġ�� ���߸� ���� �𸣴� ������ �̵���
            case RenderMode.ScreenSpaceCamera:
                Camera cam = _canvas.worldCamera; // �׷��� canvas�� �������ϰ� �ִ� ī�޶� ���缭 position�� �̵���Ŵ
                Vector3 vec = Vector3.zero;

                // ī�޶��� ������Ŀ� ���� ��ǥ �޾ƿ��� ����� �ٸ�
                if (cam.orthographic) // ���ٰ� X
                {
                    // ī�޶��� Depth ������� ����̹Ƿ� screen��ǥ�� world ��ǥ�� �ٲٸ� ��
                    vec = new Vector3(cam.ScreenToWorldPoint(_eventData.position).x, cam.ScreenToWorldPoint(_eventData.position).y, 0);
                }
                else // ���ٰ� O
                {
                    // ī�޶��� Depth�� ���� ��ǥ�� �ٸ��� �����Ƿ� z���� �����ؾ���. z���� 0�̸� �׻� (0, 1, camera.z) ���
                    // UI�� z���� cam.fieldOfView + canvas.planeDistance�� ���� �׻� 0���� ���� �� ����.
                    vec = cam.ScreenToWorldPoint(Input.mousePosition + (Vector3.forward * (cam.fieldOfView + _canvas.planeDistance)));
                }
                _rectTransform.position = vec;
                break;
        }
    }

    /// <summary>
    /// 오브젝트가 마우스를 따라다니게 하는 함수
    /// </summary>
    /// <param name="_rectTransform">대상 오브젝트 RectTransform</param>
    /// <param name="_canvas">따라다니는 기준 Canvas</param>
    public static void ObjectMoveFromMouse(RectTransform _rectTransform, Canvas _canvas)
    {
        Vector3 vec = Vector3.zero;

        if (_canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            vec = Input.mousePosition;
        }
        else
        {
            Camera cam = _canvas.worldCamera;
            vec = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        _rectTransform.position = new Vector3(vec.x, vec.y, 0);
    }

    /// <summary>
    /// 오브젝트가 액자를 못벗어나게 하는 함수
    /// 오브젝트의 앵커가 액자 기준 min, max 모두 0, 0을 해야함
    /// </summary>
    /// <param name="_rectTransform">대상 오브젝트 RectTransform</param>
    /// <param name="_layerTransform">액자 RectTransform</param>
    public static void HoldInLayer(RectTransform _rectTransform, RectTransform _layerTransform)
    {
        if (_rectTransform.anchoredPosition.x > _layerTransform.sizeDelta.x)
        {
            _rectTransform.anchoredPosition = new Vector2(_layerTransform.sizeDelta.x, _rectTransform.anchoredPosition.y);
        }
        if (_rectTransform.anchoredPosition.x < 0)
        {
            _rectTransform.anchoredPosition = new Vector2(0, _rectTransform.anchoredPosition.y);
        }
        if (_rectTransform.anchoredPosition.y > _layerTransform.sizeDelta.y)
        {
            _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, _layerTransform.sizeDelta.y);
        }
        if (_rectTransform.anchoredPosition.y < 0)
        {
            _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, 0);
        }
    }

    public static int[] GetRndNumNoOverrap(int _min, int _max, int _count)
    {
        int[] returnValue = new int[_count];

        List<int> rndValue = new List<int>();
        for(int i = 0; i< _max - _min; i++)
        {
            rndValue.Add(i);
        }

        int chocedNum;
        for(int i = 0; i<returnValue.Length; i++)
        {
            chocedNum = Random.Range(0, rndValue.Count);

            returnValue[i] = rndValue[chocedNum];

            rndValue.RemoveAt(chocedNum);
        }

        return returnValue;
    }
}