using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class CloseDoorAnimationMessage : MonoBehaviour {
	public UnityEvent m_event;
	public void CloseDoorAnimationOver(){
		if (null != m_event) {
			m_event.Invoke ();
		}
	}
}
