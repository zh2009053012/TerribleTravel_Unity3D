﻿using UnityEngine;
using System.Collections;

public class GameStart : GameStateBase {

	// Use this for initialization
	void Start () {
		FSM = new StateMachine (this);
		GameStateManager.Instance ().FSM = FSM;

		FSM.ChangeState (GameStateOutDoor.Instance ());
		//FSM.ChangeState (GameStateHall.Instance ());
		FSM.GlobalState = GameStateMainUI.Instance ();
		FSM.GlobalState.Enter (FSM.Owner);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
	}
	

}
