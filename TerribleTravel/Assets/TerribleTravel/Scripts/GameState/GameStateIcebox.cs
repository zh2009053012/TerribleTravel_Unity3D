﻿using UnityEngine;
using System.Collections;

public class GameStateIcebox : IStateBase {

	private GameStateIcebox()
	{}

	private static GameStateIcebox m_instance;
	private static object m_lockHelper = new object();
	public static GameStateIcebox Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateIcebox ();
				}
			}
		}
		return m_instance;
	}
	//
	IceboxUI uiCtr;
	public void Enter(GameStateBase owner)
	{
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("IceboxScene")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		uiCtr = go.GetComponent<IceboxUI> ();
		uiCtr.Init (GameData.HasBrain);
	}

	public void Execute(GameStateBase owner)
	{

	}

	public void Exit(GameStateBase owner)
	{
		if (null != uiCtr) {
			GameObject.Destroy (uiCtr.gameObject);
			uiCtr = null;
		}
	}

	public void Message(string message, object[] parameters)
	{
		if (message.Equals ("Up")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateNull.Instance ());
		} else if (message.Equals ("Down")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateKitchen.Instance ());
		} else if (message.Equals ("Out")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateKitchen.Instance ());
		} else if (message.Equals ("ShowBrainAniOver")) {
			
		} else if (message.Equals ("ShowBrain")) {
			if (!GameData.HasBrain) {
				uiCtr.ShowBrainAnimation ();
				GameData.HasBrain = true;
			}
		}
	}
}