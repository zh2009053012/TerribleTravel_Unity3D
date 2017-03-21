using UnityEngine;
using System.Collections;

public class OpenDoorAndShowGhostAvtion : ActionBase {
	public Animator m_animator;
	public GameObject m_ghost;
	public AudioClip m_audioOpenDoor;
	public AudioClip m_audioCloseDoor;
	public AudioClip m_audioGhost;
	public GameObject m_next;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void Play(){
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		Debug.Log ("play OpenDoorAndShowGhost");
		if(null != m_animator)
			m_animator.SetBool ("open", true);
		AudioManager.Instance.PlayAudio (m_audioOpenDoor);
	}
	public void OpenAnimationOver(){
		
		if (!this.isActiveAndEnabled)
			return;
		ShowGhost ();
	}
	void ShowGhost(){
		if (null != m_ghost) {
			m_ghost.SetActive (true);
			AudioManager.Instance.PlayAudio (m_audioGhost);
			StartCoroutine (GhostDisappear (1));
		}
	}
	public void CloseAnimationOver(){
		if (!this.isActiveAndEnabled)
			return;
		if (null != m_next) {
			m_next.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}
	IEnumerator GhostDisappear(float second){
		yield return new WaitForSeconds (second);
		if (null != m_ghost) {
			m_ghost.SetActive (false);
		}
		if(null != m_animator)
			m_animator.SetBool ("open", false);
		AudioManager.Instance.PlayAudio (m_audioCloseDoor);
		//
		NotifyActionOverEvent ();
	}
}
