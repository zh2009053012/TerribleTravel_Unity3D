using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropLightUpAction : ActionBase {
	public GameObject m_mask;
	public Animator m_droplightAni;
	public AudioClip m_droplightUpAudio;
	public GameObject m_droplightDownHit;
	public GameObject m_droplightUpHit;

	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_droplightAni.SetBool("up", true);
		AudioManager.Instance.PlayAudio(m_droplightUpAudio, false);

	}

	public void OnDropLightUpAniOver(){
		m_isPlaying = false;
		m_droplightAni.SetBool("up", false);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		NotifyActionOverEvent();
		m_droplightUpHit.GetComponent<Image>().raycastTarget = false;
		m_droplightDownHit.GetComponent<Image>().raycastTarget = true;
		m_mask.SetActive(false);
	}
}
