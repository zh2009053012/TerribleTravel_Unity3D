using UnityEngine;
using System.Collections;

public class DiningTableUI : ActionBase {
	public GameObject smallEye;
	public GameObject bigEye;
	public Animator m_anim;
	public GameObject eyeHit;
	public void Init(bool haveEye){
		if (haveEye) {
			eyeHit.SetActive (false);
		}
	}

	public void OnOutClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Out", null);
	}
	public override void Play (int eventID)
	{

		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		smallEye.SetActive (false);
		m_anim.SetBool ("play", true);
	}
	public void OnShowEyeAniOver(){
		m_anim.SetBool ("play", false);
		GameStateManager.Instance ().FSM.CurrentState.Message ("ShowEyeAniOver", null);	
		NotifyActionOverEvent ();
	}
}
