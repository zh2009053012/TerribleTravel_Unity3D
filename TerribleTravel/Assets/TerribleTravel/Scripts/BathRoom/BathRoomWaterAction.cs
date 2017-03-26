using UnityEngine;
using System.Collections;

public class BathRoomWaterAction : ActionBase {
	public AudioClip m_waterAudio;
	public Animator m_waterAni;
	public GameObject m_handHit;
	public GameObject m_water;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_waterAni.SetBool("play", true);
		AudioManager.Instance.PlayAudio(m_waterAudio, false);

	}
	public void OnWaterAniPlayOver(){
		m_waterAni.SetBool("play", false);
		NotifyActionOverEvent();
		m_handHit.SetActive(true);
		m_water.SetActive(false);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
	}
}
