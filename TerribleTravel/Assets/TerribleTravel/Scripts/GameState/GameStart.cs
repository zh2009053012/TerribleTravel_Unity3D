﻿using UnityEngine;
using System.Collections;

public class GameStart : GameStateBase {

	// Use this for initialization
	void Start () {
		FSM = new StateMachine (this);
		GameStateManager.Instance ().FSM = FSM;

		FSM.ChangeState (GameStateStart.Instance ());
//		FSM.GlobalState = GameGlobalState.Instance ();
//		FSM.GlobalState.Enter (FSM.Owner);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
	}
	
	// Update is called once per frame
	void Update () {
		if (null != FSM)
			FSM.Update ();
	}
	void OnDestroy()
	{
		if (FSM != null && FSM.GlobalState != null) {
			FSM.GlobalState.Exit (FSM.Owner);
			FSM.CurrentState.Exit (FSM.Owner);
		}
	}
}
