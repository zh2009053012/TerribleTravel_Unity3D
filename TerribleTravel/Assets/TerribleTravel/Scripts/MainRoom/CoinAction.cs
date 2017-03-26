using UnityEngine;
using System.Collections;

public class CoinAction : ActionBase {
	public GameObject m_coin;
	public Animator m_coinAni;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_coin.SetActive(false);
		m_coinAni.SetBool("play",true);
	}
	public void OnCoinAniOver(){
		//
		m_isPlaying = false;
		m_coinAni.SetBool("play",false);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		NotifyActionOverEvent();
		GameData.HasCoin = true;
		//GameStateManager.Instance().FSM.GlobalState.Message("GetCoin", null);
	}
}
