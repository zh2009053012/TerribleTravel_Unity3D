using UnityEngine;
using System.Collections;

public class BedGhostAction : ActionBase {
	public string msg = "好像并没有什么";
	public AudioClip m_ghostAudio;
	public GameObject m_bed;
	public GameObject m_ghost;
	public GameObject m_quiltGO;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		MessageUI.AutoShowMessage(msg, true, OnShowMessageOver, 2);
		m_quiltGO.SetActive(false);
	}
	public void OnShowMessageOver(){
		//
		m_isPlaying = false;
		m_quiltGO.SetActive(true);
		m_bed.SetActive(false);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		NotifyActionOverEvent();
		if(m_ghost == null)
			return;
		m_ghost.SetActive(true);
		AudioManager.Instance.PlayAudio(m_ghostAudio, false);
		AutoDestroy adCtr = m_ghost.AddComponent<AutoDestroy>();
		adCtr.AutoDestroyAfterSeconds(m_ghostAudio.length);

	}
}
