using UnityEngine;
using System.Collections;

public class IceboxUI : MonoBehaviour {
	public GameObject m_openUpImage;
	public GameObject m_brainImage;
	public GameObject m_openDownImage;
	public Animator m_ani;

	public void Init(bool showBrain){
		if (!showBrain) {
			m_brainImage.SetActive (false);
		}
	}
	public void ShowBrainAnimation(){
		m_brainImage.SetActive (false);
		m_ani.SetBool ("play", true);
	}
}
