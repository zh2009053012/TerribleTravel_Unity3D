using UnityEngine;
using System.Collections;

public class SecondFloorHitUI : MonoBehaviour {

	public void OnBalconyClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Balcony", null);
	}
	public void OnStudyClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Study", null);
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
