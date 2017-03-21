using UnityEngine;
using System.Collections;

public class GameMenu : GameStateBase {

	// Use this for initialization
	void Start () {
		FSM = new StateMachine (this);
		GameStateManager.Instance ().FSM = FSM;

		FSM.ChangeState (GameStateMenu.Instance ());
//		FSM.GlobalState = GameGlobalState.Instance ();
//		FSM.GlobalState.Enter (FSM.Owner);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
	}

}
