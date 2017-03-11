using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventState{
	public int id;
	public bool isClose;
	public EventState(){}
	public EventState(int id, bool isClose){
		this.id = id;
		this.isClose = isClose;
	}
}

public class EventManager  {
	
	private static List<EventState> m_eventStates = new List<EventState>();

	public static EventState GetEventState(int id){
		for(int i=0; i<m_eventStates.Count; i++){
			if(m_eventStates[i].id == id){
				return m_eventStates[i];
			}
		}
		return null;
	}
	public static bool IsEventClose(int id){
		EventState es = GetEventState(id);
		if(es == null){
			return false;
		}else{
			return es.isClose;
		}
	}
	public static void SetEventClose(int id, bool isClose){
		Debug.Log("SetEventClose:"+id+","+isClose);
		EventState es=null;
		es = GetEventState(id);
		if(es != null){
			es.isClose = isClose;
		}else{
			m_eventStates.Add(new EventState(id, isClose));
		}
	}
}
