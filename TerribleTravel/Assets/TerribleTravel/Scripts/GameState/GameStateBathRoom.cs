using UnityEngine;
using System.Collections;

public class GameStateBathRoom : IStateBase {

	private GameStateBathRoom()
	{}

	private static GameStateBathRoom m_instance;
	private static object m_lockHelper = new object();
	public static GameStateBathRoom Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateBathRoom ();
				}
			}
		}
		return m_instance;
	}
	//
	BathRoomUI uiCtr;
	public void Enter(GameStateBase owner)
	{
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("BathRoomScene")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		uiCtr = go.GetComponent<BathRoomUI> ();

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
