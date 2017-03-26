using UnityEngine;
using System.Collections;

public class WaterBottleAction : ActionBase {
	public GameObject m_smallWaterBottle;
	public Animator m_ani;
	public AudioClip m_audioClip;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		m_smallWaterBottle.SetActive(false);
		m_ani.SetBool("play", true);
		if(null != m_audioClip)
			AudioManager.Instance.PlayAudio(m_audioClip, false);
	}	
	public void OnWaterBottleAniOver(){
		//
		Debug.Log("water bottle action");
		m_isPlaying = false;
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
		NotifyActionOverEvent();
		m_ani.SetBool("play", false);
		GameData.HasWaterBottle = true;
		GameStateManager.Instance().FSM.GlobalState.Message("GetWaterBottle", null);
	}
}
