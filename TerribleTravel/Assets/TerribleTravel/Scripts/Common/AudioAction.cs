using UnityEngine;
using System.Collections;

public class AudioAction : ActionBase {
	public AudioClip m_audioClip;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		if(null != m_audioClip){
			AudioManager.Instance.PlayAudio(m_audioClip, false);
		}
	}
}
