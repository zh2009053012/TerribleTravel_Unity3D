using UnityEngine;
using System.Collections;

public class OpenDoorAction : ActionBase {
	public Animator m_animator;
	public AudioClip m_audioOpenDoor;
	public GameObject m_next;
	// Use this for initialization
	void Start () {
	
	}
	
	public override void Play(){
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		Debug.Log ("play OpenDoorAction");
		if(null != m_animator)
			m_animator.SetBool ("open", true);
		AudioManager.Instance.PlayAudio (m_audioOpenDoor);
	}
	public void OpenAnimationOver(){
		if (!this.isActiveAndEnabled)
			return;
		PlayOver ();
	}
	void PlayOver(){
		if (null != m_next) {
			m_next.SetActive (true);
		}
		NotifyActionOverEvent ();
	}
}
