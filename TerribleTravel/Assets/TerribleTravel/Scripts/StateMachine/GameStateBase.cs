using UnityEngine;
using System.Collections;

public class GameStateBase : MonoBehaviour {
	public StateMachine FSM;

	void Update () {
		if (null != FSM)
			FSM.Update ();
	}
	void OnDestroy()
	{
		if (FSM != null) {
			if(FSM.GlobalState != null)
				FSM.GlobalState.Exit (FSM.Owner);
			if(FSM.CurrentState != null)
				FSM.CurrentState.Exit (FSM.Owner);
		}
	}
}
