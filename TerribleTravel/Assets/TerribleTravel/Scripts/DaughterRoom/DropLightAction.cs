using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropLightAction : ActionBase {
	public Animator m_droplightAni;
	public AudioClip m_droplightDownAudio;
	public GameObject m_droplightUpHit;
	public GameObject m_droplightDownHit;
	public GameObject m_mask;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_droplightAni.SetBool("down", true);
		AudioManager.Instance.PlayAudio(m_droplightDownAudio, false);
		m_mask.SetActive(true);
	}
	public void OnDropLightDownAniOver(){
		//
		m_isPlaying = false;
		m_droplightAni.SetBool("down", false);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		NotifyActionOverEvent();
		m_droplightUpHit.GetComponent<Image>().raycastTarget = true;
		m_droplightDownHit.GetComponent<Image>().raycastTarget = false;
	}
}
