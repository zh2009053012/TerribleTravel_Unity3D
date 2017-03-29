using UnityEngine;
using System.Collections;

public class GameStateDining : IStateBase {

	private GameStateDining()
	{}

	private static GameStateDining m_instance;
	private static object m_lockHelper = new object();
	public static GameStateDining Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateDining ();
				}
			}
		}
		return m_instance;
	}
	//
	DiningUI uiCtr;
	public void Enter(GameStateBase owner)
	{
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
//		GameObject prefab = Resources.Load ("DiningScene")as GameObject;
//		GameObject go = GameObject.Instantiate (prefab);
//		uiCtr = go.GetComponent<DiningUI> ();
//		uiCtr.Init (GameData.HasEye);
		ResourcesManager.Instance.Load("DiningScene", (Object asset)=>{
			GameObject go = GameObject.Instantiate ((GameObject)asset);
			uiCtr = go.GetComponent<DiningUI> ();
			uiCtr.Init (GameData.HasEye);
		});
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
			GameStateManager.Instance ().FSM.ChangeState (GameStateHall.Instance ());
		} else if (message.Equals ("Table")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateDiningTable.Instance());
		}
	}
}
