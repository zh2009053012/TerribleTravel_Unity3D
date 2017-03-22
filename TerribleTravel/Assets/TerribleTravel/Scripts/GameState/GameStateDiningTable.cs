using UnityEngine;
using System.Collections;

public class GameStateDiningTable : IStateBase {

	private GameStateDiningTable()
	{}

	private static GameStateDiningTable m_instance;
	private static object m_lockHelper = new object();
	public static GameStateDiningTable Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateDiningTable ();
				}
			}
		}
		return m_instance;
	}
	//
	DiningTableUI uiCtr;
	public void Enter(GameStateBase owner)
	{
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("DiningTableScene")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		uiCtr = go.GetComponent<DiningTableUI> ();
		uiCtr.Init (GameData.HasEye);
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
		if (message.Equals ("Out")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateDining.Instance());
		} else if (message.Equals ("ShowEyeAniOver")) {
			GameData.HasEye = true;
			GameStateManager.Instance ().FSM.GlobalState.Message ("GetEye", null);
		}
	}
}
