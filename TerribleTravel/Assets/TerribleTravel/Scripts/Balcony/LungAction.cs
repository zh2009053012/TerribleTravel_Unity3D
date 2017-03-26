using UnityEngine;
using System.Collections;

public class LungAction : ActionBase {

	public Animator m_lungAni;
	public GameObject m_lungGO;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_lungAni.SetBool("play", true);
		m_lungGO.SetActive(false);
	}
	public void OnLungAniPlayOver(){
		m_isPlaying = false;
		m_lungAni.SetBool("play", false);
		NotifyActionOverEvent();
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		GameData.HasLung = true;
		GameStateManager.Instance().FSM.GlobalState.Message("GetLung", null);
	}
}
