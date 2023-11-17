using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.EventSystems;

public class UIPrepareRanger : UIBase
{
    public RangerControllerData data;
    public UISlot_PrepareRanger slot;

    public Transform spriteTrans;
    public Transform canvasTrans;
    private Vector3 worldPosition;

    public void Init(RangerControllerData _data, Transform _canvasTrans, UISlot_PrepareRanger _slot)
    {
        data = _data;
        canvasTrans = _canvasTrans;
        slot = _slot;
        GameObject go = Managers.UI.ShowPrepareRanger(_data.name);
        spriteTrans = go.transform;
        go.transform.SetParent(transform);
        go.transform.localPosition = Define.prepareRangerOffset;
        go.transform.localScale = new Vector3(108, 108, 108);

        BindEvent(gameObject, _dragCallback: OnDrag, _type: UIEventType.Drag);
        BindEvent(gameObject, _dragCallback: OnEndDrag, _type: UIEventType.EndDrag);
    }

    public void OnDrag(PointerEventData _eventData)
    {
        slot.OnChanging();
        gameObject.SetActive(true);
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = worldPosition;
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0);
    }

    public void OnEndDrag(PointerEventData _eventData)
    {
        Managers.Event.OnVoidEvent(VoidEventType.OnChangePrepare);
        Managers.Resource.Destroy(gameObject);
    }

    public void Release()
    {
        data = null;
        slot = null;
        canvasTrans = null;
        Managers.Resource.Destroy(spriteTrans.gameObject);
        spriteTrans = null;
        worldPosition = Vector3.zero;
    }
}
