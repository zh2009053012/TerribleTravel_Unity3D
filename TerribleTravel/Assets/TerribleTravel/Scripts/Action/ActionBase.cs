using UnityEngine;
using System.Collections;

public class ActionBase : MonoBehaviour, IAction {
	private static int ID=0;
	public static int GenerateID{
		get{return ID++;}
	}

	protected int m_id;
	protected bool m_isActionOver = false;
	public bool IsActionOver{
		get{return m_isActionOver;}
	}
	protected event System.Action<int> m_notifyEvent;
	public void AddActionOverNotify(System.Action<int> notify){
		m_notifyEvent += notify;
	}
	protected void NotifyActionOverEvent(){
		m_isActionOver = true;
		if (null != m_notifyEvent) {
			m_notifyEvent.Invoke (ID);
		}
	}
	protected bool m_isPlaying = false;

	public virtual void Play(int eventID){
		Debug.Log ("virtual play");
	}
}
