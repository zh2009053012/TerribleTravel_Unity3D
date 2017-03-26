using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GarageUI : MonoBehaviour {
	public GameObject m_blackSeedHit;
	public GameObject m_cleanSeedHit;
	public GameObject m_blackSeedGO;
	public GameObject m_cleanSeedGO;
	public Animator m_cleanAni;

	public void OnOutClick(){
		GameStateManager.Instance().FSM.CurrentState.Message("Out", null);
	}

	public void DoCleanSeed(){
		m_cleanAni.SetBool("play", true);

	}
	public void OnCleanAniOver(){
		Debug.Log("OnCleanAniOver");
		m_cleanAni.SetBool("play", false);
		m_blackSeedHit.GetComponent<Image>().raycastTarget = false;
		m_blackSeedHit.SetActive(false);
		m_cleanSeedHit.SetActive(true);
		m_blackSeedGO.SetActive(false);
		m_cleanSeedGO.SetActive(true);
		EventManager.SetEventClose(22, true);

	}

	public void EnterBlackSeedHit(){
		object[] p = new object[1];
		p[0] = (object)"BlackSeed";
		GameStateManager.Instance().FSM.GlobalState.Message("EnterTarget", p);
	}
	public void ExitBlackSeedHit(){
		GameStateManager.Instance().FSM.GlobalState.Message("ExitTarget", null);
	}
}
