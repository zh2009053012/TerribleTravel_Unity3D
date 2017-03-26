using UnityEngine;
using System.Collections;

public class OpenBlackAction : ActionBase {
	public AudioClip m_audioClip;
	public GameObject m_nextHit;
	public GameObject m_hideHit;
	public GameObject m_blackCarOpenImage;
	public GameObject m_blackCarOpen;
	public override void Play (int eventID)
	{
		m_isPlaying = false;
		AudioManager.Instance.PlayAudio(m_audioClip, false);
		if(EventManager.IsEventClose(22))
		{
			m_nextHit.SetActive(false);
		}else{
			m_nextHit.SetActive(true);
		}


		m_blackCarOpen.SetActive(true);
		m_blackCarOpenImage.SetActive(true);
		NotifyActionOverEvent();
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);

		m_hideHit.SetActive(false);
		Debug.Log("open black car action");
	}
}
