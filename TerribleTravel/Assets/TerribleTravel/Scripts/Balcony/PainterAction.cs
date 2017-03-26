using UnityEngine;
using System.Collections;

public class PainterAction : ActionBase {
	public Animator m_painterAni;
	public GameObject m_lungGO;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_painterAni.SetBool("play", true);

	}
	public void OnPainterAniPlayOver(){
		m_isPlaying = false;
		m_painterAni.SetBool("play", false);
		NotifyActionOverEvent();
		m_lungGO.SetActive(true);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
	}
}
