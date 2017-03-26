using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BathRoomMirrorAction : ActionBase {
	public GameObject BrokenMirror;
	public GameObject Mirror;
	public AudioClip MirrorBrokenAudio;

	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		BrokenMirror.SetActive(true);
		AudioManager.Instance.PlayAudio(MirrorBrokenAudio, false);
		StartCoroutine(OnBrokenAudioPlayOver(MirrorBrokenAudio.length));

	}
	IEnumerator OnBrokenAudioPlayOver(float second){
		yield return new WaitForSeconds(second);
		//BrokenMirror.SetActive(false);
		Mirror.SetActive(false);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		NotifyActionOverEvent();
	}

}
