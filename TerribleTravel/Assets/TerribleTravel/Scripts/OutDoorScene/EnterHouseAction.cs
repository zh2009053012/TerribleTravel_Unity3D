using UnityEngine;
using System.Collections;

public class EnterHouseAction : ActionBase {

	// Use this for initialization
	void Start () {
	
	}
	
	public override void Play(int eventID){
		GameStateManager.Instance().FSM.CurrentState.Message("EnterHouse", null);
		//
		NotifyActionOverEvent ();
	}
}
