using UnityEngine;
using System.Collections;

public class BookAction : ActionBase{
	public Animator m_bookAni;
	public GameObject m_bookCloseGO;
	public GameObject m_bookOpenGO;
	public GameObject m_bookNextHit;
	public AudioClip m_audioClip;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_bookAni.SetBool("play", true);
		m_bookCloseGO.SetActive(false);
		AudioManager.Instance.PlayAudio(m_audioClip, false);
	}
	public void OnBookAniPlayOver(){
		m_bookOpenGO.SetActive(true);
		m_bookNextHit.SetActive(true);
		m_isPlaying = false;
		m_bookAni.SetBool("play", false);
		NotifyActionOverEvent();
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
	}
}
