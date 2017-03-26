using UnityEngine;
using System.Collections;

public class ShowDresserAction : ActionBase {
	public GameObject hideGO;
	public GameObject showGO;
	public AudioClip m_audioClip;
	public override void Play (int eventID)
	{
		NotifyActionOverEvent();
		if(null != hideGO)
			hideGO.SetActive(false);
		if(null != showGO)
			showGO.SetActive(true);
		if(null != m_audioClip){
			AudioManager.Instance.PlayAudio(m_audioClip, false);
		}
	}
}
