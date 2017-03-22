using UnityEngine;
using System.Collections;

public class TryOpenDoorAction : ActionBase {
	public Animator m_animator;
	public GameObject m_next;
	// Use this for initialization
	void Start () {
		Debug.Log (this.gameObject.name+","+this.gameObject.activeSelf+","+this.enabled);
		if (m_next != null) {
			m_next.SetActive (false);

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void Play(int eventID){
		Debug.Log ("play:"+gameObject.name+","+m_isPlaying);
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}

		if(null != m_animator)
			m_animator.SetBool ("door", true);
		
	}
	public void AnimationOver(){
		Debug.Log ("AnimationOver:"+this.isActiveAndEnabled+","+this.gameObject.activeSelf);
		if (!this.isActiveAndEnabled || !m_isPlaying || m_isActionOver)
			return;
		if(null != m_animator)
			m_animator.SetBool ("door", false);
		
		PlayOver ();
	}
	void PlayOver(){
		//NotifyActionOverEvent ();

		if (null != m_next) {
			Debug.Log ("PlayOver next:"+m_next.gameObject.name);
			m_next.SetActive (true);
			gameObject.SetActive (false);
		}
		NotifyActionOverEvent();
	}
}
