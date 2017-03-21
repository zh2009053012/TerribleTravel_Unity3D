using UnityEngine;
using System.Collections;

public class IceboxHitUI : MonoBehaviour {

	public void OnUpClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Up", null);
	}
	public void OnDownClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Down", null);
	}
	public void OnOutClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Out", null);
	}
}
