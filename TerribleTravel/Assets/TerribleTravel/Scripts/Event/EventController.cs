using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
[RequireComponent(typeof(EventTrigger))]
public class EventController : MonoBehaviour {
	[SerializeField]
	protected int m_id=1;//event id
	[SerializeField]
	protected bool m_repeat=true;
	[SerializeField]
	protected CursorManager.CursorState m_cursor;
	[SerializeField]
	protected string m_triggerMsg;
	[SerializeField]
	protected string m_hint;
	[SerializeField]
	protected GameObject m_openShowGO;
	[SerializeField]
	protected GameObject m_openHideGO;
	[SerializeField]
	protected GameObject m_closeShowGO;
	[SerializeField]
	protected GameObject m_closeHideGO;
	protected bool m_isTrigger=false;
	public bool IsTrigger{
		get{return m_isTrigger;}
	}
	public bool IsOpen{
		get{
			
			EventData ed = EventConfig.GetEventDataCopy(m_id);
			//Debug.Log("Check IsOpen:"+m_id+ed.m_openRequiredList.Count);
			foreach(int requiredID in ed.m_openRequiredList){
				if(!EventManager.IsEventClose(requiredID)){
					Debug.Log("not open");
					return false;
				}
			}
			return true;
		}
	}
	//protected bool m_isClose = false;
	public bool IsClose{
		get{return EventManager.IsEventClose(m_id);}
		set{
			//m_isClose = value;
			EventManager.SetEventClose(m_id, value);
		}
	}
	[SerializeField]
	protected List<ActionBase> m_actionList = new List<ActionBase>();

	void Start(){
		if (IsClose) {
			if (null != m_closeShowGO) {
				m_closeShowGO.SetActive (true);
			}
			if (null != m_closeHideGO) {
				m_closeHideGO.SetActive (false);
			}
		}
		else if (IsOpen) {
			if (null != m_openShowGO) {
				Debug.Log("open show");
				m_openShowGO.SetActive (true);
			}
			if(null != m_openHideGO){
				m_openHideGO.SetActive(false);
			}
		}
	}

	void OnActionOver(int id){
		foreach(ActionBase ad in m_actionList){
			if(!ad.IsActionOver){
				return;
			}
		}
		IsClose = true;
	}
	public void Play(){
		if(m_actionList.Count <= 0){
			//Debug.Log("set close"+m_id);
			IsClose = true;
			return;
		}
		Debug.Log ("action list:"+m_actionList.Count);
		foreach(ActionBase ab in m_actionList){
			ab.AddActionOverNotify(OnActionOver);
			ab.Play(m_id);
		}
	}

	void Update(){
		
	}
	//
	MessageUI m_msgCtr;
	public void OnCursorEnter(){
		if(IsOpen){
			if (!m_repeat && IsClose) {
				return;
			}
			m_isTrigger = true;
			CursorManager.SetCursor(m_cursor);
			if (!string.IsNullOrEmpty (m_hint)) {
				m_msgCtr = MessageUI.AutoShowMessage (m_hint, false, ()=>{
					if(null != m_msgCtr){
						GameObject.Destroy(m_msgCtr.gameObject);
						m_msgCtr = null;
					}
				}, 1);
			}
		}
	}
	public void OnCursorExit(){
		//Debug.Log ("exit");
		if(m_isTrigger)
		{
			if(null != m_msgCtr){
				GameObject.Destroy(m_msgCtr.gameObject);
				m_msgCtr = null;
			}
			m_isTrigger = false;
			CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		}
	}
	//
	MessageUI m_triggerMsgCtr;
	public void OnCursorSelect(){
		if(m_isTrigger){
			if (!string.IsNullOrEmpty (m_triggerMsg)) {
				m_triggerMsgCtr = MessageUI.AutoShowMessage (m_triggerMsg, true, ()=>{
					if(null != m_triggerMsgCtr){

						GameObject.Destroy(m_triggerMsgCtr.gameObject);
						m_triggerMsgCtr = null;
					}
				}, 2);
			}
			Play();
		}
	}

}
