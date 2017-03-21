using UnityEngine;
using System.Collections;

public class HallHitUI : MonoBehaviour {

	public void OnClothingRoomClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("ClothingRoom", null);
	}
	public void OnKitchenClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Kitchen", null);
	}
	public void OnDiningRoomClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("DiningRoom", null);
	}
	public void OnUndergroundGarageClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("UndergroundGarage", null);
	}
	public void OnSecondFloorClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("SecondFloor", null);
	}
}
