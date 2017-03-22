using UnityEngine;
using System.Collections;

public class CleanUI : MonoBehaviour {
	public GameObject haveStomachGO;
	public GameObject notHaveStomachGO;
	public Animator m_anim;
	public void Init(bool haveStomach){
		haveStomachGO.SetActive (haveStomach);
		notHaveStomachGO.SetActive (!haveStomach);
		//

	}
	public void OnOutClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Out", null);
	}
	public void OnShowStomachOver(){
		Debug.Log ("OnShowStomachOver");
		GameStateManager.Instance ().FSM.CurrentState.Message ("ShowStomachAniOver", null);
		m_anim.SetBool ("play", false);
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
	}
	public void OnShowStomach(){
		if (null != m_anim) {
			m_anim.SetBool ("play", true);
		}
	}
}
