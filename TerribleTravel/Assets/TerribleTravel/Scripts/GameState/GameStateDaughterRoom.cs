using UnityEngine;
using System.Collections;

public class GameStateDaughterRoom : IStateBase {

	private GameStateDaughterRoom()
	{}

	private static GameStateDaughterRoom m_instance;
	private static object m_lockHelper = new object();
	public static GameStateDaughterRoom Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateDaughterRoom ();
				}
			}
		}
		return m_instance;
	}
	//
	DaughterRoomUI uiCtr;
	public void Enter(GameStateBase owner)
	{
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("DaughterRoomScene")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		uiCtr = go.GetComponent<DaughterRoomUI> ();
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
			GameStateManager.Instance ().FSM.ChangeState (GameStateSecondFloor.Instance ());
		} 
	}
}
