using UnityEngine;
using System.Collections;

public class KitchenHitUI : MonoBehaviour {

	public void OnIceboxClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Icebox", null);
	}
	public void OnCleanClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Clean", null);
	}
	public void OnOutClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Out", null);
	}
}
