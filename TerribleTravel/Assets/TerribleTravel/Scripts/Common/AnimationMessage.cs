using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class AnimationMessage : MonoBehaviour {
	public UnityEvent m_event;
	public void AnimationOver(){
		if (null != m_event) {
			m_event.Invoke ();
		}
	}
}
