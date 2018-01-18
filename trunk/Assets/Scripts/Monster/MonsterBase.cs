using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class MonsterBase : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
	private RectTransform rt ;
	void Start ()
	{
		rt = gameObject.GetComponent<RectTransform>();
		Trace.trace("Start",Trace.CHANNEL.UI);
	}


	public void OnBeginDrag(PointerEventData eventData)
	{
		Trace.trace("OnBeginDrag",Trace.CHANNEL.UI);
		SetDraggedPosition(eventData);
	}

	public void OnDrag(PointerEventData data)
	{
		Trace.trace("OnDrag",Trace.CHANNEL.UI);
			SetDraggedPosition(data);
	}

	private void SetDraggedPosition(PointerEventData data)
	{
		Vector3 globalMousePos;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, data.position, data.pressEventCamera, out globalMousePos))
		{
			rt.position = globalMousePos;

		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Trace.trace("OnEndDrag",Trace.CHANNEL.UI);
			SetDraggedPosition(eventData);
	}

}
