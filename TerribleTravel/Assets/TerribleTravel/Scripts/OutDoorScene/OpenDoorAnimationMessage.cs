using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class OpenDoorAnimationMessage : MonoBehaviour {
	public UnityEvent m_event;
	public void OpenDoorAnimationOver(){
		if (null != m_event) {
			m_event.Invoke ();
		}
	}
}
