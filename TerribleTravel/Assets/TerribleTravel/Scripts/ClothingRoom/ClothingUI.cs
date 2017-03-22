using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClothingUI : MonoBehaviour {
	public GameObject m_headHit;
	public Animator m_ani;

	public void Init(bool haveHead){
		if (haveHead) {
			m_headHit.GetComponent<Image> ().raycastTarget = false;
		}
	}
	public void OnOutClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Out", null);
	}
	public void OnHeadClick(){
		m_ani.SetBool ("play", true);
		//m_headGO.SetActive (false);
	}
	public void OnShowHeadAniOver(){
		m_ani.SetBool ("play", false);
		GameStateManager.Instance ().FSM.CurrentState.Message ("ShowHeadAniOver", null);
	}
}
