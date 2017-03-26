using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeartAction : ActionBase {
	public Animator m_heartAni;
	public GameObject m_heartGO;
	public GameObject m_bigHeartGO;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_heartGO.GetComponent<Image>().enabled = false;
		m_heartAni.SetBool("play", true);
	}
	public void OnShowHeartAniOver(){
		//
		m_heartAni.SetBool("play", false);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		NotifyActionOverEvent();
		m_bigHeartGO.SetActive(false);
		GameStateManager.Instance().FSM.GlobalState.Message("GetHeart", null);
		GameData.HasHeart = true;
	}
}
