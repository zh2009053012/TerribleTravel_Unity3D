using UnityEngine;
using System.Collections;

public class BrainAction : ActionBase {
	public IceboxUI uiCtr;
	public Animator m_anim;
	public GameObject m_bigBrainImage;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_anim.SetBool ("play",true);
		GameStateManager.Instance ().FSM.CurrentState.Message ("ShowBrain", null);
	}
	public void ShowBrainAniOver(){
		//Debug.Log ("showBrainANiOVer");
		m_anim.SetBool ("play", false);
		m_bigBrainImage.SetActive (false);
		GameStateManager.Instance ().FSM.CurrentState.Message ("ShowBrainAniOver", null);
		NotifyActionOverEvent();
	}
}
