using UnityEngine;
using System.Collections;

public class WindowAction : ActionBase {
	public Animator m_shadowAni;
	public GameObject m_shadow;
	public AudioClip m_hitWindowAudio;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_shadowAni.SetBool("play", true);
		AudioManager.Instance.PlayAudio(m_hitWindowAudio, true);

	}
	public void OnShadowAniPlayOver(){
		AudioManager.Instance.StopAudio(m_hitWindowAudio.name);
		m_shadowAni.SetBool("play", false);
		NotifyActionOverEvent();
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
	}
}
