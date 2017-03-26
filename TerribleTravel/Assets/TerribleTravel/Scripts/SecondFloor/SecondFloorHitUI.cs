using UnityEngine;
using System.Collections;

public class SecondFloorHitUI : MonoBehaviour {
	public GameObject m_keyGO;
	public void OnBalconyClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Balcony", null);
	}
	MessageUI msgCtr;
	public void OnStudyClick(){
//		if(GameData.HasBrain && GameData.HasCoin && GameData.HasEye && GameData.HasFinger &&
//			GameData.HasHead && GameData.HasHeart && GameData.HasLung && GameData.HasSeed && GameData.HasStomach)
		if(true)
		{
			GameStateManager.Instance ().FSM.CurrentState.Message ("Study", null);
		}else{
			msgCtr = MessageUI.AutoShowMessage("缺少一些东西才能进入", true, ()=>{
				if(null != msgCtr){
					GameObject.Destroy(msgCtr.gameObject);
					msgCtr = null;
				}
				if(null != m_keyGO){
					m_keyGO.SetActive(false);
				}
			}, 2);
		}
	}
	public void OnDaughterRoomClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("DaughterRoom", null);
	}
	public void OnBathRoomClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("BathRoom", null);
	}
	public void OnMainBedRoomClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("MainBedRoom", null);
	}
	public void OnOutClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Out", null);
	}
}
