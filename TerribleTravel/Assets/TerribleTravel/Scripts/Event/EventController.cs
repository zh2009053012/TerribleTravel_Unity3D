using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EventController : MonoBehaviour {
	[SerializeField]
	protected int m_id=1;//event id
	[SerializeField]
	protected CursorManager.CursorState m_cursor;
	protected bool m_isTrigger=false;
	public bool IsTrigger{
		get{return m_isTrigger;}
	}
	public bool IsOpen{
		get{
			
			EventData ed = EventConfig.GetEventDataCopy(m_id);
			Debug.Log("Check IsOpen:"+m_id+ed.m_openRequiredList.Count);
			foreach(int requiredID in ed.m_openRequiredList){
				if(!EventManager.IsEventClose(requiredID)){
					Debug.Log("not open");
					return false;
				}
			}
			return true;
		}
	}
	protected bool m_isClose = false;
	public bool IsClose{
		get{return m_isClose;}
		set{
			m_isClose = value;
			EventManager.SetEventClose(m_id, m_isClose);
		}
	}
	[SerializeField]
	protected List<ActionBase> m_actionList = new List<ActionBase>();

	void Start(){

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
			Debug.Log("set close"+m_id);
			IsClose = true;
			return;
		}
		foreach(ActionBase ab in m_actionList){
			ab.AddActionOverNotify(OnActionOver);
			ab.Play();
		}
	}

	void Update(){
		
	}
	public void OnCursorEnter(){
		if(IsOpen){
			m_isTrigger = true;
			Debug.Log ("enter");
			CursorManager.SetCursor(m_cursor);
		}
	}
	public void OnCursorExit(){
		if(m_isTrigger)
		{
			CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		}
	}
	public void OnCursorSelect(){
		if(m_isTrigger){
			Play();
		}
	}

}
