using UnityEngine;
using System.Collections;

public class SeedAction : ActionBase {
	public Animator m_seedAni;
	public GameObject m_cleanSeedGO;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_seedAni.SetBool("play", true);
		m_cleanSeedGO.SetActive(false);
		Debug.Log(m_cleanSeedGO.name+","+m_cleanSeedGO.activeSelf);
	}
	public void OnSeedAniPlayOver(){
		Debug.Log("over:"+m_cleanSeedGO.name+","+m_cleanSeedGO.activeSelf);
		m_cleanSeedGO.SetActive(false);
		m_isPlaying = false;
		m_seedAni.SetBool("play", false);
		NotifyActionOverEvent();
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		//
		GameData.HasSeed = true;
		GameStateManager.Instance().FSM.GlobalState.Message("GetSeed", null);
	}
}
