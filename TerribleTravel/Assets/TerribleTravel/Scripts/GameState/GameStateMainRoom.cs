using UnityEngine;
using System.Collections;

public class GameStateMainRoom : IStateBase {


	private GameStateMainRoom()
	{}

	private static GameStateMainRoom m_instance;
	private static object m_lockHelper = new object();
	public static GameStateMainRoom Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateMainRoom ();
				}
			}
		}
		return m_instance;
	}
	//
	MainRoomUI uiCtr;
	public void Enter(GameStateBase owner)
	{
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("MainRoomScene")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		uiCtr = go.GetComponent<MainRoomUI> ();
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
