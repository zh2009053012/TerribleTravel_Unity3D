using UnityEngine;
using System.Collections;

public class MainRoomPictureAction : ActionBase {
	public GameObject m_msg;
	public GameObject m_showGO;
	public AudioClip m_audioClip;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_msg.SetActive(true);
		StartCoroutine(OnShowMessageOver(15));
		AudioManager.Instance.PlayAudio(m_audioClip, false);
	}
	IEnumerator OnShowMessageOver(float second){
		//
		yield return new WaitForSeconds(second);
		m_msg.SetActive(false);
		m_isPlaying = false;
		m_showGO.SetActive(true);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		NotifyActionOverEvent();

	}
}
