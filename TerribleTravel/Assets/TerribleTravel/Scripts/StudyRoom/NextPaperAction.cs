using UnityEngine;
using System.Collections;

public class NextPaperAction : ActionBase {

	public GameObject m_bookGO;
	public GameObject m_ghostGO;
	public GameObject m_computerHit;
	public AudioClip m_audioClip;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_bookGO.SetActive(false);
		m_ghostGO.SetActive(true);
		AudioManager.Instance.PlayAudio(m_audioClip, false);
		StartCoroutine(OnGhostAniPlayOver(1.7f));
	}
	IEnumerator OnGhostAniPlayOver(float second){
		yield return new WaitForSeconds(second);
		m_computerHit.SetActive(true);
		m_ghostGO.SetActive(false);
		m_isPlaying = false;
		NotifyActionOverEvent();
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
	}
}
