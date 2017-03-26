using UnityEngine;
using System.Collections;

public class FingerAction : ActionBase {
	public Animator m_fingerAni;
	public GameObject m_handGO;

	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
	
		m_fingerAni.SetBool("play",true);
	}
	public void OnPlayFingerAniOver(){
		m_fingerAni.SetBool("play",false);
		m_handGO.SetActive(false);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		NotifyActionOverEvent();
		GameStateManager.Instance().FSM.GlobalState.Message("GetFinger", null);
		GameData.HasFinger = true;
	}
}
