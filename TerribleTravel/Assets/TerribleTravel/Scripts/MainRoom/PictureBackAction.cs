using UnityEngine;
using System.Collections;

public class PictureBackAction : ActionBase {

	public GameObject m_showGO;
	public GameObject m_coinGO;
	public AudioClip m_audioClip;
	public override void Play (int eventID)
	{
		AudioManager.Instance.PlayAudio(m_audioClip, false);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		NotifyActionOverEvent();
		m_showGO.SetActive(true);
		m_coinGO.SetActive(true);
	}

}
