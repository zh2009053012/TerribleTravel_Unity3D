using UnityEngine;
using System.Collections;

public class IceboxUI : MonoBehaviour {
	public GameObject m_upHit;
	public GameObject m_downHit;
	public GameObject m_openUpImage;
	public GameObject m_brainImage;
	public GameObject m_openDownImage;
	public Animator m_ani;
	public AudioClip m_ghostAudio;

	public void Init(bool showBrain){
		if (!showBrain) {
			m_brainImage.SetActive (true);
		} else {
			m_brainImage.SetActive (false);
		}
		m_upHit.SetActive (true);
		m_downHit.SetActive (true);
	}
	public void ShowBrainAnimation(){
		m_brainImage.SetActive (false);
		m_ani.SetBool ("play", true);
	}
	public void ShowIceboxUp(){
		m_openUpImage.SetActive (true);
		m_openDownImage.SetActive (false);
		m_upHit.SetActive (false);
		m_downHit.SetActive (true);
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
	}
	public void ShowIceboxDown(){
		m_openUpImage.SetActive (false);
		m_openDownImage.SetActive (true);
		m_downHit.SetActive (false);
		m_upHit.SetActive (true);
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		AudioManager.Instance.PlayAudio (m_ghostAudio, false);
		StartCoroutine (ShowIceboxDownOver(1));
	}
	IEnumerator ShowIceboxDownOver(float second){
		yield return new WaitForSeconds (second);
		m_openDownImage.SetActive (false);
	}
}
